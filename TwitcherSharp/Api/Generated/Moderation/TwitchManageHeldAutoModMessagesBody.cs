using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchManageHeldAutoModMessagesBody : RefCounted, ITwitcherSharp<TwitchManageHeldAutoModMessagesBody>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string MsgId { get; set; } = null!;
    public string Action { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchManageHeldAutoModMessagesBody object.
    /// </summary> 
    public static TwitchManageHeldAutoModMessagesBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchManageHeldAutoModMessagesBody
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            MsgId = data.Read("msg_id", static v => v.AsString()),
            Action = data.Read("action", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_manage_held_auto_mod_messages.gd", "Body");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(MsgId != null) request.SetValue("msg_id", MsgId);
        if(Action != null) request.SetValue("action", Action);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
