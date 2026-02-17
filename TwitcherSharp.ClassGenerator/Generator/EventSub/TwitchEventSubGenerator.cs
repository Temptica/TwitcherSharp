using ClassGenerator.Parsers;
using ClassGenerator.Extensions;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubGenerator
{
    public void GenerateEventSub(string path, TwitchEventSubParser parser)
    {
        var sharedComponents = parser.SubComponents;
        foreach (var component in sharedComponents)
        {
            var code = EventSubCodeHelper.MainEventSub(component, "Shared");
            var actualPath = Path.Combine(path, "Shared");
            Directory.CreateDirectory(actualPath);
            File.WriteAllText(Path.Combine(actualPath, $"{component.ClassName}.cs"), code);
        }
        
        var components = parser.Components;
        foreach (var component in components)
        {
            var nameSpace = component.ClassName.Remove("Twitch").Remove("Event").Remove("V2");
            var code = EventSubCodeHelper.MainEventSub(component, nameSpace);
            var actualPath = Path.Combine(path, nameSpace);
            Directory.CreateDirectory(actualPath);
            File.WriteAllText(Path.Combine(actualPath, $"{component.ClassName}.cs"), code);
        }
    }
}