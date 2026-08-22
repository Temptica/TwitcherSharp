using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionSecretsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionSecretsResponse>
{
    private GodotObject? _data;
    public TwitchExtensionSecret[] Data { get => field ??= _data?.GetArray<TwitchExtensionSecret>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionSecretsResponse object.
    /// </summary> 
    public static TwitchGetExtensionSecretsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionSecretsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_secrets.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
