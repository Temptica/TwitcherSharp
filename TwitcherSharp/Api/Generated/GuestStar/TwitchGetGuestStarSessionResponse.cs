using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetGuestStarSessionResponse : RefCounted, ITwitcherSharp<TwitchGetGuestStarSessionResponse>
{
    private GodotObject _data;
    public TwitchGuestStarSession[] Data { get => field ??= _data?.GetArray<TwitchGuestStarSession>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarSessionResponse object.
    /// </summary> 
    public static TwitchGetGuestStarSessionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGuestStarSessionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_session.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
