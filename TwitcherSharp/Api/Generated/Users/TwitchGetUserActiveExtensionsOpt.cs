using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserActiveExtensions 
/// </summary>
public partial class TwitchGetUserActiveExtensionsOpt : RefCounted, ITwitcherSharp<TwitchGetUserActiveExtensionsOpt>
{
    private Variant _data;
    public string? UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsOpt object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserActiveExtensionsOpt
        {
            UserId = data.Read("user_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", UserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
