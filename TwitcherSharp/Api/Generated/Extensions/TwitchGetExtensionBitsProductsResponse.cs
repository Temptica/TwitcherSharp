using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionBitsProductsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionBitsProductsResponse>
{
    private Variant _data;
    public TwitchExtensionBitsProduct[] Data { get => field ??= _data.GetArray<TwitchExtensionBitsProduct>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionBitsProductsResponse object.
    /// </summary> 
    public static TwitchGetExtensionBitsProductsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionBitsProductsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_extension_bits_products.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
