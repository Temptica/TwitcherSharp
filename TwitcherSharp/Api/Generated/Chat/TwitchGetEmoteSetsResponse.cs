using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetEmoteSetsResponse : RefCounted, ITwitcherSharp<TwitchGetEmoteSetsResponse>
{
    private Variant _data;
    public TwitchEmote[] Data { get => field ??= _data.GetArray<TwitchEmote>("data")!; set; } = null!;
    public string Template { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEmoteSetsResponse object.
    /// </summary> 
    public static TwitchGetEmoteSetsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetEmoteSetsResponse
        {
            Template = data.Read("template", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_emote_sets.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Template != null) request.SetValue("template", Template);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
