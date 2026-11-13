using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;


/// <summary> 
/// All optional parameters for TwitchAPI.GetGameAnalytics 
/// </summary>
public partial class TwitchGetGameAnalyticsOpt : RefCounted, ITwitcherSharp<TwitchGetGameAnalyticsOpt>
{
    private Variant _data;
    public string? GameId { get; set; }
    public string? Type { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGameAnalyticsOpt object.
    /// </summary> 
    public static TwitchGetGameAnalyticsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGameAnalyticsOpt
        {
            GameId = data.ReadAsString("game_id"),
            Type = data.ReadAsString("type"),
            StartedAt = data.ReadAsString("started_at"),
            EndedAt = data.ReadAsString("ended_at"),
            First = data.ReadAsInt32("first"),
            After = data.ReadAsString("after"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_game_analytics.gd", "Opt");
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Type != null) request.SetValue("type", Type);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        if(First.HasValue) request.SetValue("first", First.Value);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
