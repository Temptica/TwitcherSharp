using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The current amount of donations that the campaign has received. 
/// </summary>
public partial class TwitchCurrentAmount : Resource, ITwitcherSharp<TwitchCurrentAmount>
{
    private GodotObject _data;
	public int Value { get; set; }
	public int DecimalPlaces { get; set; }
	public string Currency { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCurrentAmount object.
    /// </summary> 
    public static TwitchCurrentAmount FromObject(GodotObject data)
    {
		return new TwitchCurrentAmount
		{
			Value = data.Get("value").AsInt32(),
			DecimalPlaces = data.Get("decimal_places").AsInt32(),
			Currency = data.Get("currency").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_current_amount.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("value", Value);
		request.Set("decimal_places", DecimalPlaces);
		request.Set("currency", Currency);
		return request;
	}
}
