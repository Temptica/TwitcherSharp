using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.UpdateUser 
/// </summary>
public partial class TwitchUpdateUserOpt : RefCounted, ITwitcherSharp<TwitchUpdateUserOpt>
{
    private GodotObject _data;
    public string Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserOpt object.
    /// </summary> 
    public static TwitchUpdateUserOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateUserOpt
        {
            Description = data.Get("description").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Description != null) request.Set("description", Description);
        return request;
    }

}
