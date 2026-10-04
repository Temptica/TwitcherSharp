using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;


/// <summary> 
/// All optional parameters for TwitchAPI.GetVideos 
/// </summary>
public partial class TwitchGetVideosOpt : RefCounted, ITwitcherSharp<TwitchGetVideosOpt>
{
    private Variant _data;
    public string[]? Id { get; set; }
    public string? UserId { get; set; }
    public string? GameId { get; set; }
    public string? Language { get; set; }
    public string? Period { get; set; }
    public string? Sort { get; set; }
    public string? Type { get; set; }
    public string? First { get; set; }
    public string? After { get; set; }
    public string? Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetVideosOpt object.
    /// </summary> 
    public static TwitchGetVideosOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetVideosOpt
        {
            Id = data.Read("id", static v => v.AsStringArray()),
            UserId = data.Read("user_id", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            Language = data.Read("language", static v => v.AsString()),
            Period = data.Read("period", static v => v.AsString()),
            Sort = data.Read("sort", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            First = data.Read("first", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
            Before = data.Read("before", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_videos.gd", "Opt");
        if(Id != null) request.SetValue("id", new Godot.Collections.Array<string>(Id));
        if(UserId != null) request.SetValue("user_id", UserId);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Language != null) request.SetValue("language", Language);
        if(Period != null) request.SetValue("period", Period);
        if(Sort != null) request.SetValue("sort", Sort);
        if(Type != null) request.SetValue("type", Type);
        if(First != null) request.SetValue("first", First);
        if(After != null) request.SetValue("after", After);
        if(Before != null) request.SetValue("before", Before);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
