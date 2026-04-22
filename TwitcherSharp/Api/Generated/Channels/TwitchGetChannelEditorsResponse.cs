using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetChannelEditorsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelEditorsResponse>
{
    private GodotObject _data;
    public TwitchChannelEditor[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEditorsResponse object.
    /// </summary> 
    public static TwitchGetChannelEditorsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelEditorsResponse
        {
            Data = dataArray.Select(TwitchChannelEditor.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_editors.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
