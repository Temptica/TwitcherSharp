using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUsers 
/// </summary>
public partial class TwitchGetUsersOpt : RefCounted, ITwitcherSharp<TwitchGetUsersOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string[]? Login { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUsersOpt object.
    /// </summary> 
    public static TwitchGetUsersOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUsersOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            Login = data.Read("login", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_users.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(Login != null) request.SetValue("login", new Godot.Collections.Array<string>(Login));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
