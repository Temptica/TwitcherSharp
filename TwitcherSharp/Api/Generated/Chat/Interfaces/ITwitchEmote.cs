using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Api.Generated.Chat.Interfaces;
public interface ITwitchEmote : ITwitcherSharp
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public ITwitchImages? Images { get; set; }
    public string[]? Format { get; set; }
    public string[]? Scale { get; set; }
    public string[]? ThemeMode { get; set; }
}
