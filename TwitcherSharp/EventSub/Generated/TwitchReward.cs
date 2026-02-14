using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchReward : Resource, ITwitcherSharpEventSub<TwitchReward>
{

	/// <summary> 
	/// The reward identifier.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The reward name.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// The reward cost.
	/// </summary>
	public int Cost { get; set; }

	/// <summary> 
	/// The reward description.
	/// </summary>
	public string Prompt { get; set; }

	public static TwitchReward FromData(Dictionary data)
	{
	    return new TwitchReward
	    {
			Id = data["id"].AsString(),
			Title = data["title"].AsString(),
			Cost = data["cost"].AsInt32(),
			Prompt = data["prompt"].AsString(),
		};
	}

}
