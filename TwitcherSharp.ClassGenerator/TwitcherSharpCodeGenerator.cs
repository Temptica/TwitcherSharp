/*using System.Text;
using Microsoft.OpenApi.Readers;
using Environment = System.Environment;

namespace ClassGenerator;

public class TwitchCodeGenerator
{
    private List<TwitchBodyData> _globalsToGenerate = [];

    public async Task GenerateModels(string outputFolder)
    {
        //read from file
        await using var stream = File.OpenRead("openapi.json");

        List<TwitchObjectGroup> objectGroups = [];

        var openApiDocument = new OpenApiStreamReader().Read(stream, out _);
        var groups = openApiDocument.Paths.SelectMany(p => p.Value.Operations).ToList()
            .GroupBy(x => x.Value.Tags[0].Name)
            .OrderBy(x => x.Key)
            .ToList();
        
        foreach (var group in groups)
        {
            var groupObject = new TwitchObjectGroup()
            {
                Name = group.Key.Replace(" ", string.Empty),
                Objects = group.Select(x => TwitchApiTranslator.CreateTwitchObject(x.Value)).ToList()
            };
            objectGroups.Add(groupObject);
        }


        foreach (var group in objectGroups)
        {
            //create folder
            var folderPath = $"{outputFolder}/{group.Name}";
            Directory.CreateDirectory(folderPath);
            foreach (var twitchObject in group.Objects)
            {
                GenerateClass(twitchObject, group.Name, folderPath);
            }
        }

        foreach (var global in _globalsToGenerate.DistinctBy(g => g.Name))
        {
            var folderPath = $"{outputFolder}/Globals";
            Directory.CreateDirectory(folderPath);
            GenerateObject(global, $"{outputFolder}/Globals", "Globals", true);
        }

        
        var api = new StringBuilder();
        
        api.Append(TwitchApiUsings);
        foreach (var twitchObjectGroup in objectGroups)
        {
            api.Append($"using TwitcherSharp.Generated.{twitchObjectGroup.Name};");
            api.Append(Environment.NewLine);
        }
        
        api.Append(TwitchApiHeader);

        foreach (var group in objectGroups.SelectMany(g=> g.Objects))
        {
            api.Append(Environment.NewLine);
            api.Append(GenerateApiMethodForRequest(group));
        }
        
        api.Append(Environment.NewLine);
        api.Append('}');
        
        WriteToFile("TwitchAPI", outputFolder, ".cs", api.ToString());
    }

    private static string GenerateApiMethodForRequest(TwitchObject requestObject)
    {
        var responseName = $"{requestObject.ClassName}Response";
        var bodyName = requestObject.Body.Data.Count> 0 ? $"{requestObject.ClassName}Body" : null;
        var optNames = requestObject.Opt.Data.Count > 0 ? $"{requestObject.ClassName}Optionals" : null;
        
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"    public async Task<{responseName}> {requestObject.ClassName}(");
        if(!string.IsNullOrEmpty(bodyName)) stringBuilder.Append($"{bodyName} body");
        if(!string.IsNullOrEmpty(optNames) && !string.IsNullOrEmpty(bodyName)) stringBuilder.Append(", ");
        if(!string.IsNullOrEmpty(optNames)) stringBuilder.Append($"{optNames} opt");
        
        stringBuilder.Append(')');
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("    {");
        stringBuilder.Append(Environment.NewLine);
        
        stringBuilder.Append($"        return await _data.CallAsync<{responseName}>(\"{requestObject.ClassName}\", this");
        if(!string.IsNullOrEmpty(bodyName)) stringBuilder.Append(", body");
        if(!string.IsNullOrEmpty(optNames)) stringBuilder.Append(", opt");
        stringBuilder.Append(");");
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("    }");
        stringBuilder.Append(Environment.NewLine);
        
        return stringBuilder.ToString();
    }

    private void GenerateClass(TwitchObject twitchObject, string tag, string folderPath)
    {
        GenerateBody(twitchObject, tag, folderPath, "Body");

        GenerateBody(twitchObject, tag, folderPath, "Optionals");

        GenerateBody(twitchObject, tag, folderPath, "Response");

        GenerateObjectsForBodyType(twitchObject.Body.Data, folderPath, tag, twitchObject.ClassName.ToSnakeCase());
        
        GenerateObjectsForBodyType(twitchObject.Opt.Data, folderPath, tag, twitchObject.ClassName.ToSnakeCase());
        
        GenerateObjectsForBodyType(twitchObject.Response.Data, folderPath, tag, twitchObject.ClassName.ToSnakeCase());
    }

    private void GenerateObjectsForBodyType(List<TwitchBodyData> items, string folderPath, string tag, string godotClassName)
    {
        var nestedArrayObjects = items.Where(i => i.Type == "array" && i.ArrayType == "object").Select(i=>i.Children[0]).ToList();
        items = items.Where(i => i.Type == "Object").ToList();
        items.AddRange(nestedArrayObjects);
        Queue<TwitchBodyData> itemsToCheck = new(items);

        while (itemsToCheck.Count > 0)
        {
            var item = itemsToCheck.Dequeue();
            foreach (var child in item.Children.Where(c => c.Type == "Object"))
            {
                itemsToCheck.Enqueue(child);
            }

            GenerateObject(item, folderPath, tag, false,godotClassName);
        }
    }

    private static void GenerateBody(TwitchObject twitchObject, string tag, string folderPath, string bodyType)
    {
        var stringBuilder = new StringBuilder();
        var bodyName = twitchObject.ClassName + bodyType;

        var items = bodyType switch
        {
            "Body" => twitchObject.Body.Data,
            "Optionals" => twitchObject.Opt.Data,
            _ => twitchObject.Response.Data
        };

        if (items.Count == 0 && bodyType is "Body" or "Optionals") return;

        // HEADER
        if (items.Any(i => i.IsGlobal))
        {
            stringBuilder.Append("using TwitcherSharp.Generated.Globals;");
            stringBuilder.Append(Environment.NewLine);
        }

        stringBuilder.Append($$"""
                               using TwitcherSharp.Interfaces;
                               using Godot;
                                  
                               namespace TwitcherSharp.Generated.{{tag}};

                               public partial class {{bodyName}} : Resource, ITwitcherSharpBody<{{bodyName}}>
                               {
                                   private GodotObject _data;
                               """);


        // PROPERTIES
        GenerateProperties(stringBuilder, items);

        // FROM OBJECT
        GenerateFromObjectMethod(stringBuilder, bodyName, items);

        // TO OBJECT
        GenerateToGodotObjectMethod(stringBuilder, twitchObject, items, bodyType);

        // END
        stringBuilder.Append("""

                                     return obj;
                                 }
                             }
                             """);
        WriteToFile(twitchObject.ClassName, folderPath, $"{bodyType}.cs", stringBuilder.ToString());
    }

    private static void GenerateProperties(StringBuilder stringBuilder, List<TwitchBodyData> items)
    {
        foreach (var property in items)
        {
            stringBuilder.Append(Environment.NewLine);
            if (!string.IsNullOrWhiteSpace(property.Description))
            {
                stringBuilder.Append($"    /// <summary> {CleanDescription(property.Description)} </summary>");
                stringBuilder.Append(Environment.NewLine);
            }

            if (property.Type is "array" or "Array")
            {
                stringBuilder.Append($$"""    public {{property.ArrayType}}[] {{property.Name}} { get; set; } = [];""");
                continue;
            }

            if (property.Type == "object")
            {
                stringBuilder.Append($$"""    public {{property.Name}} {{property.Name}} { get; set; }""");
                continue;
            }

            stringBuilder.Append($$"""    public {{property.Type.ToLower()}} {{property.Name}} { get; set; }""");
        }
    }

    private static void GenerateFromObjectMethod(StringBuilder stringBuilder, string bodyName,
        List<TwitchBodyData> items)
    {
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($$"""
                                   public static {{bodyName}} FromObject(GodotObject data)
                                   {
                                       return new {{bodyName}}
                                       {
                                           _data = data,
                               """);

        foreach (var property in items)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("            ");
            switch (property.Type.ToLower())
            {
                case "object":
                    stringBuilder.Append(
                        $"""{property.Name} = {property.Name}.FromObject(data.Get("{property.GodotName}").AsGodotObject()),""");
                    break;
                default:
                    stringBuilder.Append(
                        $"""{property.Name} = data.Get("{property.GodotName}").{property.Type.GetAsType()},""");
                    break;
            }
        }
    }

    private static void GenerateToGodotObjectMethod(StringBuilder stringBuilder, TwitchObject twitchObject,
        List<TwitchBodyData> items, string bodyType = "Body")
    {
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($$"""
                                       };
                                   }
                                       
                                   public GodotObject ToGodotObject()
                                   {
                                      var script = GD.Load<GDScript>("res://addons/twitcher/generated/{{twitchObject.GodotFileName}}");
                                      var obj = script.Get("{{(bodyType is "Optionals" ? "Opt" : bodyType)}}").AsGodotObject().Call("new").AsGodotObject();
                               """);

        // TO OBJECT PROPERTIES
        foreach (var property in items)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("        ");
            if (property.Type != "Object")
            {
                stringBuilder.Append($"""obj.Set("{property.GodotName}", {property.Name});""");
            }
            else
            {
                stringBuilder.Append($"""obj.Set("{property.GodotName}", {property.Name}.ToGodotObject());""");
            }
        }
    }

    private static void GenerateToGodotObjectMethod(StringBuilder stringBuilder, TwitchBodyData twitchObject,
        List<TwitchBodyData> items, string file = null)
    {
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($$"""
                                       };
                                   }
                                       
                                   public GodotObject ToGodotObject()
                                   {
                                      var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_{{file ?? twitchObject.GodotName}}.gd");
                               """);
        stringBuilder.Append(Environment.NewLine);

        if (!string.IsNullOrEmpty(file))
        {
            stringBuilder.Append($"       var body = script.Get(\"{twitchObject.Name}\").AsGodotObject();");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("       var obj = body.Call(\"new\").AsGodotObject();");
            
        }
        else
        {
            stringBuilder.Append("       var obj = script.Call(\"new\").AsGodotObject();");
        }

        // TO OBJECT PROPERTIES
        foreach (var property in items)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("        ");
            if (property.Type != "Object")
            {
                stringBuilder.Append($"""obj.Set("{property.GodotName}", {property.Name});""");
            }
            else
            {
                stringBuilder.Append($"""obj.Set("{property.GodotName}", {property.Name}.ToGodotObject());""");
            }
        }
    }

    private void GenerateObject(TwitchBodyData data, string folderPath, string nameSpace, bool generateGlobals = false, string godotClassName = null)
    {
        var stringBuilder = new StringBuilder();
        if (data.IsGlobal && !generateGlobals)
        {
            _globalsToGenerate.Add(data);
            return;
        }

        stringBuilder.Append($$"""
                               using Godot;
                               using TwitcherSharp.Interfaces;
                                  
                               namespace TwitcherSharp.Generated.{{nameSpace}};

                               ///<summary> {{CleanDescription(data.Description)}} </summary>
                               public partial class {{data.Name}} : Resource, ITwitcherSharpBody<{{data.Name}}>
                               {
                                   private GodotObject _data;
                               """);

        var distinctChildren = data.Children.DistinctBy(c => c.Name).ToList();
        GenerateProperties(stringBuilder, distinctChildren);
        GenerateFromObjectMethod(stringBuilder, data.Name, distinctChildren);
        if (generateGlobals) GenerateToGodotObjectMethod(stringBuilder, data, distinctChildren);
        else GenerateToGodotObjectMethod(stringBuilder, data, distinctChildren, godotClassName);

        // END
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append("""
                                     return obj;
                                 }
                             }
                             """);


        WriteToFile(data.Name, folderPath, ".cs", stringBuilder.ToString());

        var childObjects = distinctChildren.Where(c => c.Type == "object").ToList();
        foreach (var childObject in childObjects)
        {
            GenerateObject(childObject, folderPath, nameSpace, generateGlobals);
        }
    }

    private static void WriteToFile(string className, string folderPath, string fileEnding, string body)
    {
        var filePath = $"{folderPath}/{className}{fileEnding}";
        File.WriteAllText(filePath, body);
        Console.WriteLine($"Generated file {filePath}");
    }
    
    public static string CleanDescription(string description)
    {
        return description.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ").Trim();
    }
}*/