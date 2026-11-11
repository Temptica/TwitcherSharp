using System.Text.RegularExpressions;
using ClassGenerator.Docs;
using ClassGenerator.Markdown;

namespace ClassGenerator.Parsers.EventSub;

/// <summary>
/// Reads the Markdown EventSub reference (https://dev.twitch.tv/docs/eventsub/reference.md and the pages it links to)
/// into one <see cref="EventSubSubscriptionType"/> per subscription type and version.
/// </summary>
public static partial class EventSubReferenceParser
{
    public static List<EventSubSubscriptionType> Parse(TwitchReference reference)
    {
        var types = new List<EventSubSubscriptionType>();

        foreach (var page in reference.Pages)
        {
            foreach (var section in page.Sections.Where(s => s.Subsection("Subscription") != null))
            {
                types.Add(ParseType(page, section));
            }
        }

        Console.WriteLine($"{types.Count} eventsub subscription types parsed");
        return types;
    }

    private static EventSubSubscriptionType ParseType(MarkdownPage page, MarkdownSection section)
    {
        var subscription = section.Subsection("Subscription").Text;
        var type = TypeRegex().Match(subscription);
        var version = VersionRegex().Match(subscription);
        if (!type.Success || !version.Success)
            throw new FormatException($"No type or version found for '{section.Id}'");

        return new EventSubSubscriptionType
        {
            Type = type.Groups["value"].Value,
            Version = version.Groups["value"].Value,
            Description = section.Text,
            DocumentationUrl =
                $"https://dev.twitch.tv/docs/eventsub/reference/{Path.GetFileNameWithoutExtension(page.Name)}/#{section.Id}",
            Scopes = ParseScopes(section.Subsection("Authorization")),
            Condition = ChildrenOf(section.Subsection("Subscription Request Body"), "condition"),
            Event = ParseEvent(section.Subsection("Event Payload")),
        };
    }

    private static List<string> ParseScopes(MarkdownSection authorization) =>
        authorization == null
            ? []
            : ScopeRegex().Matches(authorization.Text).Select(m => m.Groups["scope"].Value).Distinct().ToList();

    private static List<DocField> ChildrenOf(MarkdownSection section, string fieldName) =>
        section == null
            ? []
            : DocFieldListParser.Parse(section.Lines).FirstOrDefault(f => f.Name == fieldName)?.Children ?? [];

    private static List<DocField> ParseEvent(MarkdownSection payload)
    {
        var fields = ChildrenOf(payload, "event");
        return fields.Count > 0 ? fields : ChildrenOf(payload, "events");
    }

    [GeneratedRegex(@"^- Type: `(?<value>[^`]+)`", RegexOptions.Multiline)]
    private static partial Regex TypeRegex();

    [GeneratedRegex(@"^- Version: `(?<value>[^`]+)`", RegexOptions.Multiline)]
    private static partial Regex VersionRegex();

    [GeneratedRegex(@"\*\*(?<scope>[a-z_]+(?::[a-z_]+){1,2})\*\*")]
    private static partial Regex ScopeRegex();
}
