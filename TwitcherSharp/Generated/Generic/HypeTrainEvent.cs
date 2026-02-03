using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class HypeTrainEvent : Resource, ITwitcherSharp<HypeTrainEvent>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string EventType { get; set; }
	public string EventTimestamp { get; set; }
	public string Version { get; set; }
	public EventData EventData { get; set; }
    /// <summary> 
    /// Transforms the godot data into a HypeTrainEvent object.
    /// </summary> 
    public static HypeTrainEvent FromObject(GodotObject data)
    {
        return new HypeTrainEvent
        {

			Id = data.Get("id").AsString(),
			EventType = data.Get("event_type").AsString(),
			EventTimestamp = data.Get("event_timestamp").AsString(),
			Version = data.Get("version").AsString(),
			EventData = data.Get("event_data").As<EventData>(),
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
