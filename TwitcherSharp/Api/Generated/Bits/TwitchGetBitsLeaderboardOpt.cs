using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetBitsLeaderboard 
/// </summary>
public partial class TwitchGetBitsLeaderboardOpt : RefCounted, ITwitcherSharp<TwitchGetBitsLeaderboardOpt>
{
    private Variant _data;
    public int? Count { get; set; }
    public string? Period { get; set; }
    public string? StartedAt { get; set; }
    public string? UserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBitsLeaderboardOpt object.
    /// </summary> 
    public static TwitchGetBitsLeaderboardOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetBitsLeaderboardOpt
        {
            Count = data.Read("count", static v => v.AsInt32()),
            Period = data.Read("period", static v => v.AsString()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd", "Opt");
        if(Count.HasValue) request.SetValue("count", Count.Value);
        if(Period != null) request.SetValue("period", Period);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(UserId != null) request.SetValue("user_id", UserId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
