using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchHypeTrainEvent : Resource, ITwitcherSharp<TwitchHypeTrainEvent>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string EventType { get; set; }
	public string EventTimestamp { get; set; }
	public string Version { get; set; }
	public TwitchEventData EventData { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainEvent object.
    /// </summary> 
    public static TwitchHypeTrainEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchHypeTrainEvent
		{
			Id = data.Get("id").AsString(),
			EventType = data.Get("event_type").AsString(),
			EventTimestamp = data.Get("event_timestamp").AsString(),
			Version = data.Get("version").AsString(),
			EventData = data.Get("event_data").As<TwitchEventData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_hype_train_event.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("event_type", EventType);
		request.Set("event_timestamp", EventTimestamp);
		request.Set("version", Version);
		request.Set("event_data", EventData);
		return request;
	}
}
