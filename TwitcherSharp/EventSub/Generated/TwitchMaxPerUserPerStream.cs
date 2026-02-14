using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchMaxPerUserPerStream : Resource, ITwitcherSharpEventSub<TwitchMaxPerUserPerStream>
{

	/// <summary> 
	/// Is the setting enabled.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// The max per user per stream limit.
	/// </summary>
	public int Value { get; set; }

	public static TwitchMaxPerUserPerStream FromData(Dictionary data)
	{
	    return new TwitchMaxPerUserPerStream
	    {
			IsEnabled = data["is_enabled"].AsBool(),
			Value = data["value"].AsInt32(),
		};
	}

}
