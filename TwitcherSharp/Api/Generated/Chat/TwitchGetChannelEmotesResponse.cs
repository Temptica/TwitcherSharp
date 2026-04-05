using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChannelEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetChannelEmotesResponse>
{
    private GodotObject _data;
    public TwitchChannelEmote[] Data { get; set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEmotesResponse object.
    /// </summary> 
    public static TwitchGetChannelEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelEmotesResponse
        {
            Data = dataArray.Select(TwitchChannelEmote.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        request.Set("template", Template);
        return request;
    }

}
