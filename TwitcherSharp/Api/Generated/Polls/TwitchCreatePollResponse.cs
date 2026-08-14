using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchCreatePollResponse : RefCounted, ITwitcherSharp<TwitchCreatePollResponse>
{
    private GodotObject? _data;
    public TwitchPoll[]? Data { get => field ??= _data?.GetArray<TwitchPoll>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePollResponse object.
    /// </summary> 
    public static TwitchCreatePollResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePollResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
