using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchHypeTrainBeginEvent : Resource, ITwitcherSharpEventSub<TwitchHypeTrainBeginEvent>
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
	/// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
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
	/// The top contributor for a contribution type. For example, the top contributor using BITS (by aggregate) or the top contributor using subscriptions (by count).
	/// </summary>
	public TwitchTopContributions TopContributions { get; set; }

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
	/// The type of the Hype Train. Possible values are: treasure golden_kapparegular
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The current level of the Hype Train.
	/// </summary>
	public int Level { get; set; }

	/// <summary> 
	/// The all-time high level this type of Hype Train has reached for this broadcaster.
	/// </summary>
	public int AllTimeHighLevel { get; set; }

	/// <summary> 
	/// The all-time high total this type of Hype Train has reached for this broadcaster.
	/// </summary>
	public int AllTimeHighTotal { get; set; }

	/// <summary> 
	/// Optional. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
	/// </summary>
	public TwitchSharedTrainParticipants[] SharedTrainParticipants { get; set; }

	/// <summary> 
	/// The time when the Hype Train started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
	/// </summary>
	public string ExpiresAt { get; set; }

	/// <summary> 
	/// Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
	/// </summary>
	public bool IsSharedTrain { get; set; }

	public static TwitchHypeTrainBeginEvent FromData(Dictionary data)
	{
	    return new TwitchHypeTrainBeginEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Total = data["total"].AsInt32(),
			Progress = data["progress"].AsInt32(),
			Goal = data["goal"].AsInt32(),
			TopContributions = TwitchTopContributions.FromData(data["top_contributions"].AsGodotDictionary()),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Type = data["type"].AsString(),
			Level = data["level"].AsInt32(),
			AllTimeHighLevel = data["all_time_high_level"].AsInt32(),
			AllTimeHighTotal = data["all_time_high_total"].AsInt32(),
			SharedTrainParticipants = data["shared_train_participants"].AsGodotArray().Select(x => TwitchSharedTrainParticipants.FromData(x.AsGodotDictionary())).ToArray(),
			StartedAt = data["started_at"].AsString(),
			ExpiresAt = data["expires_at"].AsString(),
			IsSharedTrain = data["is_shared_train"].AsBool(),
		};
	}

public partial class TwitchSharedTrainParticipants : Resource, ITwitcherSharpEventSub<TwitchSharedTrainParticipants>
{

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

	public static TwitchSharedTrainParticipants FromData(Dictionary data)
	{
	    return new TwitchSharedTrainParticipants
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
		};
	}

}

}
