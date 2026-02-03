using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The contributors with the most points contributed. 
/// </summary>
public partial class TopContributions : Resource, ITwitcherSharp<TopContributions>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public string Type { get; set; }
	public int Total { get; set; }
	public SharedTrainParticipants[] SharedTrainParticipants { get; set; }
	public string StartedAt { get; set; }
	public string ExpiresAt { get; set; }
	public bool IsSharedTrain { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TopContributions object.
    /// </summary> 
    public static TopContributions FromObject(GodotObject data)
    {
        return new TopContributions
        {

			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			Type = data.Get("type").AsString(),
			Total = data.Get("total").AsInt32(),
			SharedTrainParticipants = data.Get("shared_train_participants").As<SharedTrainParticipants[]>(),
			StartedAt = data.Get("started_at").AsString(),
			ExpiresAt = data.Get("expires_at").AsString(),
			IsSharedTrain = data.Get("is_shared_train").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_top_contributions.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("type", Type);
		request.Set("total", Total);
		request.Set("shared_train_participants", SharedTrainParticipants);
		request.Set("started_at", StartedAt);
		request.Set("expires_at", ExpiresAt);
		request.Set("is_shared_train", IsSharedTrain);
		return request;
	}
}
