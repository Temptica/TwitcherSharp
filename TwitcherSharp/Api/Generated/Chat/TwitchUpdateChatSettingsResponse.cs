using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateChatSettingsResponse : Resource, ITwitcherSharp<TwitchUpdateChatSettingsResponse>
{
    private GodotObject _data;
	public TwitchChatSettingsUpdated[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChatSettingsResponse object.
    /// </summary> 
    public static TwitchUpdateChatSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchUpdateChatSettingsResponse
		{
			Data = dataArray.Select(TwitchChatSettingsUpdated.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_chat_settings.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
