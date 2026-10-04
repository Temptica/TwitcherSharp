using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;


/// <summary> 
/// All optional parameters for TwitchAPI.GetClips 
/// </summary>
public partial class TwitchGetClipsOpt : RefCounted, ITwitcherSharp<TwitchGetClipsOpt>
{
    private Variant _data;
    public string? BroadcasterId { get; set; }
    public string? GameId { get; set; }
    public string[]? Id { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public int? First { get; set; }
    public string? Before { get; set; }
    public string? After { get; set; }
    public bool? IsFeatured { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsOpt object.
    /// </summary> 
    public static TwitchGetClipsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetClipsOpt
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsStringArray()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            EndedAt = data.Read("ended_at", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
            Before = data.Read("before", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            IsFeatured = data.Read("is_featured", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_clips.gd", "Opt");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        if(First.HasValue) request.SetValue("first", First.Value);
        if(Before != null) request.SetValue("before", Before);
        if(After != null) request.SetValue("after", After);
        if(IsFeatured.HasValue) request.SetValue("is_featured", IsFeatured.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
