using System.Text;
using System.Text.RegularExpressions;

namespace ClassGenerator.Markdown;

/// <summary>
/// Parses the bullet lists Twitch uses for parameters, bodies and payloads:
/// <c>- `parent.name` — Type[, Nullable][, **Required**]. Description</c>.
/// Nesting follows the bullet indentation. A nested bullet only counts as a field when its path extends the
/// parent's path; otherwise it is an enum value or prose. Keys like <c>1.5</c> contain dots themselves.
/// </summary>
public static partial class DocFieldListParser
{
    public static List<DocField> Parse(IEnumerable<string> lines)
    {
        var roots = new List<DocField>();
        var parents = new Stack<(int Indent, DocField Field)>();
        DocField current = null;
        var description = new StringBuilder();

        foreach (var line in lines)
        {
            var fieldMatch = FieldRegex().Match(line);
            if (fieldMatch.Success && TryFindParent(fieldMatch, parents, out var parent))
            {
                Complete(current, description);
                current = CreateField(fieldMatch, parent, description);
                (parent?.Children ?? roots).Add(current);
                parents.Push((fieldMatch.Groups["indent"].Length, current));
                continue;
            }

            if (current == null) continue;

            var enumMatch = EnumValueRegex().Match(line);
            if (enumMatch.Success) current.EnumValues.Add(enumMatch.Groups["value"].Value);

            AppendDescription(description, line, enumMatch.Success);
        }

        Complete(current, description);
        return roots;
    }

    private static bool TryFindParent(Match fieldMatch, Stack<(int Indent, DocField Field)> parents, out DocField parent)
    {
        var indent = fieldMatch.Groups["indent"].Length;
        var path = fieldMatch.Groups["path"].Value;
        var candidates = parents.SkipWhile(p => p.Indent >= indent).ToList();

        parent = candidates.Count > 0 ? candidates[0].Field : null;
        if (parent != null && !path.StartsWith(parent.Path + ".")) return false;

        while (parents.Count > 0 && parents.Peek().Indent >= indent) parents.Pop();
        return true;
    }

    private static DocField CreateField(Match match, DocField parent, StringBuilder description)
    {
        var path = match.Groups["path"].Value;
        var meta = MetaRegex().Match(match.Groups["rest"].Value);
        var modifiers = meta.Groups["meta"].Value.Split(',', StringSplitOptions.TrimEntries);

        description.Append(meta.Groups["description"].Value.Trim());

        return new DocField
        {
            Name = parent == null ? path : path[(parent.Path.Length + 1)..],
            Path = path,
            Type = modifiers[0],
            IsNullable = modifiers.Contains("Nullable"),
            IsRequired = modifiers.Contains("**Required**"),
        };
    }

    private static void AppendDescription(StringBuilder description, string line, bool isListItem)
    {
        var text = line.Trim();
        if (text.Length == 0)
        {
            if (description.Length > 0 && !EndsWithBreak(description)) description.Append("\n\n");
            return;
        }

        if (isListItem || text.StartsWith("- "))
        {
            if (description.Length > 0 && !EndsWithBreak(description)) description.Append('\n');
            description.Append(text).Append('\n');
            return;
        }

        if (description.Length > 0 && !EndsWithBreak(description)) description.Append(' ');
        description.Append(text);
    }

    private static bool EndsWithBreak(StringBuilder description) => description[^1] == '\n';

    private static void Complete(DocField field, StringBuilder description)
    {
        if (field != null) field.Description = description.ToString().Trim();
        description.Clear();
    }

    [GeneratedRegex(@"^(?<indent>\s*)- `(?<path>[A-Za-z0-9_.\[\]-]+)` — (?<rest>.*)$")]
    private static partial Regex FieldRegex();

    [GeneratedRegex(@"^(?<meta>[^.]*?)(?:\.\s+(?<description>.*)|\.?\s*)$")]
    private static partial Regex MetaRegex();

    [GeneratedRegex(@"^\s*- (?:`(?<value>[^`]+)`|\*\*(?<value>[^*]+)\*\*)(?::|\s—|\s*$)")]
    private static partial Regex EnumValueRegex();
}
