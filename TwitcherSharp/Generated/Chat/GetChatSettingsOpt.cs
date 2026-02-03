using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetChatSettings 
/// </summary>
public partial class GetChatSettingsOpt : Resource, ITwitcherSharp<GetChatSettingsOpt>
{
    private GodotObject _data;
	public string ModeratorId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChatSettingsOpt object.
    /// </summary> 
    public static GetChatSettingsOpt FromObject(GodotObject data)
    {
        return new GetChatSettingsOpt
        {

			ModeratorId = data.Get("moderator_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chat_settings_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("moderator_id", ModeratorId);
		return request;
	}
}
