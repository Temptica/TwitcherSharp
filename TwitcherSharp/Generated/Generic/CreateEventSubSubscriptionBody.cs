using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class CreateEventSubSubscriptionBody : Resource, ITwitcherSharp<CreateEventSubSubscriptionBody>
{
    private GodotObject _data;
	public string Type { get; set; }
	public string Version { get; set; }
	public Variant Condition { get; set; }
	public Transport Transport { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateEventSubSubscriptionBody object.
    /// </summary> 
    public static CreateEventSubSubscriptionBody FromObject(GodotObject data)
    {
        return new CreateEventSubSubscriptionBody
        {

			Type = data.Get("type").AsString(),
			Version = data.Get("version").AsString(),
			Condition = data.Get("condition").As<Variant>(),
			Transport = data.Get("transport").As<Transport>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("type", Type);
		request.Set("version", Version);
		request.Set("condition", Condition);
		request.Set("transport", Transport);
		return request;
	}
}
