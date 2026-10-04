using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChannelEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetChannelEmotesResponse>
{
    private Variant _data;
    public TwitchChannelEmote[] Data { get => field ??= _data.GetArray<TwitchChannelEmote>("data")!; set; } = null!;
    public string Template { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEmotesResponse object.
    /// </summary> 
    public static TwitchGetChannelEmotesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelEmotesResponse
        {
            Template = data.Read("template", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_emotes.gd", "Response");
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
