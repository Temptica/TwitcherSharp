using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchEndGuestStarSessionResponse : RefCounted, ITwitcherSharp<TwitchEndGuestStarSessionResponse>
{
    private GodotObject _data;
    public TwitchGuestStarSession[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndGuestStarSessionResponse object.
    /// </summary> 
    public static TwitchEndGuestStarSessionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchEndGuestStarSessionResponse
        {
            Data = dataArray.Select(TwitchGuestStarSession.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_guest_star_session.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
