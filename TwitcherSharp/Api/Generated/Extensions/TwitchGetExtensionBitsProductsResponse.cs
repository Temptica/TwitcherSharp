using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionBitsProductsResponse : Resource, ITwitcherSharp<TwitchGetExtensionBitsProductsResponse>
{
    private GodotObject _data;
    public TwitchExtensionBitsProduct[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionBitsProductsResponse object.
    /// </summary> 
    public static TwitchGetExtensionBitsProductsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetExtensionBitsProductsResponse
        {
            Data = dataArray.Select(TwitchExtensionBitsProduct.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_bits_products.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }

}
