using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Api.Generated.Chat.Interfaces;
public interface ITwitchImages : ITwitcherSharp
{
    public string Url1x { get; set; }
    public string Url2x { get; set; }
    public string Url4x { get; set; }
}
