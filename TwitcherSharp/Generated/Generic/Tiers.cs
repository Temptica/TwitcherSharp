using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list of tier levels that the Cheermote supports. Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level. 
/// </summary>
public partial class Tiers : Resource, ITwitcherSharp<Tiers>
{
    private GodotObject _data;
	public int MinBits { get; set; }
	public string Id { get; set; }
	public string Color { get; set; }
	public Images Images { get; set; }
	public bool CanCheer { get; set; }
	public bool ShowInBitsCard { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Tiers object.
    /// </summary> 
    public static Tiers FromObject(GodotObject data)
    {
        return new Tiers
        {

			MinBits = data.Get("min_bits").AsInt32(),
			Id = data.Get("id").AsString(),
			Color = data.Get("color").AsString(),
			Images = data.Get("images").As<Images>(),
			CanCheer = data.Get("can_cheer").AsBool(),
			ShowInBitsCard = data.Get("show_in_bits_card").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_tiers.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("min_bits", MinBits);
		request.Set("id", Id);
		request.Set("color", Color);
		request.Set("images", Images);
		request.Set("can_cheer", CanCheer);
		request.Set("show_in_bits_card", ShowInBitsCard);
		return request;
	}
}
