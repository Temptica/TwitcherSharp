using System.Text.RegularExpressions;
using ClassGenerator.Docs;
using ClassGenerator.Markdown;

namespace ClassGenerator.Parsers.Helix;

/// <summary>
/// Reads the Markdown API reference (https://dev.twitch.tv/docs/api/reference.md and the pages it links to)
/// into <see cref="HelixEndpoint"/>s.
/// </summary>
public static partial class HelixReferenceParser
{
    private const string ApiBaseUrl = "https://api.twitch.tv/helix";

    public static List<HelixEndpoint> Parse(TwitchReference reference)
    {
        var index = ParseIndex(reference.Index);
        var endpoints = new List<HelixEndpoint>();

        foreach (var page in reference.Pages)
        {
            foreach (var section in page.Sections.Where(s => s.Subsection("Endpoint") != null))
            {
                if (!index.TryGetValue(section.Id, out var entry))
                {
                    Console.WriteLine($"Warning: '{section.Id}' is not listed in the API reference index, skipped");
                    continue;
                }

                endpoints.Add(ParseEndpoint(page, section, entry));
            }
        }

        Console.WriteLine($"{endpoints.Count} helix endpoints parsed");
        return endpoints;
    }

    private static Dictionary<string, IndexEntry> ParseIndex(MarkdownPage index)
    {
        var entries = new Dictionary<string, IndexEntry>();
        foreach (var section in index.Sections)
        {
            foreach (Match match in section.Lines.Select(l => IndexEntryRegex().Match(l)).Where(m => m.Success))
            {
                entries[match.Groups["id"].Value] = new IndexEntry(section.Title, match.Groups["summary"].Value.Trim());
            }
        }

        return entries;
    }

    private static HelixEndpoint ParseEndpoint(MarkdownPage page, MarkdownSection section, IndexEntry entry)
    {
        var endpoint = EndpointRegex().Match(section.Subsection("Endpoint").Text);
        if (!endpoint.Success) throw new FormatException($"No endpoint url found for '{section.Id}'");

        return new HelixEndpoint
        {
            Id = section.Id,
            Name = section.Title,
            Tag = entry.Tag,
            Summary = entry.Summary,
            Description = section.Text,
            DocumentationUrl = $"https://dev.twitch.tv/docs/api/reference/{Path.GetFileNameWithoutExtension(page.Name)}/#{section.Id}",
            HttpVerb = endpoint.Groups["verb"].Value,
            Path = endpoint.Groups["url"].Value.Replace(ApiBaseUrl, string.Empty),
            SuccessCode = ParseSuccessCode(section.Subsection("Response Codes")),
            QueryParameters = ParseFields(section.Subsection("Query Parameters")),
            RequestBody = ParseFields(section.Subsection("Request Body")),
            ResponseBody = ParseFields(section.Subsection("Response Body")),
        };
    }

    private static List<DocField> ParseFields(MarkdownSection section) =>
        section == null ? [] : DocFieldListParser.Parse(section.Lines);

    private static string ParseSuccessCode(MarkdownSection responseCodes)
    {
        var code = responseCodes?.Lines
            .Select(l => ResponseCodeRegex().Match(l))
            .FirstOrDefault(m => m.Success)?.Groups["code"].Value;

        return code is not null && code.StartsWith('2') ? code : "200";
    }

    private sealed record IndexEntry(string Tag, string Summary);

    [GeneratedRegex(@"^- \[[^\]]+\]\([^)]*#(?<id>[a-z0-9-]+)\):\s*(?<summary>.*)$")]
    private static partial Regex IndexEntryRegex();

    [GeneratedRegex(@"`(?<verb>GET|POST|PUT|PATCH|DELETE) (?<url>https://\S+)`")]
    private static partial Regex EndpointRegex();

    [GeneratedRegex(@"^- \*\*(?<code>\d{3})")]
    private static partial Regex ResponseCodeRegex();
}
