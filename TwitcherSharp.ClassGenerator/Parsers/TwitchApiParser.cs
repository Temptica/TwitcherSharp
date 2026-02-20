using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.Api;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace ClassGenerator.Parsers;

// V2
public class TwitchApiParser
{
    private const string Path = "openapi.json";

    private OpenApiDocument Definition { get; set; }
    private IDictionary<string, TwitchGenComponent> Components { get; } = new Dictionary<string, TwitchGenComponent>();
    private TwitchGenComponent Pagination { get; set; }
    private List<TwitchGenMethod> Methods { get; } = [];

    public async Task ParseApi()
    {
        await using var stream = File.OpenRead(Path);

        var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);

        Definition = openApiDocument ??
                     throw new Exception(
                         $"Failed to parse OpenAPI document: {diagnostic.Errors.FirstOrDefault()?.Message}");

        var pagination = new TwitchGenComponent("TwitchPagination", "_",
            "Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through");

        pagination.AddField(new TwitchGenField
        {
            Name = "Cursor",
            Type = "string",
        });

        Components[pagination.ClassName] = pagination;
        Pagination = pagination;

        ParseComponents();
        ParsingPaths();
    }

    private void ParseComponents()
    {
        var schemas = Definition.Components.Schemas;
        foreach (var (name, schema) in schemas)
        {
            if (schema.Type != "object") continue;

            var @ref = "#/components/schemas/" + name;
            var component = new TwitchGenComponent(name, @ref, schema.Description);
            ParseProperties(component, schema);
            Components[name] = component;
        }

        //for each component, check for children, 
        foreach (var component in Components.Values)
        {
            foreach (var field in component.GetAllFields())
            {
                if (!field.IsTyped) continue;

                if (!Components.TryGetValue(field.CleanedArrayType, out var subComponent)) continue;
                component.AddComponent(subComponent);
            }
        }
    }

    private void ParseProperties(TwitchGenComponent component, OpenApiSchema schema)
    {
        foreach (var (name, property) in schema.Properties)
        {
            var field = new TwitchGenField
            {
                Name = name,
                Description = property.Description,
                Type = GetParamType(property),
                IsRequired = schema.Required?.Contains(name) ?? false
            };

            if (name.Equals("pagination", StringComparison.InvariantCultureIgnoreCase))
            {
                field.Type = "TwitchPagination";
                field.TypedComponent = Pagination;
                component.AddComponent(Pagination);
                component.AddField(field);
                continue;
            }

            var className = name.ToPascalCase();

            //if array of objects => items -> object -> properties
            if (property.Type == "array")
            {
                field.IsArray = true;
                var items = property.Items;

                if (items.Reference != null)
                {
                    field.Type = "Twitch" + items.Reference.ReferenceV3.Split("/").Last();
                    field.TypedComponent = GetComponentByRef(items.Reference.ReferenceV3);
                    component.AddComponent(field.TypedComponent);
                }
                else if (items.Properties.Count > 0)
                {
                    var subComponent = AddSubComponent(className, field.Description, component, items);
                    field.Type = "Twitch" + subComponent.Ref.Split("/").Last();
                    field.TypedComponent = subComponent;
                    component.AddComponent(field.TypedComponent);
                }
                else
                {
                    field.Type = GetParamType(property.Items);
                }
            }
            else if (property.Properties.Count > 0)
            {
                var subComponent = AddSubComponent(className, field.Description, component, property);
                field.Type = "Twitch" + subComponent.Ref.Split("/").Last();
                field.TypedComponent = subComponent;
                component.AddComponent(field.TypedComponent);
            }
            else if (component.Ref.Contains("GetAdSchedule",StringComparison.CurrentCultureIgnoreCase) && name.EndsWith("At",StringComparison.CurrentCultureIgnoreCase))
            {
                field.Type = "float"; //WHYYY TWITCH
            }

            component.AddField(field);
        }
    }

    private TwitchGenComponent AddSubComponent(string className, string description, TwitchGenComponent parentComponent,
        OpenApiSchema schema)
    {
        var @ref = $"{parentComponent.Ref}/{className}";
        var subComponent = new TwitchGenComponent(className, @ref, description);
        ParseProperties(subComponent, schema);
        return subComponent;
    }

    private void ParsingPaths()
    {
        var paths = Definition.Paths;

        foreach (var (path, methodSpecs) in paths)
        {
            foreach (var (httpVerb, methodSpec) in methodSpecs.Operations)
            {
                var method = ParseMethod(httpVerb, methodSpec);
                method.Path = path;

                var tag = methodSpec.Tags[0].Name.Replace(" ", string.Empty);
                if (method.ContainsOptional)
                {
                    var component = method.GetOptionalComponent();
                    Components[component.ClassName] = component;
                    component.Tag = tag;
                }

                //try find child component
                if (method.ContainsBody &&
                    Components.TryGetValue(method.BodyType.Replace("Twitch", ""), out var bodyComponent))
                {
                    bodyComponent.Tag = tag;
                }

                if (Components.TryGetValue(method.ResultType.Replace("Twitch", ""), out var responseComponent))
                {
                    responseComponent.Tag = tag;
                }

                Methods.Add(method);
            }
        }

        foreach (var component in Components.Values.Where(c => c.IsGlobal))
        {
            var componentParentTags = component
                .SubComponents
                .Select(s => s.GetTag())
                .Where(t => t != "Shared")
                .ToHashSet();

            switch (componentParentTags.Count)
            {
                case 0 when component.GetTag() != "Shared":
                    continue;
                case 1:
                    component.Tag = componentParentTags.First();
                    break;
                default:
                    component.Tag = "Shared";
                    continue;
            }
        }
    }

    private TwitchGenMethod ParseMethod(OperationType httpVerb, OpenApiOperation methodSpec)
    {
        var method = new TwitchGenMethod
        {
            HttpVerb = httpVerb.ToString(),
            Name = methodSpec.OperationId?.Replace('-', '_').ToPascalCase() ?? "Method" + httpVerb,
            Summary = methodSpec.Summary ?? "No summary provided.",
            Description = methodSpec.Description ?? "No description provided.",
            DocUrl = methodSpec.ExternalDocs?.Url.ToString() ?? "No link provided",
        };

        ParseParameters(method, methodSpec);

        // Body Type
        if (methodSpec.RequestBody != null)
        {
            var @ref = methodSpec.RequestBody.Content["application/json"].Schema.Reference.ReferenceV3;

            var component = Components.Values.FirstOrDefault(c => c.Ref == @ref);
            if (component != null) method.BodyType = component.ClassName;
        }

        // Result Type
        var response = methodSpec.Responses;

        method.ResultType = "ResponseData";
        if (response.ContainsKey("200") || response.ContainsKey("202"))
        {
            var content = response.TryGetValue("200", out var response200)
                ? response200.Content
                : response["202"].Content;


            if (content.ContainsKey("text/calendar")) method.ResultType = "ResponseData";
            else if (content.TryGetValue("application/json", out var responseJson))
            {
                var result = responseJson.Schema.Reference.ReferenceV3;

                var component = Components.Values.FirstOrDefault(c => c.Ref == result);
                if (component != null) method.ResultType = component.ClassName;
            }
        }

        // Content Type
        if (methodSpec.RequestBody != null)
        {
            var requestBody = methodSpec.RequestBody;
            method.ContentType = requestBody.Content.Keys.First();
        }
        else if (httpVerb == OperationType.Post)
        {
            method.ContentType = "application/x-www-form-urlencoded";
        }

        return method;
    }

    private static void ParseParameters(TwitchGenMethod method, OpenApiOperation methodSpec)
    {
        var parametersSpecs = methodSpec.Parameters;
        foreach (var parameterSpec in parametersSpecs)
        {
            var parameter = new TwitchGenParameter
            {
                Name = parameterSpec.Name.ToPascalCase(),
                Description = parameterSpec.Description,
                Type = GetParamType(parameterSpec.Schema),
                Required = parameterSpec.Required,
                IsTime = parameterSpec.Schema.Format == "date-time",
            };
            method.AddParameter(parameter);
        }
    }

    private static string GetParamType(OpenApiSchema schema)
    {
        if (schema.Reference != null) return "Twitch" + schema.Reference.ReferenceV3.Split('/')[0];

        var type = schema.Type;
        var format = schema.Format;

        type = type switch
        {
            "object" when schema.Items?.Reference?.ReferenceV3 is not null
                => "Twitch" + schema.Items.Reference.ReferenceV3.Split('/')[3],
            "string" => "string",
            "integer" => "int",
            "number" when format == "float" => "double",
            "number" => "int",
            "boolean" => "bool",
            "array" when schema.Items.Type == "string" => "string[]",
            "array" when schema.Items.Type == "int" => "int[]",
            "array" when schema.Items.Type == "number" => "int[]",
            "array" when schema.Items.Type == "float" => "double[]",
            "array" when schema.Items.Type == "boolean" => "bool[]",
            "array" when schema.Items?.Reference is not null
                => $"Twitch{schema.Items.Reference.ReferenceV3.Split('/')[3]}[]",
            _ => "Variant"
        };
        return type;
    }

    public TwitchGenComponent GetComponentByRef(string type) => Components.Values.FirstOrDefault(c => c.Ref == type);

    public IList<TwitchGenComponent> GetComponents()
    {
        return Components.Values.ToList();
    }

    public IList<TwitchGenMethod> GetMethods()
    {
        return Methods;
    }
}