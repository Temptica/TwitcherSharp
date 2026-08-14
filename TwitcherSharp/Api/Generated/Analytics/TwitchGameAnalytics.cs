using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchGameAnalytics : RefCounted, ITwitcherSharp<TwitchGameAnalytics>
{
    private GodotObject? _data;
    public string? GameId { get; set; }
    public string? Url { get; set; }
    public string? Type { get; set; }
    public TwitchResponseDateRange? DateRange { get => field ??= _data?.Get<TwitchResponseDateRange>("date_range"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGameAnalytics object.
    /// </summary> 
    public static TwitchGameAnalytics? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGameAnalytics
        {
            GameId = data.Get("game_id").AsString(),
            Url = data.Get("url").AsString(),
            Type = data.Get("type").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
        var request = script.Call("new").AsGodotObject();
        if(GameId != null) request.Set("game_id", GameId);
        if(Url != null) request.Set("url", Url);
        if(Type != null) request.Set("type", Type);
        if(DateRange != null) request.Set("date_range", DateRange.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The reporting window’s start and end dates, in RFC3339 format. 
    /// </summary>
    public partial class TwitchResponseDateRange : RefCounted, ITwitcherSharp<TwitchResponseDateRange>
    {
        private GodotObject? _data;
        public string? StartedAt { get; set; }
        public string? EndedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseDateRange object.
        /// </summary> 
        public static TwitchResponseDateRange? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseDateRange
            {
                StartedAt = data.Get("started_at").AsString(),
                EndedAt = data.Get("ended_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
            var twitchResponseDateRangeClass = script.Get("DateRange").AsGodotObject();
            var request = twitchResponseDateRangeClass.Call("new").AsGodotObject();
            if(StartedAt != null) request.Set("started_at", StartedAt);
            if(EndedAt != null) request.Set("ended_at", EndedAt);
            return request;
        }
    
    }

}
