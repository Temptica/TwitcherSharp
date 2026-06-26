using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChannelEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetChannelEmotesResponse>
{
    private GodotObject _data;
    public TwitchChannelEmote[] Data { get => field ??= _data?.GetArray<TwitchChannelEmote>("data"); set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEmotesResponse object.
    /// </summary> 
    public static TwitchGetChannelEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelEmotesResponse
        {
            Template = data.Get("template").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        request.Set("template", Template);
        return request;
    }

}
