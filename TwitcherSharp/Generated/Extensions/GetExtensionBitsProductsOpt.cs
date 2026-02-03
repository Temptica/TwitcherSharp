using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionBitsProducts 
/// </summary>
public partial class GetExtensionBitsProductsOpt : Resource, ITwitcherSharp<GetExtensionBitsProductsOpt>
{
    private GodotObject _data;
	public bool ShouldIncludeAll { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionBitsProductsOpt object.
    /// </summary> 
    public static GetExtensionBitsProductsOpt FromObject(GodotObject data)
    {
        return new GetExtensionBitsProductsOpt
        {

			ShouldIncludeAll = data.Get("should_include_all").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_bits_products_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("should_include_all", ShouldIncludeAll);
		return request;
	}
}
