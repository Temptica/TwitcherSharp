using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetStreams 
/// </summary>
public partial class TwitchGetStreamsOpt : RefCounted, ITwitcherSharp<TwitchGetStreamsOpt>
{
    private Variant _data;
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
            UserId = data.Read("user_id", static v => v.AsStringArray()),
            UserLogin = data.Read("user_login", static v => v.AsStringArray()),
            GameId = data.Read("game_id", static v => v.AsStringArray()),
            Type = data.Read("type", static v => v.AsString()),
            Language = data.Read("language", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsInt32()),
            Before = data.Read("before", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_streams.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", new Godot.Collections.Array<string>(UserId));
        if(UserLogin != null) request.SetValue("user_login", new Godot.Collections.Array<string>(UserLogin));
        if(GameId != null) request.SetValue("game_id", new Godot.Collections.Array<string>(GameId));
        if(Type != null) request.SetValue("type", Type);
        if(Language != null) request.SetValue("language", new Godot.Collections.Array<string>(Language));
        if(First.HasValue) request.SetValue("first", First.Value);
        if(Before != null) request.SetValue("before", Before);
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
