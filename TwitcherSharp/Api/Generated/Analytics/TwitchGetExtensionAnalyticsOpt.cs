using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Analytics;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionAnalytics 
/// </summary>
public partial class TwitchGetExtensionAnalyticsOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionAnalyticsOpt>
{
    private Variant _data;
    public string? ExtensionId { get; set; }
    public string? Type { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionAnalyticsOpt object.
    /// </summary> 
    public static TwitchGetExtensionAnalyticsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionAnalyticsOpt
        {
            ExtensionId = data.ReadAsString("extension_id"),
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_extension_analytics.gd", "Opt");
        if(ExtensionId != null) request.SetValue("extension_id", ExtensionId);
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
