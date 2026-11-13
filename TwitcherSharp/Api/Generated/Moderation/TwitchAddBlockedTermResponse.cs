using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermResponse : RefCounted, ITwitcherSharp<TwitchAddBlockedTermResponse>
{
    private Variant _data;
    public TwitchBlockedTerm[] Data { get => field ??= _data.GetArray<TwitchBlockedTerm>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermResponse object.
    /// </summary> 
    public static TwitchAddBlockedTermResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAddBlockedTermResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_add_blocked_term.gd", "Response");
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
