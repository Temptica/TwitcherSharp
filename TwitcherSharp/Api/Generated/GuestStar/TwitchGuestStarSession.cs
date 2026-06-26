using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuestStarSession : RefCounted, ITwitcherSharp<TwitchGuestStarSession>
{
    private GodotObject _data;
    public string Id { get; set; }
    public TwitchGuest[] Guests { get => field ??= _data?.GetArray<TwitchGuest>("guests"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuestStarSession object.
    /// </summary> 
    public static TwitchGuestStarSession FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGuestStarSession
        {
            Id = data.Get("id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest_star_session.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        if(Guests != null) request.Set("guests", Guests?.ToGodotArray());
        return request;
    }

}
