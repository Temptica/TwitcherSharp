using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Guest : Resource, ITwitcherSharp<Guest>
{
    private GodotObject _data;
	public string SlotId { get; set; }
	public bool IsLive { get; set; }
	public string UserId { get; set; }
	public string UserDisplayName { get; set; }
	public string UserLogin { get; set; }
	public int Volume { get; set; }
	public string AssignedAt { get; set; }
	public AudioSettings AudioSettings { get; set; }
	public VideoSettings VideoSettings { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Guest object.
    /// </summary> 
    public static Guest FromObject(GodotObject data)
    {
        return new Guest
        {

			SlotId = data.Get("slot_id").AsString(),
			IsLive = data.Get("is_live").AsBool(),
			UserId = data.Get("user_id").AsString(),
			UserDisplayName = data.Get("user_display_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			Volume = data.Get("volume").AsInt32(),
			AssignedAt = data.Get("assigned_at").AsString(),
			AudioSettings = data.Get("audio_settings").As<AudioSettings>(),
			VideoSettings = data.Get("video_settings").As<VideoSettings>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("slot_id", SlotId);
		request.Set("is_live", IsLive);
		request.Set("user_id", UserId);
		request.Set("user_display_name", UserDisplayName);
		request.Set("user_login", UserLogin);
		request.Set("volume", Volume);
		request.Set("assigned_at", AssignedAt);
		request.Set("audio_settings", AudioSettings);
		request.Set("video_settings", VideoSettings);
		return request;
	}
}
