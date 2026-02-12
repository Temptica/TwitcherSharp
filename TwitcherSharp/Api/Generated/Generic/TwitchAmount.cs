using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// An object that contains the amount of money that the user donated. 
/// </summary>
public partial class TwitchAmount : Resource, ITwitcherSharp<TwitchAmount>
{
    private GodotObject _data;
	public int Value { get; set; }
	public int DecimalPlaces { get; set; }
	public string Currency { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAmount object.
    /// </summary> 
    public static TwitchAmount FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchAmount
		{
			Value = data.Get("value").AsInt32(),
			DecimalPlaces = data.Get("decimal_places").AsInt32(),
			Currency = data.Get("currency").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_amount.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("value", Value);
		request.Set("decimal_places", DecimalPlaces);
		request.Set("currency", Currency);
		return request;
	}
}
