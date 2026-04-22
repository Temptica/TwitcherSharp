using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Videos;


/// <summary> 
/// All optional parameters for TwitchAPI.GetVideos 
/// </summary>
public partial class TwitchGetVideosOpt : RefCounted, ITwitcherSharp<TwitchGetVideosOpt>
{
    private GodotObject _data;
    public string[] Id { get; set; }
    public string UserId { get; set; }
    public string GameId { get; set; }
    public string Language { get; set; }
    public string Period { get; set; }
    public string Sort { get; set; }
    public string Type { get; set; }
    public string First { get; set; }
    public string After { get; set; }
    public string Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetVideosOpt object.
    /// </summary> 
    public static TwitchGetVideosOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetVideosOpt
        {
            Id = data.Get("id").AsStringArray(),
            UserId = data.Get("user_id").AsString(),
            GameId = data.Get("game_id").AsString(),
            Language = data.Get("language").AsString(),
            Period = data.Get("period").AsString(),
            Sort = data.Get("sort").AsString(),
            Type = data.Get("type").AsString(),
            First = data.Get("first").AsString(),
            After = data.Get("after").AsString(),
            Before = data.Get("before").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_videos.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", new Godot.Collections.Array<string>(Id));
        if(UserId != null) request.Set("user_id", UserId);
        if(GameId != null) request.Set("game_id", GameId);
        if(Language != null) request.Set("language", Language);
        if(Period != null) request.Set("period", Period);
        if(Sort != null) request.Set("sort", Sort);
        if(Type != null) request.Set("type", Type);
        if(First != null) request.Set("first", First);
        if(After != null) request.Set("after", After);
        if(Before != null) request.Set("before", Before);
        return request;
    }

}
