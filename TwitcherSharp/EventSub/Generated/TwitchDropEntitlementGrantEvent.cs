using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchDropEntitlementGrantEvent : Resource, ITwitcherSharpEventSub<TwitchDropEntitlementGrantEvent>
{

	/// <summary> 
	/// Individual event ID, as assigned by EventSub. Use this for de-duplicating messages.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// Entitlement object.
	/// </summary>
	public array Data { get; set; }

	public static TwitchDropEntitlementGrantEvent FromData(Dictionary data)
	{
	    return new TwitchDropEntitlementGrantEvent
	    {
			Id = data["id"].AsString(),
			Data = data["data"].As<array>(),
		};
	}

}
