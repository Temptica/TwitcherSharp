using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;


/// <summary> 
/// All optional parameters for TwitchAPI.GetModeratedChannels 
/// </summary>
public partial class TwitchGetModeratedChannelsOpt : RefCounted, ITwitcherSharp<TwitchGetModeratedChannelsOpt>
{
    private Variant _data;
    public string? After { get; set; }
    public int? First { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratedChannelsOpt object.
    /// </summary> 
    public static TwitchGetModeratedChannelsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetModeratedChannelsOpt
        {
            After = data.Read("after", static v => v.AsString()),
            First = data.Read("first", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_moderated_channels.gd", "Opt");
        if(After != null) request.SetValue("after", After);
        if(First.HasValue) request.SetValue("first", First.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
