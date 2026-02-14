using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchTopPredictors : Resource, ITwitcherSharpEventSub<TwitchTopPredictors>
{

	/// <summary> 
	/// The ID of the user.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the user.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The number of Channel Points won. This value is always null in the event payload for Prediction progress and Prediction lock. This value is 0 if the outcome did not win or if the Prediction was canceled and Channel Points were refunded.
	/// </summary>
	public int ChannelPointsWon { get; set; }

	/// <summary> 
	/// The number of Channel Points used to participate in the Prediction.
	/// </summary>
	public int ChannelPointsUsed { get; set; }

	public static TwitchTopPredictors FromData(Dictionary data)
	{
	    return new TwitchTopPredictors
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			ChannelPointsWon = data["channel_points_won"].AsInt32(),
			ChannelPointsUsed = data["channel_points_used"].AsInt32(),
		};
	}

}
