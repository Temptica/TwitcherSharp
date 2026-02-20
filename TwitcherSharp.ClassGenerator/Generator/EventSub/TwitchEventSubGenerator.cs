using ClassGenerator.Parsers;
using ClassGenerator.Extensions;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubGenerator
{
    public void GenerateEventSub(string path, TwitchEventSubParser parser)
    {
        foreach (var component in parser.SubComponents)
        {
            var code = EventSubCodeHelper.MainEventSub(component, "Shared");
            var actualPath = Path.Combine(path, "Shared");
            Directory.CreateDirectory(actualPath);
            File.WriteAllText(Path.Combine(actualPath, $"{component.ClassName}.cs"), code);
        }
        
        foreach (var component in parser.Components)
        {
            var nameSpace = component.ClassName.Remove("Twitch").Remove("Event").Remove("V2");
            var code = EventSubCodeHelper.MainEventSub(component, nameSpace);
            var actualPath = Path.Combine(path, nameSpace);
            Directory.CreateDirectory(actualPath);
            File.WriteAllText(Path.Combine(actualPath, $"{component.ClassName}.cs"), code);
        }

        foreach (var component in parser.ConditionComponents)
        {
            var nameSpace = component.ClassName.Remove("Twitch").Remove("Condition").Remove("V2");
            var code = EventSubCodeHelper.MainEventSub(component, nameSpace, true);
            var actualPath = Path.Combine(path, nameSpace);
            Directory.CreateDirectory(actualPath);
            File.WriteAllText(Path.Combine(actualPath, $"{component.ClassName}.cs"), code);
        }
    }
}