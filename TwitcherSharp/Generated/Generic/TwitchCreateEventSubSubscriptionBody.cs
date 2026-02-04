using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateEventSubSubscriptionBody : Resource, ITwitcherSharp<TwitchCreateEventSubSubscriptionBody>
{
    private GodotObject _data;
	public string Type { get; set; }
	public string Version { get; set; }
	public Variant Condition { get; set; }
	public TwitchTransport Transport { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionBody object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionBody FromObject(GodotObject data)
    {
		return new TwitchCreateEventSubSubscriptionBody
		{
			Type = data.Get("type").AsString(),
			Version = data.Get("version").AsString(),
			Condition = data.Get("condition").As<Variant>(),
			Transport = data.Get("transport").As<TwitchTransport>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("type", Type);
		request.Set("version", Version);
		request.Set("condition", Condition);
		request.Set("transport", Transport);
		return request;
	}
}
