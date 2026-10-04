using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.BlockUser 
/// </summary>
public partial class TwitchBlockUserOpt : RefCounted, ITwitcherSharp<TwitchBlockUserOpt>
{
    private Variant _data;
    public string? SourceContext { get; set; }
    public string? Reason { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBlockUserOpt object.
    /// </summary> 
    public static TwitchBlockUserOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBlockUserOpt
        {
            SourceContext = data.Read("source_context", static v => v.AsString()),
            Reason = data.Read("reason", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_block_user.gd", "Opt");
        if(SourceContext != null) request.SetValue("source_context", SourceContext);
        if(Reason != null) request.SetValue("reason", Reason);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
