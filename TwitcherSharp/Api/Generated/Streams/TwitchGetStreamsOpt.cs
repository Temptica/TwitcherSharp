using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetStreams 
/// </summary>
public partial class TwitchGetStreamsOpt : RefCounted, ITwitcherSharp<TwitchGetStreamsOpt>
{
    private GodotObject? _data;
    public string[]? UserId { get; set; }
    public string[]? UserLogin { get; set; }
    public string[]? GameId { get; set; }
    public string? Type { get; set; }
    public string[]? Language { get; set; }
    public int? First { get; set; }
    public string? Before { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamsOpt object.
    /// </summary> 
    public static TwitchGetStreamsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetStreamsOpt
        {
            UserId = data.Get("user_id").AsStringArray(),
            UserLogin = data.Get("user_login").AsStringArray(),
            GameId = data.Get("game_id").AsStringArray(),
            Type = data.Get("type").AsString(),
            Language = data.Get("language").AsStringArray(),
            First = data.Get("first").AsInt32(),
            Before = data.Get("before").AsString(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_streams.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", new Godot.Collections.Array<string>(UserId));
        if(UserLogin != null) request.Set("user_login", new Godot.Collections.Array<string>(UserLogin));
        if(GameId != null) request.Set("game_id", new Godot.Collections.Array<string>(GameId));
        if(Type != null) request.Set("type", Type);
        if(Language != null) request.Set("language", new Godot.Collections.Array<string>(Language));
        if(First.HasValue) request.Set("first", First.Value);
        if(Before != null) request.Set("before", Before);
        if(After != null) request.Set("after", After);
        return request;
    }

}
