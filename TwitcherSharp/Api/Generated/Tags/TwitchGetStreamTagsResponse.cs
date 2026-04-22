using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchGetStreamTagsResponse : RefCounted, ITwitcherSharp<TwitchGetStreamTagsResponse>
{
    private GodotObject _data;
    public TwitchStreamTag[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetStreamTagsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetStreamTagsResponse
        {
            Data = dataArray.Select(TwitchStreamTag.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_tags.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
