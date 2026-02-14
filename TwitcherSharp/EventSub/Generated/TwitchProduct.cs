using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchProduct : Resource, ITwitcherSharpEventSub<TwitchProduct>
{

	/// <summary> 
	/// Product name.
	/// </summary>
	public string Name { get; set; }

	/// <summary> 
	/// Bits involved in the transaction.
	/// </summary>
	public int Bits { get; set; }

	/// <summary> 
	/// Unique identifier for the product acquired.
	/// </summary>
	public string Sku { get; set; }

	/// <summary> 
	/// Flag indicating if the product is in development. If in_development is true, bits will be 0.
	/// </summary>
	public bool InDevelopment { get; set; }

	public static TwitchProduct FromData(Dictionary data)
	{
	    return new TwitchProduct
	    {
			Name = data["name"].AsString(),
			Bits = data["bits"].AsInt32(),
			Sku = data["sku"].AsString(),
			InDevelopment = data["in_development"].AsBool(),
		};
	}

}
