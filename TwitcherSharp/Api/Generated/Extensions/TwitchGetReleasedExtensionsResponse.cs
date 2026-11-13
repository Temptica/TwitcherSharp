using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetReleasedExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetReleasedExtensionsResponse>
{
    private Variant _data;
    public TwitchExtension[] Data { get => field ??= _data.GetArray<TwitchExtension>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsResponse object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetReleasedExtensionsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_released_extensions.gd", "Response");
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
