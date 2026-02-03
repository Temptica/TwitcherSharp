using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateExtensionBitsProductBody : Resource, ITwitcherSharp<UpdateExtensionBitsProductBody>
{
    private GodotObject _data;
	public string Sku { get; set; }
	public Cost Cost { get; set; }
	public string DisplayName { get; set; }
	public bool InDevelopment { get; set; }
	public string Expiration { get; set; }
	public bool IsBroadcast { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateExtensionBitsProductBody object.
    /// </summary> 
    public static UpdateExtensionBitsProductBody FromObject(GodotObject data)
    {
        return new UpdateExtensionBitsProductBody
        {

			Sku = data.Get("sku").AsString(),
			Cost = data.Get("cost").As<Cost>(),
			DisplayName = data.Get("display_name").AsString(),
			InDevelopment = data.Get("in_development").AsBool(),
			Expiration = data.Get("expiration").AsString(),
			IsBroadcast = data.Get("is_broadcast").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("sku", Sku);
		request.Set("cost", Cost);
		request.Set("display_name", DisplayName);
		request.Set("in_development", InDevelopment);
		request.Set("expiration", Expiration);
		request.Set("is_broadcast", IsBroadcast);
		return request;
	}
}
