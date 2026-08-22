using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAutoModStatus : RefCounted, ITwitcherSharp<TwitchAutoModStatus>
{
    private GodotObject? _data;
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
            MsgId = data.Get("msg_id").AsString(),
            IsPermitted = data.Get("is_permitted").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_auto_mod_status.gd");
        var request = script.Call("new").AsGodotObject();
        if(MsgId != null) request.Set("msg_id", MsgId);
        request.Set("is_permitted", IsPermitted);
        return request;
    }

}
