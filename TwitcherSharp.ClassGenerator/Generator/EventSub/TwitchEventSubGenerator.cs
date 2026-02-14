using ClassGenerator.GenObjects.EventSub;
using ClassGenerator.Parsers;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubGenerator
{
    public void GenerateEventSub(string path, TwitchEventSubParser parser)
    {
        var sharedComponents = parser.SubComponents;
        foreach (var component in sharedComponents)
        {
            var code = EventSubCodeHelper.MainEventSub(component);
            File.WriteAllText(Path.Combine(path, $"{component.ClassName}.cs"), code);
        }
        
        var components = parser.Components;
        foreach (var component in components)
        {
            var code = EventSubCodeHelper.MainEventSub(component);
            File.WriteAllText(Path.Combine(path, $"{component.ClassName}.cs"), code);
        }
    }
}