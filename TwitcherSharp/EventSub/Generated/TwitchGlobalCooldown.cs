using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchGlobalCooldown : Resource, ITwitcherSharpEventSub<TwitchGlobalCooldown>
{

	/// <summary> 
	/// Is the setting enabled.
	/// </summary>
	public bool IsEnabled { get; set; }

	/// <summary> 
	/// The cooldown in seconds.
	/// </summary>
	public int Seconds { get; set; }

	public static TwitchGlobalCooldown FromData(Dictionary data)
	{
	    return new TwitchGlobalCooldown
	    {
			IsEnabled = data["is_enabled"].AsBool(),
			Seconds = data["seconds"].AsInt32(),
		};
	}

}
