using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductResponse : RefCounted, ITwitcherSharp<TwitchUpdateExtensionBitsProductResponse>
{
    private Variant _data;
    public TwitchExtensionBitsProduct[] Data { get => field ??= _data.GetArray<TwitchExtensionBitsProduct>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductResponse object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateExtensionBitsProductResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd", "Response");
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
