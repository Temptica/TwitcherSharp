using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetUsersResponse : RefCounted, ITwitcherSharp<TwitchGetUsersResponse>
{
    private Variant _data;
    public TwitchUser[] Data { get => field ??= _data.GetArray<TwitchUser>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUsersResponse object.
    /// </summary> 
    public static TwitchGetUsersResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUsersResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_users.gd", "Response");
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
