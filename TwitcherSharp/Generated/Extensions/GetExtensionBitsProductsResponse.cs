using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionBitsProductsResponse : Resource, ITwitcherSharp<GetExtensionBitsProductsResponse>
{
    private GodotObject _data;
	public ExtensionBitsProduct[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionBitsProductsResponse object.
    /// </summary> 
    public static GetExtensionBitsProductsResponse FromObject(GodotObject data)
    {
        return new GetExtensionBitsProductsResponse
        {

			Data = data.Get("data").As<ExtensionBitsProduct[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_bits_products_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
