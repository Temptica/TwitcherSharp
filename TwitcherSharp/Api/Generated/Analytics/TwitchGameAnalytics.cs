using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchGameAnalytics : RefCounted, ITwitcherSharp<TwitchGameAnalytics>
{
    private GodotObject _data;
    public string GameId { get; set; }
    public string URL { get; set; }
    public string Type { get; set; }
    public TwitchResponseDateRange DateRange { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGameAnalytics object.
    /// </summary> 
    public static TwitchGameAnalytics FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGameAnalytics
        {
            GameId = data.Get("game_id").AsString(),
            URL = data.Get("url").AsString(),
            Type = data.Get("type").AsString(),
            DateRange = data.Get("date_range").As<TwitchResponseDateRange>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("game_id", GameId);
        request.Set("url", URL);
        request.Set("type", Type);
        request.Set("date_range", DateRange?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The reporting window’s start and end dates, in RFC3339 format. 
    /// </summary>
    public partial class TwitchResponseDateRange : RefCounted, ITwitcherSharp<TwitchResponseDateRange>
    {
        private GodotObject _data;
        public string StartedAt { get; set; }
        public string EndedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseDateRange object.
        /// </summary> 
        public static TwitchResponseDateRange FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseDateRange
            {
                StartedAt = data.Get("started_at").AsString(),
                EndedAt = data.Get("ended_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
            var twitchResponseDateRangeClass = script.Get("DateRange").AsGodotObject();
            var request = twitchResponseDateRangeClass.Call("new").AsGodotObject();
            request.Set("started_at", StartedAt);
            request.Set("ended_at", EndedAt);
            return request;
        }
    
    }

}
