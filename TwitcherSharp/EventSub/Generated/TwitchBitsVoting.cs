using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchBitsVoting : Resource, ITwitcherSharpEventSub<TwitchBitsVoting>
{

	/// <summary> 
	/// Not used; will be set to false.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// Not used; will be set to 0.
	/// </summary>
	public int AmountPerVote { get; set; }

	public static TwitchBitsVoting FromData(Dictionary data)
	{
	    return new TwitchBitsVoting
	    {
			IsEnabled = data["is_enabled"].AsBool(),
			AmountPerVote = data["amount_per_vote"].AsInt32(),
		};
	}

}
