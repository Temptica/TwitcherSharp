using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductResponse : RefCounted, ITwitcherSharp<TwitchUpdateExtensionBitsProductResponse>
{
    private GodotObject _data;
    public TwitchExtensionBitsProduct[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductResponse object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchUpdateExtensionBitsProductResponse
        {
            Data = dataArray.Select(TwitchExtensionBitsProduct.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
