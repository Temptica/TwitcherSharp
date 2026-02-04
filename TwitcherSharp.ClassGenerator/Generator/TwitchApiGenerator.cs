using System.Text;
using ClassGenerator.ApiParser;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects;
using Godot;
using Environment = System.Environment;

namespace ClassGenerator.Generator;

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
        twitchApiCode.Append(CodeStrings.TwitchApiUsings);
        twitchApiCode.Append(Environment.NewLine);

        var tags = _components.Values
            .Select(tgc => tgc.GetTag()).ToHashSet();

        foreach (var nameSpace in tags)
        {
            twitchApiCode.Append($"using TwitcherSharp.Generated.{nameSpace};");
            twitchApiCode.Append(Environment.NewLine);
        }

        twitchApiCode.Append(CodeStrings.TwitchApiHeader);
        twitchApiCode.Append(Environment.NewLine);

        foreach (var method in _apiParser.GetMethods())
        {
            twitchApiCode.Append(CodeHelper.ApiMethod(method));
            twitchApiCode.Append(Environment.NewLine);
        }

        twitchApiCode.AppendIndentedLine("}");

        File.WriteAllText(apiPath + "TwitchApi.cs", twitchApiCode.ToString());

        foreach (var (name, obj) in _components)
        {
            string code;
            if (obj.IsBody)
            {
                code = CodeHelper.ComponentCode(obj, "Body");
            }
            else if (obj.IsOpt)
            {
                code = CodeHelper.ComponentCode(obj, "Opt");
            }
            else if (obj.IsResponse)
            {
                code = CodeHelper.ComponentCode(obj, "Response");
            }
            else
            {
                code = CodeHelper.ComponentCode(obj);
            }

            var tag = obj.GetTag();
            Directory.CreateDirectory($"{apiPath}{tag}");
            File.WriteAllText($"{apiPath}{tag}/{name}.cs", code);
        }
    }

    private void PrepareComponent(TwitchGenComponent component)
    {
        var baseName = GetBaseName(component.ClassName);

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

            _components[component.ClassName] = component;
            return;
        }

        _components[component.ClassName] = component;
        component.AddMeta("fqdn", component.ClassName);
    }

    private string GetType(string type, bool isArray = false, bool fullyQualified = false)
    {
        if (!type.StartsWith('#')) return isArray ? $"{type}[]" : type;

        var component = _apiParser.GetComponentByRef(type);
        var resultType = component.ClassName;

        if (fullyQualified && component.HasMeta("fqdn"))
        {
            resultType = component.GetMeta("fqdn");
        }

        return isArray ? $"{resultType}[]" : resultType;
    }

    private static string GetBaseName(string file)
    {
        return Suffixes.Aggregate(file, (current, suffix) => current.TrimSuffix(suffix));
    }
}