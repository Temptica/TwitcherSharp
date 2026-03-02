using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionBitsProducts 
/// </summary>
public partial class TwitchGetExtensionBitsProductsOpt : Resource, ITwitcherSharp<TwitchGetExtensionBitsProductsOpt>
{
    private GodotObject _data;
    public bool? ShouldIncludeAll { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionBitsProductsOpt object.
    /// </summary> 
    public static TwitchGetExtensionBitsProductsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetExtensionBitsProductsOpt
        {
            ShouldIncludeAll = data.Get("should_include_all").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_bits_products.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(ShouldIncludeAll.HasValue) request.Set("should_include_all", ShouldIncludeAll.Value);
        return request;
    }

}
