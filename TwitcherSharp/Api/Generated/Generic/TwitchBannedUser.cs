using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchBannedUser : Resource, ITwitcherSharp<TwitchBannedUser>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public string ExpiresAt { get; set; }
	public string CreatedAt { get; set; }
	public string Reason { get; set; }
	public string ModeratorId { get; set; }
	public string ModeratorLogin { get; set; }
	public string ModeratorName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBannedUser object.
    /// </summary> 
    public static TwitchBannedUser FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchBannedUser
		{
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			ExpiresAt = data.Get("expires_at").AsString(),
			CreatedAt = data.Get("created_at").AsString(),
			Reason = data.Get("reason").AsString(),
			ModeratorId = data.Get("moderator_id").AsString(),
			ModeratorLogin = data.Get("moderator_login").AsString(),
			ModeratorName = data.Get("moderator_name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_banned_user.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("expires_at", ExpiresAt);
		request.Set("created_at", CreatedAt);
		request.Set("reason", Reason);
		request.Set("moderator_id", ModeratorId);
		request.Set("moderator_login", ModeratorLogin);
		request.Set("moderator_name", ModeratorName);
		return request;
	}
}
