using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// The campaign’s fundraising goal. This field is **null** if the broadcaster has not defined a fundraising goal. 
/// </summary>
public partial class TwitchTargetAmount : Resource, ITwitcherSharp<TwitchTargetAmount>
{
    private GodotObject _data;
	public int Value { get; set; }
	public int DecimalPlaces { get; set; }
	public string Currency { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchTargetAmount object.
    /// </summary> 
    public static TwitchTargetAmount FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchTargetAmount
		{
			Value = data.Get("value").AsInt32(),
			DecimalPlaces = data.Get("decimal_places").AsInt32(),
			Currency = data.Get("currency").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_target_amount.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("value", Value);
		request.Set("decimal_places", DecimalPlaces);
		request.Set("currency", Currency);
		return request;
	}
}
