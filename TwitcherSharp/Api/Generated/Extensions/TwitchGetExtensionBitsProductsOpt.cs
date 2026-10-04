using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionBitsProducts 
/// </summary>
public partial class TwitchGetExtensionBitsProductsOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionBitsProductsOpt>
{
    private Variant _data;
    public bool? ShouldIncludeAll { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionBitsProductsOpt object.
    /// </summary> 
    public static TwitchGetExtensionBitsProductsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionBitsProductsOpt
        {
            ShouldIncludeAll = data.Read("should_include_all", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_extension_bits_products.gd", "Opt");
        if(ShouldIncludeAll.HasValue) request.SetValue("should_include_all", ShouldIncludeAll.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
