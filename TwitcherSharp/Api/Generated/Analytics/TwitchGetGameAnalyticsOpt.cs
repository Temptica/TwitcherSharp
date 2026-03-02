using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;


/// <summary> 
/// All optional parameters for TwitchAPI.GetGameAnalytics 
/// </summary>
public partial class TwitchGetGameAnalyticsOpt : Resource, ITwitcherSharp<TwitchGetGameAnalyticsOpt>
{
    private GodotObject _data;
    public string GameId { get; set; }
    public string Type { get; set; }
    public string StartedAt { get; set; }
    public string EndedAt { get; set; }
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGameAnalyticsOpt object.
    /// </summary> 
    public static TwitchGetGameAnalyticsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetGameAnalyticsOpt
        {
            GameId = data.Get("game_id").AsString(),
            Type = data.Get("type").AsString(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_game_analytics.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(GameId != null) request.Set("game_id", GameId);
        if(Type != null) request.Set("type", Type);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        if(EndedAt != null) request.Set("ended_at", EndedAt);
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
