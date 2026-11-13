using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetGuestStarSessionResponse : RefCounted, ITwitcherSharp<TwitchGetGuestStarSessionResponse>
{
    private Variant _data;
    public TwitchGuestStarSession[] Data { get => field ??= _data.GetArray<TwitchGuestStarSession>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarSessionResponse object.
    /// </summary> 
    public static TwitchGetGuestStarSessionResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGuestStarSessionResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_guest_star_session.gd", "Response");
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
