using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ManageHeldAutoModMessagesBody : Resource, ITwitcherSharp<ManageHeldAutoModMessagesBody>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string MsgId { get; set; }
	public string Action { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ManageHeldAutoModMessagesBody object.
    /// </summary> 
    public static ManageHeldAutoModMessagesBody FromObject(GodotObject data)
    {
        return new ManageHeldAutoModMessagesBody
        {

			UserId = data.Get("user_id").AsString(),
			MsgId = data.Get("msg_id").AsString(),
			Action = data.Get("action").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_manage_held_auto_mod_messages_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("msg_id", MsgId);
		request.Set("action", Action);
		return request;
	}
}
