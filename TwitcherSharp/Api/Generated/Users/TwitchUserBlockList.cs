using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchUserBlockList : RefCounted, ITwitcherSharp<TwitchUserBlockList>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string DisplayName { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserBlockList object.
    /// </summary> 
    public static TwitchUserBlockList? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserBlockList
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            DisplayName = data.Read("display_name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_user_block_list.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(DisplayName != null) request.SetValue("display_name", DisplayName);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
