using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchOutcomes : Resource, ITwitcherSharpEventSub<TwitchOutcomes>
{

	/// <summary> 
	/// The outcome ID.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The outcome title.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// The color for the outcome. Valid values are pink and blue.
	/// </summary>
	public string Color { get; set; }

	/// <summary> 
	/// The number of users who used Channel Points on this outcome.
	/// </summary>
	public int Users { get; set; }

	/// <summary> 
	/// The total number of Channel Points used on this outcome.
	/// </summary>
	public int ChannelPoints { get; set; }

	public static TwitchOutcomes FromData(Dictionary data)
	{
	    return new TwitchOutcomes
	    {
			Id = data["id"].AsString(),
			Title = data["title"].AsString(),
			Color = data["color"].AsString(),
			Users = data["users"].AsInt32(),
			ChannelPoints = data["channel_points"].AsInt32(),
		};
	}

}
