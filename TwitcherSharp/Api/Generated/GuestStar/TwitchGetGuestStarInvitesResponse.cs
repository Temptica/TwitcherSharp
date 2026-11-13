using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetGuestStarInvitesResponse : RefCounted, ITwitcherSharp<TwitchGetGuestStarInvitesResponse>
{
    private Variant _data;
    public TwitchGuestStarInvite[] Data { get => field ??= _data.GetArray<TwitchGuestStarInvite>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarInvitesResponse object.
    /// </summary> 
    public static TwitchGetGuestStarInvitesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGuestStarInvitesResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_guest_star_invites.gd", "Response");
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
