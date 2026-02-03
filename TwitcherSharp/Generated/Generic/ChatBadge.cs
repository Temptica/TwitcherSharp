using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ChatBadge : Resource, ITwitcherSharp<ChatBadge>
{
    private GodotObject _data;
	public string SetId { get; set; }
	public Versions[] Versions { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ChatBadge object.
    /// </summary> 
    public static ChatBadge FromObject(GodotObject data)
    {
        return new ChatBadge
        {

			SetId = data.Get("set_id").AsString(),
			Versions = data.Get("versions").As<Versions[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chat_badge.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("set_id", SetId);
		request.Set("versions", Versions);
		return request;
	}
}
