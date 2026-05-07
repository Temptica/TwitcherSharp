using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductResponse : RefCounted, ITwitcherSharp<TwitchUpdateExtensionBitsProductResponse>
{
    private GodotObject _data;
    public TwitchExtensionBitsProduct[] Data { get => field ??= _data?.GetArray<TwitchExtensionBitsProduct>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductResponse object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateExtensionBitsProductResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
