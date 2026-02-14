using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// An object that contains the product's cost information. 
/// </summary>
public partial class TwitchCost : Resource, ITwitcherSharp<TwitchCost>
{
    private GodotObject _data;
	public int Amount { get; set; }
	public string Type { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCost object.
    /// </summary> 
    public static TwitchCost FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchCost
		{
			Amount = data.Get("amount").AsInt32(),
			Type = data.Get("type").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cost.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("amount", Amount);
		request.Set("type", Type);
		return request;
	}
}
