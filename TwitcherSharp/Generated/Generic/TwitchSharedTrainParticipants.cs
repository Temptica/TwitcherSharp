using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared. 
/// </summary>
public partial class TwitchSharedTrainParticipants : Resource, ITwitcherSharp<TwitchSharedTrainParticipants>
{
    private GodotObject _data;
	public string BroadcasterUserId { get; set; }
	public string BroadcasterUserLogin { get; set; }
	public string BroadcasterUserName { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSharedTrainParticipants object.
    /// </summary> 
    public static TwitchSharedTrainParticipants FromObject(GodotObject data)
    {
		return new TwitchSharedTrainParticipants
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_shared_train_participants.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		return request;
	}
}
