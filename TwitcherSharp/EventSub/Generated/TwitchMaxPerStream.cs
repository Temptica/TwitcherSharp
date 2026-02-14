using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchMaxPerStream : Resource, ITwitcherSharpEventSub<TwitchMaxPerStream>
{

	/// <summary> 
	/// Is the setting enabled.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// The max per stream limit.
	/// </summary>
	public int Value { get; set; }

	public static TwitchMaxPerStream FromData(Dictionary data)
	{
	    return new TwitchMaxPerStream
	    {
			IsEnabled = data["is_enabled"].AsBool(),
			Value = data["value"].AsInt32(),
		};
	}

}
