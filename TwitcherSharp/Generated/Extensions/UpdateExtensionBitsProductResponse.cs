using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateExtensionBitsProductResponse : Resource, ITwitcherSharp<UpdateExtensionBitsProductResponse>
{
    private GodotObject _data;
	public ExtensionBitsProduct[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateExtensionBitsProductResponse object.
    /// </summary> 
    public static UpdateExtensionBitsProductResponse FromObject(GodotObject data)
    {
        return new UpdateExtensionBitsProductResponse
        {

			Data = data.Get("data").As<ExtensionBitsProduct[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
