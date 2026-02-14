using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchEmotes : Resource, ITwitcherSharpEventSub<TwitchEmotes>
{

	/// <summary> 
	/// The index of where the Emote starts in the text.
	/// </summary>
	public int Begin { get; set; }

	/// <summary> 
	/// The index of where the Emote ends in the text.
	/// </summary>
	public int End { get; set; }

	/// <summary> 
	/// The emote ID.
	/// </summary>
	public string Id { get; set; }

	public static TwitchEmotes FromData(Dictionary data)
	{
	    return new TwitchEmotes
	    {
			Begin = data["begin"].AsInt32(),
			End = data["end"].AsInt32(),
			Id = data["id"].AsString(),
		};
	}

}
