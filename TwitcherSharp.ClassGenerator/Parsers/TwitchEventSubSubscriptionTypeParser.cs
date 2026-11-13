using System.Text.RegularExpressions;
using ClassGenerator.GenObjects.EventSub;
using HtmlAgilityPack;

namespace ClassGenerator.Parsers;

/// <summary>
/// Parses https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/ into the flat list of
/// subscription types (name, version, required scopes, condition fields) used to generate
/// TwitchEventSubDefinition. Condition fields are cross-referenced against the condition
/// components already parsed from the eventsub-reference page by <see cref="TwitchEventSubParser"/>.
/// </summary>
public class TwitchEventSubSubscriptionTypeParser
{
    //"https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/";
    private const string Path = "SubscriptionTypes.html";

    public List<TwitchEventSubDefinitionInfo> Definitions { get; } = [];

    // A subscription type header is a lowercase dotted name (2-4 segments), optionally suffixed with "V2"/"v2".
    // e.g. "automod.message.hold", "channel.moderate v2". This distinguishes it from the other h3 headers
    // in the same section ("Authorization", "... Request Body", "... Webhook Example", ...).
    private static readonly Regex TypeHeaderRegex =
        new(@"^[a-z][a-z0-9_]*(\.[a-z0-9_]+){1,3}(\s+[Vv]([0-9]+))?$", RegexOptions.Compiled);

    private static readonly Regex VersionRegex = new("\"version\":\\s*\"([^\"]+)\"", RegexOptions.Compiled);

    // Twitch inconsistently wraps scopes in the Authorization prose in either <code> or <strong>.
    private static readonly Regex ScopeRegex =
        new("<(?:code class=\"highlighter-rouge\"|strong)>([a-z_]+(?::[a-z_]+){1,2})</(?:code|strong)>",
            RegexOptions.Compiled);

    private static readonly Regex RequestBodyHeaderRegex = new("request-body", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex ConditionLinkRegex =
        new("eventsub-reference/#([a-z0-9-]+-condition)\"", RegexOptions.Compiled);

    // Fallback for sections whose Request Body table doesn't link to a condition object on the reference page
    // (it just says "Object"): pull the field names straight out of the first JSON "condition": { ... } block
    // in the webhook/payload example. Condition objects are always flat, so a non-greedy match up to the next
    // "}" is safe.
    private static readonly Regex ConditionJsonRegex =
        new("\"condition\":\\s*\\{([^{}]*)\\}", RegexOptions.Compiled);

    private static readonly Regex JsonKeyRegex = new("\"([a-zA-Z_][a-zA-Z0-9_]*)\"\\s*:", RegexOptions.Compiled);

    private static readonly Regex TagRegex = new("<[^>]+>", RegexOptions.Compiled);

    public async Task ParseSubscriptionTypes(List<TwitchEventSubGenComponent> conditionComponents)
    {
        await using var stream = Path.StartsWith("https://")
            ? await new HttpClient().GetStreamAsync(Path)
            : File.OpenRead(Path);
        var html = await new StreamReader(stream).ReadToEndAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var h3Nodes = doc.DocumentNode.SelectNodes("//h3").ToList();
        var typeHeaderIndices = h3Nodes
            .Select((node, index) => (node, index))
            .Where(t => TypeHeaderRegex.IsMatch(t.node.InnerText.Trim()))
            .Select(t => t.index)
            .ToList();

        for (var t = 0; t < typeHeaderIndices.Count; t++)
        {
            var i = typeHeaderIndices[t];
            var node = h3Nodes[i];
            var text = node.InnerText.Trim();
            var match = TypeHeaderRegex.Match(text);

            // A section spans until the next *type-header* h3, not just the next h3 (which would only be
            // "Authorization" and cut the section off before the scopes text and the Request Body table).
            var nextTypeHeaderIndex = t + 1 < typeHeaderIndices.Count ? typeHeaderIndices[t + 1] : h3Nodes.Count;
            var sectionStart = node.StreamPosition;
            var sectionEnd = nextTypeHeaderIndex < h3Nodes.Count ? h3Nodes[nextTypeHeaderIndex].StreamPosition : html.Length;
            var slice = html[sectionStart..sectionEnd];

            // The webhook/payload JSON examples are syntax-highlighted: each token sits in its own <span>, so
            // e.g. "version": "2" is actually "version"</span><span...>:</span>...  in the raw markup and won't
            // match a plain JSON regex. Strip tags first so the JSON reads as JSON again.
            var plainText = TagRegex.Replace(slice, "");

            var isV2 = match.Groups[2].Success;
            var value = isV2 ? text[..match.Groups[2].Index].TrimEnd() : text;

            var version = VersionRegex.Match(plainText) is { Success: true } versionMatch
                ? versionMatch.Groups[1].Value
                : "1";

            // Authorization scopes only ever show up between the type header and the "Request Body" heading;
            // scanning past that risks picking up unrelated colon-separated text in webhook/payload JSON examples.
            var requestBodyMatch = RequestBodyHeaderRegex.Match(slice);
            var scopeSlice = requestBodyMatch.Success ? slice[..requestBodyMatch.Index] : slice;
            var scopes = ScopeRegex.Matches(scopeSlice).Select(m => m.Groups[1].Value).Distinct().ToList();

            var conditions = new List<string>();
            var conditionLinkMatch = ConditionLinkRegex.Match(slice);
            if (conditionLinkMatch.Success)
            {
                var conditionId = conditionLinkMatch.Groups[1].Value;
                var conditionComponent = conditionComponents.FirstOrDefault(c => c.Id == conditionId);
                if (conditionComponent != null)
                {
                    conditions = conditionComponent.Fields.Values.Select(f => f.RawName).ToList();
                }
                else
                {
                    Console.WriteLine($"Warning: no condition component found for '{conditionId}' ({value})");
                }
            }
            else
            {
                var conditionJsonMatch = ConditionJsonRegex.Match(plainText);
                if (conditionJsonMatch.Success)
                {
                    conditions = JsonKeyRegex.Matches(conditionJsonMatch.Groups[1].Value)
                        .Select(m => m.Groups[1].Value)
                        .Distinct()
                        .ToList();
                }
                else
                {
                    Console.WriteLine($"Warning: no condition found for '{value}'");
                }
            }

            Definitions.Add(new TwitchEventSubDefinitionInfo
            {
                EnumName = ToEnumName(value) + (isV2 ? "V2" : ""),
                Value = value,
                Version = version,
                Conditions = conditions,
                Scopes = scopes,
                DocumentationLink = $"https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#{node.Id}",
            });
        }

        Console.WriteLine($"{Definitions.Count} subscription type definitions parsed");
    }

    private static string ToEnumName(string dottedValue) =>
        string.Concat(dottedValue.Split(['.', '_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpperInvariant(w[0]) + w[1..]));
}
