using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.Api;
using ClassGenerator.Parsers;
using Godot;

namespace ClassGenerator.Generator.Api;

public class TwitchApiGenerator
{
    private static readonly string[] Suffixes = ["Response", "Body", "Opt"];

    private TwitchApiParser _apiParser;

    private readonly Dictionary<string, TwitchGenComponent> _components = [];

    public void GenerateApi(string apiPath, TwitchApiParser apiParser)
    {
        _apiParser = apiParser;
        foreach (var component in _apiParser.GetComponents())
        {
            PrepareComponent(component);
        }

        var twitchApiCode = new StringBuilder();
        twitchApiCode.AppendLine(ApiCodeStrings.TwitchApiUsings);

        var tags = _components.Values
            .Select(tgc => tgc.GetTag()).ToHashSet();

        foreach (var nameSpace in tags)
        {
            twitchApiCode.AppendLine($"using TwitcherSharp.Api.Generated.{nameSpace};");
        }

        twitchApiCode.AppendLine(ApiCodeStrings.TwitchApiHeader);
        twitchApiCode.AppendLine();

        foreach (var method in _apiParser.GetMethods())
        {
            twitchApiCode.AppendLine(ApiCodeHelper.ApiMethod(method));
        }

        twitchApiCode.AppendIndentedLine("}");

        File.WriteAllText(apiPath + "TwitchApi.cs", twitchApiCode.ToString());

        foreach (var (name, obj) in _components)
        {
            string code;
            if (obj.IsBody)
            {
                code = ApiCodeHelper.GlobalComponentCode(obj, "Body");
            }
            else if (obj.IsOpt)
            {
                code = ApiCodeHelper.GlobalComponentCode(obj, "Opt");
            }
            else if (obj.IsResponse)
            {
                code = ApiCodeHelper.GlobalComponentCode(obj, "Response");
            }
            else if(obj.IsGlobal)
            {
                code = ApiCodeHelper.GlobalComponentCode(obj);
            }
            else continue;

            var tag = obj.GetTag();
            Directory.CreateDirectory($"{apiPath}{tag}");
            File.WriteAllText($"{apiPath}{tag}/{name}.cs", code);
        }
    }

    private void PrepareComponent(TwitchGenComponent component)
    {
        var baseName = GetBaseName(component.ClassName);

        if (string.IsNullOrEmpty(component.GetTag()))
        {
            Console.Error.WriteLine($"No tag found for {component.ClassName}");
            return;
        }

        if (baseName == component.ClassName)
        {
            if (_components.ContainsKey(baseName))
            {
                Console.WriteLine($"That file shouldn't exist: {baseName}");
            }

            component.ClassName = baseName switch
            {
                "Stream" => "Twitch" + baseName,
                _ => component.ClassName
            };
        }

        _components[component.ClassName] = component;
    }

    private static string GetBaseName(string file)
    {
        return Suffixes.Aggregate(file, (current, suffix) => current.TrimSuffix(suffix));
    }
}