using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

/// <summary> 
/// All optional parameters for TwitchAPI.GetChatSettings 
/// </summary>
public partial class TwitchGetChatSettingsOpt : Resource, ITwitcherSharp<TwitchGetChatSettingsOpt>
{
    private GodotObject _data;
	public string ModeratorId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChatSettingsOpt object.
    /// </summary> 
    public static TwitchGetChatSettingsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetChatSettingsOpt
		{
			ModeratorId = data.Get("moderator_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chat_settings.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
		return request;
	}

}
