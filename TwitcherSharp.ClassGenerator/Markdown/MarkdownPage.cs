using System.Text.RegularExpressions;

namespace ClassGenerator.Markdown;

public sealed record MarkdownSection(string Title, string Id, IReadOnlyList<string> Lines, IReadOnlyList<MarkdownSection> Subsections)
{
    public MarkdownSection Subsection(string title) =>
        Subsections.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

    public string Text => string.Join('\n', Lines).Trim();
}

public sealed partial class MarkdownPage
{
    public string Name { get; }
    public string Title { get; }
    public IReadOnlyList<MarkdownSection> Sections { get; }

    private MarkdownPage(string name, string title, IReadOnlyList<MarkdownSection> sections)
    {
        Name = name;
        Title = title;
        Sections = sections;
    }

    public static MarkdownPage Parse(string name, string markdown)
    {
        var lines = markdown.Replace("\r\n", "\n").Split('\n');
        var title = string.Empty;
        var sections = new List<MarkdownSection>();
        var headings = FindHeadings(lines);

        foreach (var heading in headings.Where(h => h.Level == 1)) title = heading.Title;

        var level2 = headings.Where(h => h.Level == 2).ToList();
        for (var i = 0; i < level2.Count; i++)
        {
            var start = level2[i].Line;
            var end = i + 1 < level2.Count ? level2[i + 1].Line : lines.Length;
            sections.Add(BuildSection(lines, headings, level2[i], start, end));
        }

        return new MarkdownPage(name, title, sections);
    }

    private static MarkdownSection BuildSection(string[] lines, List<Heading> headings, Heading heading, int start, int end)
    {
        var children = headings.Where(h => h.Level == heading.Level + 1 && h.Line > start && h.Line < end).ToList();
        var bodyEnd = children.Count > 0 ? children[0].Line : end;
        var subsections = new List<MarkdownSection>();

        for (var i = 0; i < children.Count; i++)
        {
            var childEnd = i + 1 < children.Count ? children[i + 1].Line : end;
            subsections.Add(BuildSection(lines, headings, children[i], children[i].Line, childEnd));
        }

        return new MarkdownSection(heading.Title, heading.Id, lines[(start + 1)..bodyEnd], subsections);
    }

    private static List<Heading> FindHeadings(string[] lines)
    {
        var headings = new List<Heading>();
        var inCodeBlock = false;

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].StartsWith("```"))
            {
                inCodeBlock = !inCodeBlock;
                continue;
            }

            if (inCodeBlock) continue;

            var match = HeadingRegex().Match(lines[i]);
            if (!match.Success) continue;

            headings.Add(new Heading(match.Groups["hashes"].Length, match.Groups["title"].Value.Trim(),
                match.Groups["id"].Value, i));
        }

        return headings;
    }

    private sealed record Heading(int Level, string Title, string Id, int Line);

    [GeneratedRegex(@"^(?<hashes>#{1,6})\s+(?<title>.+?)(?:\s+\{#(?<id>[^}]+)\})?\s*$")]
    private static partial Regex HeadingRegex();
}
