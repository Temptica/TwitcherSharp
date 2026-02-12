using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGuest : Resource, ITwitcherSharp<TwitchGuest>
{
    private GodotObject _data;
	public string SlotId { get; set; }
	public bool IsLive { get; set; }
	public string UserId { get; set; }
	public string UserDisplayName { get; set; }
	public string UserLogin { get; set; }
	public int Volume { get; set; }
	public string AssignedAt { get; set; }
	public TwitchAudioSettings AudioSettings { get; set; }
	public TwitchVideoSettings VideoSettings { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuest object.
    /// </summary> 
    public static TwitchGuest FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGuest
		{
			SlotId = data.Get("slot_id").AsString(),
			IsLive = data.Get("is_live").AsBool(),
			UserId = data.Get("user_id").AsString(),
			UserDisplayName = data.Get("user_display_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			Volume = data.Get("volume").AsInt32(),
			AssignedAt = data.Get("assigned_at").AsString(),
			AudioSettings = data.Get("audio_settings").As<TwitchAudioSettings>(),
			VideoSettings = data.Get("video_settings").As<TwitchVideoSettings>(),
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
