using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchCreateExtensionSecretResponse : RefCounted, ITwitcherSharp<TwitchCreateExtensionSecretResponse>
{
    private Variant _data;
    public TwitchExtensionSecret[] Data { get => field ??= _data.GetArray<TwitchExtensionSecret>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretResponse object.
    /// </summary> 
    public static TwitchCreateExtensionSecretResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateExtensionSecretResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_extension_secret.gd", "Response");
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
