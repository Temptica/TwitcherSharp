using ClassGenerator.Markdown;

namespace ClassGenerator.Parsers.EventSub;

public sealed class EventSubSubscriptionType
{
    public required string Type { get; init; }
    public required string Version { get; init; }
    public required string Description { get; init; }
    public required string DocumentationUrl { get; init; }
    public List<string> Scopes { get; init; } = [];
    public List<DocField> Condition { get; init; } = [];
    public List<DocField> Event { get; init; } = [];

    public int VersionOrder => int.TryParse(Version, out var version) ? version : 1;
}
