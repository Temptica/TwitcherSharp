using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchEndPollResponse : RefCounted, ITwitcherSharp<TwitchEndPollResponse>
{
    private GodotObject? _data;
    public TwitchPoll[] Data { get => field ??= _data?.GetArray<TwitchPoll>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollResponse object.
    /// </summary> 
    public static TwitchEndPollResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPollResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_poll.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
