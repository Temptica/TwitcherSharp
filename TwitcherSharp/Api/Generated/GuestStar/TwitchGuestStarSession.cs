using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuestStarSession : RefCounted, ITwitcherSharp<TwitchGuestStarSession>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public TwitchGuest[] Guests { get => field ??= _data.GetArray<TwitchGuest>("guests")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGuestStarSession object.
    /// </summary> 
    public static TwitchGuestStarSession? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGuestStarSession
        {
            Id = data.Read("id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_guest_star_session.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Guests != null) request.SetArray("guests", Guests);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
