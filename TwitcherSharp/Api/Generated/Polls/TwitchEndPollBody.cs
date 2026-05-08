using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchEndPollBody : RefCounted, ITwitcherSharp<TwitchEndPollBody>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string Id { get; set; }
    public string Status { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollBody object.
    /// </summary> 
    public static TwitchEndPollBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPollBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Id = data.Get("id").AsString(),
            Status = data.Get("status").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_poll.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("id", Id);
        request.Set("status", Status);
        return request;
    }

}
