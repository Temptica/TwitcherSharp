using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetGuestStarInvitesResponse : RefCounted, ITwitcherSharp<TwitchGetGuestStarInvitesResponse>
{
    private GodotObject _data;
    public TwitchGuestStarInvite[] Data { get => field ??= _data?.GetArray<TwitchGuestStarInvite>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarInvitesResponse object.
    /// </summary> 
    public static TwitchGetGuestStarInvitesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGuestStarInvitesResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_invites.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
