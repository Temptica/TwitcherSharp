using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchTopContributions : Resource, ITwitcherSharpEventSub<TwitchTopContributions>
{

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
	/// The contribution method used. Possible values are: bits — Cheering with Bits.subscription — Subscription activity like subscribing or gifting subscriptions.other — Covers other contribution methods not listed.
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
	/// </summary>
	public int Total { get; set; }

	public static TwitchTopContributions FromData(Dictionary data)
	{
	    return new TwitchTopContributions
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Type = data["type"].AsString(),
			Total = data["total"].AsInt32(),
		};
	}

}
