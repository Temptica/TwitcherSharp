using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;


/// <summary> 
/// All optional parameters for TwitchAPI.SearchChannels 
/// </summary>
public partial class TwitchSearchChannelsOpt : RefCounted, ITwitcherSharp<TwitchSearchChannelsOpt>
{
    private Variant _data;
    public bool? LiveOnly { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSearchChannelsOpt object.
    /// </summary> 
    public static TwitchSearchChannelsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSearchChannelsOpt
        {
            LiveOnly = data.Read("live_only", static v => v.AsBool()),
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_search_channels.gd", "Opt");
        if(LiveOnly.HasValue) request.SetValue("live_only", LiveOnly.Value);
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
