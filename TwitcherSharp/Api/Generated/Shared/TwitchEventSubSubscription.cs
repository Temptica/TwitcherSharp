using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchEventSubSubscription : Resource, ITwitcherSharp<TwitchEventSubSubscription>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Status { get; set; }
	public string Type { get; set; }
	public string Version { get; set; }
	public Variant Condition { get; set; }
	public string CreatedAt { get; set; }
	public TwitchTransport Transport { get; set; }
	public int Cost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventSubSubscription object.
    /// </summary> 
    public static TwitchEventSubSubscription FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchEventSubSubscription
		{
			Id = data.Get("id").AsString(),
			Status = data.Get("status").AsString(),
			Type = data.Get("type").AsString(),
			Version = data.Get("version").AsString(),
			Condition = data.Get("condition").As<Variant>(),
			CreatedAt = data.Get("created_at").AsString(),
			Transport = data.Get("transport").As<TwitchTransport>(),
			Cost = data.Get("cost").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_sub_subscription.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("status", Status);
		request.Set("type", Type);
		request.Set("version", Version);
		request.Set("condition", Condition);
		request.Set("created_at", CreatedAt);
		request.Set("transport", Transport);
		request.Set("cost", Cost);
		return request;
	}
}
