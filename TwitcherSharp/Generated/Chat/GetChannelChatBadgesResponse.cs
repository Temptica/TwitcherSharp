using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelChatBadgesResponse : Resource, ITwitcherSharp<GetChannelChatBadgesResponse>
{
    private GodotObject _data;
	public ChatBadge[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelChatBadgesResponse object.
    /// </summary> 
    public static GetChannelChatBadgesResponse FromObject(GodotObject data)
    {
        return new GetChannelChatBadgesResponse
        {

			Data = data.Get("data").As<ChatBadge[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_chat_badges_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
