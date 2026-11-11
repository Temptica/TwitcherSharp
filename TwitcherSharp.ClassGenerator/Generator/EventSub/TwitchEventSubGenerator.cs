using ClassGenerator.Parsers;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubGenerator
{
    public static void GenerateEventSub(string path, TwitchEventSubParser parser)
    {
        foreach (var component in parser.SubComponents.Concat(parser.Components))
        {
            Write(path, component, EventSubCodeHelper.MainEventSub(component, component.NameSpace));
        }

        foreach (var component in parser.ConditionComponents)
        {
            Write(path, component, EventSubCodeHelper.MainEventSub(component, component.NameSpace, true));
        }
    }

    private static void Write(string path, TwitchEventSubGenComponent component, string code)
    {
        var directory = Path.Combine(path, component.NameSpace);
        Directory.CreateDirectory(directory);
        File.WriteAllText(Path.Combine(directory, $"{component.ClassName}.cs"), code);
    }
}
