using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPointsVoting : Resource, ITwitcherSharpEventSub<TwitchChannelPointsVoting>
{

	/// <summary> 
	/// Indicates if Channel Points can be used for voting.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// Number of Channel Points required to vote once with Channel Points.
	/// </summary>
	public int AmountPerVote { get; set; }

	public static TwitchChannelPointsVoting FromData(Dictionary data)
	{
	    return new TwitchChannelPointsVoting
	    {
			IsEnabled = data["is_enabled"].AsBool(),
			AmountPerVote = data["amount_per_vote"].AsInt32(),
		};
	}

}
