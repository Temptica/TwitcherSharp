using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.GetModerators 
/// </summary>
public partial class TwitchGetModeratorsOpt : RefCounted, ITwitcherSharp<TwitchGetModeratorsOpt>
{
    private Variant _data;
    public string[]? UserId { get; set; }
    public string? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratorsOpt object.
    /// </summary> 
    public static TwitchGetModeratorsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetModeratorsOpt
        {
            UserId = data.Read("user_id", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_moderators.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", new Godot.Collections.Array<string>(UserId));
        if(First != null) request.SetValue("first", First);
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
