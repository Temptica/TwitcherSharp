using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChoices : Resource, ITwitcherSharpEventSub<TwitchChoices>
{

	/// <summary> 
	/// ID for the choice.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// Text displayed for the choice.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// Not used; will be set to 0.
	/// </summary>
	public int BitsVotes { get; set; }

	/// <summary> 
	/// Number of votes received via Channel Points.
	/// </summary>
	public int ChannelPointsVotes { get; set; }

	/// <summary> 
	/// Total number of votes received for the choice across all methods of voting.
	/// </summary>
	public int Votes { get; set; }

	public static TwitchChoices FromData(Dictionary data)
	{
	    return new TwitchChoices
	    {
			Id = data["id"].AsString(),
			Title = data["title"].AsString(),
			BitsVotes = data["bits_votes"].AsInt32(),
			ChannelPointsVotes = data["channel_points_votes"].AsInt32(),
			Votes = data["votes"].AsInt32(),
		};
	}

}
