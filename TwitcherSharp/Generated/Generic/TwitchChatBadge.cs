using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchChatBadge : Resource, ITwitcherSharp<TwitchChatBadge>
{
    private GodotObject _data;
	public string SetId { get; set; }
	public TwitchVersions[] Versions { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchChatBadge object.
    /// </summary> 
    public static TwitchChatBadge FromObject(GodotObject data)
    {
		var versionsArray = data.Get("versions").AsGodotArray<GodotObject>();
		return new TwitchChatBadge
		{
			SetId = data.Get("set_id").AsString(),
			Versions = versionsArray.Select(TwitchVersions.FromObject).ToArray(),
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
