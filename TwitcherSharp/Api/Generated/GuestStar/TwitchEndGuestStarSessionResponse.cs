using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchEndGuestStarSessionResponse : RefCounted, ITwitcherSharp<TwitchEndGuestStarSessionResponse>
{
    private GodotObject _data;
    public TwitchGuestStarSession[] Data { get => field ??= _data?.GetArray<TwitchGuestStarSession>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndGuestStarSessionResponse object.
    /// </summary> 
    public static TwitchEndGuestStarSessionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchEndGuestStarSessionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_guest_star_session.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

}
