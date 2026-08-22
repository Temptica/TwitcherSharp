using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchExtensionAnalytics : RefCounted, ITwitcherSharp<TwitchExtensionAnalytics>
{
    private GodotObject? _data;
    public string ExtensionId { get; set; } = null!;
    public string URL { get; set; } = null!;
    public string Type { get; set; } = null!;
    public TwitchResponseDateRange DateRange { get => field ??= _data?.Get<TwitchResponseDateRange>("date_range")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionAnalytics object.
    /// </summary> 
    public static TwitchExtensionAnalytics? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionAnalytics
        {
            ExtensionId = data.Get("extension_id").AsString(),
            URL = data.Get("url").AsString(),
            Type = data.Get("type").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_analytics.gd");
        var request = script.Call("new").AsGodotObject();
        if(ExtensionId != null) request.Set("extension_id", ExtensionId);
        if(URL != null) request.Set("url", URL);
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
        public string StartedAt { get; set; } = null!;
        public string EndedAt { get; set; } = null!;
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_analytics.gd");
            var twitchResponseDateRangeClass = script.Get("DateRange").AsGodotObject();
            var request = twitchResponseDateRangeClass.Call("new").AsGodotObject();
            if(StartedAt != null) request.Set("started_at", StartedAt);
            if(EndedAt != null) request.Set("ended_at", EndedAt);
            return request;
        }
    
    }

}
