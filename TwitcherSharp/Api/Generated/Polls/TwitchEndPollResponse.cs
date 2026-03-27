using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchEndPollResponse : RefCounted, ITwitcherSharp<TwitchEndPollResponse>
{
    private GodotObject _data;
    public TwitchPoll[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollResponse object.
    /// </summary> 
    public static TwitchEndPollResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchEndPollResponse
        {
            Data = dataArray.Select(TwitchPoll.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_poll.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
