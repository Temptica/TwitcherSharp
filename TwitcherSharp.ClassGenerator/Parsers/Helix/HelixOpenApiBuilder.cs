using System.Text.RegularExpressions;
using ClassGenerator.Markdown;
using Microsoft.OpenApi.Models;
using static ClassGenerator.Parsers.Helix.HelixSchemaConventions;

namespace ClassGenerator.Parsers.Helix;

/// <summary>
/// Turns the parsed Markdown endpoints into an <see cref="OpenApiDocument"/> shaped like the community spec
/// the generator was built on, so the rest of the pipeline stays unchanged.
/// </summary>
public sealed partial class HelixOpenApiBuilder
{
    private readonly OpenApiDocument _document = new()
    {
        Info = new OpenApiInfo { Title = "Twitch Helix API", Version = "1.0" },
        Paths = new OpenApiPaths(),
        Components = new OpenApiComponents(),
        Tags = [],
    };

    public static OpenApiDocument Build(IEnumerable<HelixEndpoint> endpoints)
    {
        var builder = new HelixOpenApiBuilder();
        foreach (var endpoint in endpoints) builder.AddEndpoint(endpoint);
        builder.ResolveReferences();
        return builder._document;
    }

    private void AddEndpoint(HelixEndpoint endpoint)
    {
        if (_document.Tags.All(t => t.Name != endpoint.Tag)) _document.Tags.Add(new OpenApiTag { Name = endpoint.Tag });

        var operation = new OpenApiOperation
        {
            OperationId = endpoint.Id,
            Summary = endpoint.Summary,
            Description = endpoint.Description,
            Tags = [new OpenApiTag { Name = endpoint.Tag }],
            ExternalDocs = new OpenApiExternalDocs { Description = endpoint.Name, Url = new Uri(endpoint.DocumentationUrl) },
            Parameters = endpoint.QueryParameters.Select(p => BuildParameter(endpoint.Id, p)).ToList(),
            Responses = new OpenApiResponses(),
        };

        if (endpoint.RequestBody.Count > 0) operation.RequestBody = BuildRequestBody(endpoint);

        operation.Responses[endpoint.SuccessCode] = BuildSuccessResponse(endpoint);

        if (!_document.Paths.TryGetValue(endpoint.Path, out var pathItem))
        {
            pathItem = new OpenApiPathItem();
            _document.Paths[endpoint.Path] = pathItem;
        }

        pathItem.Operations[Enum.Parse<OperationType>(endpoint.HttpVerb, true)] = operation;
    }

    private OpenApiRequestBody BuildRequestBody(HelixEndpoint endpoint)
    {
        var schema = BuildObject(endpoint.RequestBody);
        if (endpoint.Id == "update-user-extensions") ReplaceUserExtensionUpdateBody(schema);

        var name = SchemaPrefix(endpoint.Name) + "Body";
        Register(name, schema);

        return new OpenApiRequestBody
        {
            Content = { ["application/json"] = new OpenApiMediaType { Schema = Ref(name) } },
        };
    }

    private OpenApiResponse BuildSuccessResponse(HelixEndpoint endpoint)
    {
        var response = new OpenApiResponse { Description = endpoint.Summary };

        if (endpoint.Id == CalendarEndpoint)
        {
            response.Content["text/calendar"] = new OpenApiMediaType();
            return response;
        }

        if (endpoint.ResponseBody.Count == 0 || endpoint.SuccessCode == "204") return response;

        ApplyResponseRequiredness(endpoint);
        var schema = BuildObject(endpoint.ResponseBody);
        ApplyResponseConventions(endpoint, schema);

        var name = SchemaPrefix(endpoint.Name) + "Response";
        Register(name, schema);
        response.Content["application/json"] = new OpenApiMediaType { Schema = Ref(name) };
        return response;
    }

    private static void ApplyResponseRequiredness(HelixEndpoint endpoint)
    {
        var optional = OptionalResponseFields.GetValueOrDefault(endpoint.Id) ?? [];
        foreach (var field in endpoint.ResponseBody.SelectMany(f => f.Descendants().Prepend(f)))
        {
            field.IsRequired = !field.IsNullable
                               && !ConditionallyIncludedRegex().IsMatch(field.Description)
                               && !AllResponseFieldsOptional.Contains(endpoint.Id)
                               && !AlwaysOptionalResponseFields.Contains(field.Name)
                               && !optional.Contains(field.Name);
        }
    }

    private void ApplyResponseConventions(HelixEndpoint endpoint, OpenApiSchema schema)
    {
        if (UserExtensionEndpoints.Contains(endpoint.Id)) ExtractUserExtensionSchemas(schema);
        if (endpoint.Id == CheermotesEndpoint) ReplaceCheermoteImages(schema);
        if (ExtensionIconEndpoints.Contains(endpoint.Id)) ReplaceExtensionIconUrls(schema);

        foreach (var (path, name) in (SharedResponseSchemas.GetValueOrDefault(endpoint.Id) ?? []).Reverse())
        {
            var property = FindProperty(schema, path);
            if (property?.Type != "array")
                throw new InvalidOperationException($"Shared schema '{name}' expects an array at '{path}' in '{endpoint.Id}'");

            Register(name, property.Items);
            property.Items = Ref(name);
        }
    }

    private static OpenApiSchema FindProperty(OpenApiSchema schema, string path)
    {
        var data = PropertyOrNull(schema, "data");
        var segments = path.Split('.');
        if (segments.Length == 1) return data;

        var parent = segments[0] == "data[0]" ? data?.Items : data;
        return PropertyOrNull(parent, segments[1]);
    }

    private static OpenApiSchema PropertyOrNull(OpenApiSchema schema, string name)
    {
        OpenApiSchema property = null;
        schema?.Properties.TryGetValue(name, out property);
        return property;
    }

    private void ExtractUserExtensionSchemas(OpenApiSchema schema)
    {
        var data = schema.Properties["data"];
        foreach (var (property, name) in UserExtensionSchemas)
        {
            var slot = data.Properties[property];
            var slotSchema = slot.AdditionalProperties;
            Register(name, slotSchema);
            slot.AdditionalProperties = Ref(name);

            var updateSchema = new OpenApiSchema(slotSchema) { Reference = null };
            updateSchema.Properties = new Dictionary<string, OpenApiSchema>(slotSchema.Properties);
            updateSchema.Properties.Remove("name");
            Register(name + "Update", updateSchema);
        }
    }

    private void ReplaceUserExtensionUpdateBody(OpenApiSchema schema)
    {
        var data = schema.Properties["data"];
        data.Properties = UserExtensionSchemas.ToDictionary(
            e => e.Key,
            e => new OpenApiSchema { Type = "object", AdditionalProperties = Ref(e.Value + "Update") });
    }

    private void ReplaceCheermoteImages(OpenApiSchema schema)
    {
        var format = StringProperties("1", "1.5", "2", "3", "4");
        Register("CheermoteImageFormat", format);
        Register("CheermoteImageTheme", ObjectOf(("animated", Ref("CheermoteImageFormat")), ("static", Ref("CheermoteImageFormat"))));
        Register("CheermoteImages", ObjectOf(("light", Ref("CheermoteImageTheme")), ("dark", Ref("CheermoteImageTheme"))));

        schema.Properties["data"].Items.Properties["tiers"].Items.Properties["images"] = Ref("CheermoteImages");
    }

    private void ReplaceExtensionIconUrls(OpenApiSchema schema)
    {
        var properties = schema.Properties["data"].Items.Properties;
        var iconUrls = StringProperties("100x100", "24x24", "300x200");
        iconUrls.Description = properties["icon_urls"].Description;

        Register("ExtensionIconUrls", iconUrls);
        properties["icon_urls"] = Ref("ExtensionIconUrls");
    }

    private static OpenApiSchema StringProperties(params string[] names) =>
        ObjectOf(names.Select(n => (n, new OpenApiSchema { Type = "string" })).ToArray());

    private static OpenApiSchema ObjectOf(params (string Name, OpenApiSchema Schema)[] properties) => new()
    {
        Type = "object",
        Properties = properties.ToDictionary(p => p.Name, p => p.Schema),
    };

    private static OpenApiSchema BuildObject(IEnumerable<DocField> fields)
    {
        var schema = new OpenApiSchema { Type = "object" };
        foreach (var field in fields)
        {
            schema.Properties[field.Name] = BuildProperty(field);
            if (field.IsRequired) schema.Required.Add(field.Name);
        }

        return schema;
    }

    private static OpenApiSchema BuildProperty(DocField field)
    {
        var property = MapType(field.Type);
        property.Description = field.Description;
        property.Nullable = field.IsNullable || field.Description.Contains("**null**", StringComparison.OrdinalIgnoreCase);

        if (IsDateTime(property, field)) property.Format = "date-time";
        if (field.Children.Count == 0) return property;

        var children = BuildObject(field.Children);
        if (property.Type == "array")
        {
            property.Items = children;
        }
        else if (field.Type == "map[string]Object")
        {
            property.AdditionalProperties = children;
        }
        else
        {
            children.Description = field.Description;
            children.Nullable = property.Nullable;
            return children;
        }

        return property;
    }

    private static OpenApiParameter BuildParameter(string endpointId, DocField field)
    {
        var schema = MapType(field.Type);
        if (IsDateTime(schema, field)) schema.Format = "date-time";

        var isArray = IsArrayParameter(field.Description) && schema.Type != "array";
        if (isArray) schema = new OpenApiSchema { Type = "array", Items = schema };

        return new OpenApiParameter
        {
            Name = field.Name,
            In = ParameterLocation.Query,
            Description = field.Description,
            Required = field.IsRequired && !MutuallyExclusiveParameters.Contains(endpointId),
            Explode = isArray,
            Schema = schema,
        };
    }

    private static bool IsDateTime(OpenApiSchema schema, DocField field) =>
        schema.Type == "string" && (field.Name.EndsWith("_at") || field.Description.Contains("RFC3339"));

    private static bool IsArrayParameter(string description)
    {
        foreach (var regex in new[] { MaximumRegex(), UpToMaximumRegex(), MoreThanOneRegex() })
        {
            var match = regex.Match(description);
            if (!match.Success) continue;
            if (match.Groups["n"].Success && int.Parse(match.Groups["n"].Value) <= 1) continue;
            return true;
        }

        return false;
    }

    private static OpenApiSchema MapType(string type) => type switch
    {
        "String" => new OpenApiSchema { Type = "string" },
        "String[]" => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "string" } },
        "Integer" or "Unsigned Integer" => new OpenApiSchema { Type = "integer", Format = "int32" },
        "Int64" => new OpenApiSchema { Type = "integer", Format = "int64" },
        "Float" or "float" => new OpenApiSchema { Type = "number", Format = "float" },
        "Boolean" or "Bool" => new OpenApiSchema { Type = "boolean" },
        "Object" or "MediaSettings" => new OpenApiSchema { Type = "object" },
        "map[string,string]" or "map[string]string" => new OpenApiSchema
            { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "string" } },
        "map[string]Object" => new OpenApiSchema
            { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "object" } },
        _ when type.EndsWith("[]") => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "object" } },
        _ => new OpenApiSchema { Type = type },
    };

    private void Register(string name, OpenApiSchema schema)
    {
        schema.Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = name };
        _document.Components.Schemas[name] = schema;
    }

    private static OpenApiSchema Ref(string name) => new()
    {
        UnresolvedReference = true,
        Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = name },
    };

    private void ResolveReferences()
    {
        foreach (var schema in _document.Components.Schemas.Values) ResolveChildren(schema);

        foreach (var mediaType in _document.Paths.Values
                     .SelectMany(p => p.Operations.Values)
                     .SelectMany(o => o.Responses.Values.SelectMany(r => r.Content.Values)
                         .Concat(o.RequestBody?.Content.Values ?? [])))
        {
            mediaType.Schema = Resolve(mediaType.Schema);
        }
    }

    private void ResolveChildren(OpenApiSchema schema)
    {
        foreach (var key in schema.Properties.Keys.ToList())
        {
            schema.Properties[key] = Resolve(schema.Properties[key]);
            if (!IsComponent(schema.Properties[key])) ResolveChildren(schema.Properties[key]);
        }

        if (schema.Items != null)
        {
            schema.Items = Resolve(schema.Items);
            if (!IsComponent(schema.Items)) ResolveChildren(schema.Items);
        }

        if (schema.AdditionalProperties != null)
        {
            schema.AdditionalProperties = Resolve(schema.AdditionalProperties);
            if (!IsComponent(schema.AdditionalProperties)) ResolveChildren(schema.AdditionalProperties);
        }
    }

    private static bool IsComponent(OpenApiSchema schema) => schema.Reference != null;

    private OpenApiSchema Resolve(OpenApiSchema schema) =>
        schema is { UnresolvedReference: true } ? _document.Components.Schemas[schema.Reference.Id] : schema;

    [GeneratedRegex("included only if|includes this field only if|is included only", RegexOptions.IgnoreCase)]
    private static partial Regex ConditionallyIncludedRegex();

    [GeneratedRegex(@"You may specify a maximum of (?<n>\d+)")]
    private static partial Regex MaximumRegex();

    [GeneratedRegex(@"up to a maximum of (?<n>\d+)")]
    private static partial Regex UpToMaximumRegex();

    [GeneratedRegex("To specify more than one")]
    private static partial Regex MoreThanOneRegex();
}
