using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetEmoteSetsResponse : RefCounted, ITwitcherSharp<TwitchGetEmoteSetsResponse>
{
    private GodotObject? _data;
    public TwitchEmote[]? Data { get => field ??= _data?.GetArray<TwitchEmote>("data"); set; }
    public string? Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEmoteSetsResponse object.
    /// </summary> 
    public static TwitchGetEmoteSetsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetEmoteSetsResponse
        {
            Template = data.Get("template").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_emote_sets.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Template != null) request.Set("template", Template);
        return request;
    }

}
