using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAutoModStatus : RefCounted, ITwitcherSharp<TwitchAutoModStatus>
{
    private Variant _data;
    public string MsgId { get; set; } = null!;
    public bool IsPermitted { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutoModStatus object.
    /// </summary> 
    public static TwitchAutoModStatus? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutoModStatus
        {
            MsgId = data.Read("msg_id", static v => v.AsString()),
            IsPermitted = data.Read("is_permitted", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_auto_mod_status.gd");
        if(MsgId != null) request.SetValue("msg_id", MsgId);
        request.SetValue("is_permitted", IsPermitted);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
