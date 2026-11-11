using ClassGenerator.Markdown;

namespace ClassGenerator.Parsers.Helix;

public sealed class HelixEndpoint
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Tag { get; init; }
    public required string Summary { get; init; }
    public required string Description { get; init; }
    public required string DocumentationUrl { get; init; }
    public required string HttpVerb { get; init; }
    public required string Path { get; init; }
    public required string SuccessCode { get; init; }
    public List<DocField> QueryParameters { get; init; } = [];
    public List<DocField> RequestBody { get; init; } = [];
    public List<DocField> ResponseBody { get; init; } = [];
}
