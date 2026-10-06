using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;

public partial class TwitchExtensionAnalytics : RefCounted, ITwitcherSharp<TwitchExtensionAnalytics>
{
    private Variant _data;
    public string ExtensionId { get; set; } = null!;
    public string URL { get; set; } = null!;
    public string Type { get; set; } = null!;
    public TwitchResponseDateRange DateRange { get => field ??= _data.Get<TwitchResponseDateRange>("date_range")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionAnalytics object.
    /// </summary> 
    public static TwitchExtensionAnalytics? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionAnalytics
        {
            ExtensionId = data.Read("extension_id", static v => v.AsString()),
            URL = data.Read("URL", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_analytics.gd");
        if(ExtensionId != null) request.SetValue("extension_id", ExtensionId);
        if(URL != null) request.SetValue("URL", URL);
        if(Type != null) request.SetValue("type", Type);
        if(DateRange != null) request.SetObject("date_range", DateRange);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The reporting window’s start and end dates, in RFC3339 format. 
    /// </summary>
    public partial class TwitchResponseDateRange : RefCounted, ITwitcherSharp<TwitchResponseDateRange>
    {
        private Variant _data;
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
                StartedAt = data.Read("started_at", static v => v.AsString()),
                EndedAt = data.Read("ended_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension_analytics.gd", "DateRange");
            if(StartedAt != null) request.SetValue("started_at", StartedAt);
            if(EndedAt != null) request.SetValue("ended_at", EndedAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
