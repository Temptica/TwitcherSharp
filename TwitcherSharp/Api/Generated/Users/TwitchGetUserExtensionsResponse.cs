using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUserExtensionsResponse : RefCounted, ITwitcherSharp<TwitchGetUserExtensionsResponse>
{
    private Variant _data;
    public TwitchUserExtension[] Data { get => field ??= _data.GetArray<TwitchUserExtension>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserExtensionsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserExtensionsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_extensions.gd", "Response");
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
