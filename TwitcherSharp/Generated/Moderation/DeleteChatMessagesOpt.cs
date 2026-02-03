using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.DeleteChatMessages 
/// </summary>
public partial class DeleteChatMessagesOpt : Resource, ITwitcherSharp<DeleteChatMessagesOpt>
{
    private GodotObject _data;
	public string MessageId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DeleteChatMessagesOpt object.
    /// </summary> 
    public static DeleteChatMessagesOpt FromObject(GodotObject data)
    {
        return new DeleteChatMessagesOpt
        {

			MessageId = data.Get("message_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_delete_chat_messages_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("message_id", MessageId);
		return request;
	}
}
