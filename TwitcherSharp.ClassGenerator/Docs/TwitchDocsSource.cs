using System.Text.RegularExpressions;
using ClassGenerator.Markdown;

namespace ClassGenerator.Docs;

/// <summary>
/// Loads a Twitch reference (index page plus the per-resource Markdown pages it links to).
/// Every download is written to a snapshot folder so changes in the docs show up in git,
/// and so generation can run offline from that snapshot.
/// </summary>
public sealed partial class TwitchDocsSource(string snapshotDirectory, bool offline)
{
    private const string IndexFileName = "index.md";

    private static readonly HttpClient Http = new();

    public async Task<TwitchReference> LoadAsync(string indexUrl)
    {
        var index = await LoadPageAsync(IndexFileName, indexUrl);
        var pageUrls = PageLinkRegex().Matches(index)
            .Select(m => m.Groups["url"].Value)
            .Where(url => url.StartsWith(indexUrl[..^3] + "/"))
            .Distinct()
            .ToList();

        var pages = new List<MarkdownPage>();
        foreach (var url in pageUrls)
        {
            var fileName = url[(url.LastIndexOf('/') + 1)..];
            pages.Add(MarkdownPage.Parse(fileName, await LoadPageAsync(fileName, url)));
        }

        return new TwitchReference(MarkdownPage.Parse(IndexFileName, index), pages);
    }

    private async Task<string> LoadPageAsync(string fileName, string url)
    {
        var snapshotPath = Path.Combine(snapshotDirectory, fileName);
        if (offline) return await File.ReadAllTextAsync(snapshotPath);

        var markdown = await Http.GetStringAsync(url);
        Directory.CreateDirectory(snapshotDirectory);
        await File.WriteAllTextAsync(snapshotPath, markdown);
        return markdown;
    }

    [GeneratedRegex(@"\((?<url>https://dev\.twitch\.tv/[^)#\s]+\.md)(?:#[^)]*)?\)")]
    private static partial Regex PageLinkRegex();
}

public sealed record TwitchReference(MarkdownPage Index, IReadOnlyList<MarkdownPage> Pages);
