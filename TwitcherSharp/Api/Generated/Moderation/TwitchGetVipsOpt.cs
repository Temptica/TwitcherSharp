using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.GetVips 
/// </summary>
public partial class TwitchGetVipsOpt : RefCounted, ITwitcherSharp<TwitchGetVipsOpt>
{
    private Variant _data;
    public string[]? UserId { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetVipsOpt object.
    /// </summary> 
    public static TwitchGetVipsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetVipsOpt
        {
            UserId = data.Read("user_id", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_vips.gd", "Opt");
        if(UserId != null) request.SetValue("user_id", new Godot.Collections.Array<string>(UserId));
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
