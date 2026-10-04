using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateUser 
/// </summary>
public partial class TwitchUpdateUserOpt : RefCounted, ITwitcherSharp<TwitchUpdateUserOpt>
{
    private Variant _data;
    public string? Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserOpt object.
    /// </summary> 
    public static TwitchUpdateUserOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateUserOpt
        {
            Description = data.Read("description", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_user.gd", "Opt");
        if(Description != null) request.SetValue("description", Description);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
