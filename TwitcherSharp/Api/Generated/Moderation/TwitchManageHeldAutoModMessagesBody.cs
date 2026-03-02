using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchManageHeldAutoModMessagesBody : Resource, ITwitcherSharp<TwitchManageHeldAutoModMessagesBody>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string MsgId { get; set; }
    public string Action { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchManageHeldAutoModMessagesBody object.
    /// </summary> 
    public static TwitchManageHeldAutoModMessagesBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchManageHeldAutoModMessagesBody
        {
            UserId = data.Get("user_id").AsString(),
            MsgId = data.Get("msg_id").AsString(),
            Action = data.Get("action").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_manage_held_auto_mod_messages.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("msg_id", MsgId);
        request.Set("action", Action);
        return request;
    }

}
