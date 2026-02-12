using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchHypeTrainProgressEvent : Resource, ITwitcherSharpEventSub<TwitchHypeTrainProgressEvent>
{

	/// <summary> 
	/// The Hype Train ID.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The requested broadcaster ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The requested broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The requested broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// Total points contributed to the Hype Train.
	/// </summary>
	public int Total { get; set; }

	/// <summary> 
	/// The number of points contributed to the Hype Train at the current level.
	/// </summary>
	public int Progress { get; set; }

	/// <summary> 
	/// The number of points required to reach the next level.
	/// </summary>
	public int Goal { get; set; }

	/// <summary> 
	/// The contributors with the most points contributed.
	/// </summary>
	public top_contributions TopContributions { get; set; }

	/// <summary> 
	/// The ID of the user that made the contribution.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user’s login name.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user’s display name.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The contribution method used. Possible values are: bits - Bits contributions with Cheering, Power-ups, and Extensions. subscription - Subscription activity like subscribing or gifting subscriptions. other - Covers other contribution methods not listed.
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
	/// </summary>
	public int Total { get; set; }

	/// <summary> 
	/// The current level of the Hype Train.
	/// </summary>
	public int Level { get; set; }

	/// <summary> 
	/// The ID of the broadcaster participating in the shared Hype Train.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster participating in the shared Hype Train.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the broadcaster participating in the shared Hype Train.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The time when the Hype Train started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
	/// </summary>
	public string ExpiresAt { get; set; }

	/// <summary> 
	/// The type of the Hype Train. Possible values are: treasure golden_kapparegular
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
	/// </summary>
	public bool IsSharedTrain { get; set; }

	public static TwitchHypeTrainProgressEvent FromData(Dictionary data)
	{
	    return new TwitchHypeTrainProgressEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Total = data["total"].AsInt32(),
			Progress = data["progress"].AsInt32(),
			Goal = data["goal"].AsInt32(),
			TopContributions = data["top_contributions"].As<top_contributions>(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Type = data["type"].AsString(),
			Total = data["total"].AsInt32(),
			Level = data["level"].AsInt32(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			StartedAt = data["started_at"].AsString(),
			ExpiresAt = data["expires_at"].AsString(),
			Type = data["type"].AsString(),
			IsSharedTrain = data["is_shared_train"].AsBool(),
		};
	}

}
