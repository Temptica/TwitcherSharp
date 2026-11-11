namespace ClassGenerator.Markdown;

public sealed class DocField
{
    public required string Name { get; init; }
    public required string Path { get; init; }
    public required string Type { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNullable { get; init; }
    public string Description { get; set; } = string.Empty;
    public List<string> EnumValues { get; } = [];
    public List<DocField> Children { get; } = [];

    public bool IsArray => Type.EndsWith("[]");

    public DocField Child(string name) => Children.FirstOrDefault(c => c.Name == name);

    public IEnumerable<DocField> Descendants() => Children.SelectMany(c => c.Descendants().Prepend(c));
}
