using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchCreateExtensionSecretResponse : RefCounted, ITwitcherSharp<TwitchCreateExtensionSecretResponse>
{
    private GodotObject? _data;
    public TwitchExtensionSecret[]? Data { get => field ??= _data?.GetArray<TwitchExtensionSecret>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretResponse object.
    /// </summary> 
    public static TwitchCreateExtensionSecretResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateExtensionSecretResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
