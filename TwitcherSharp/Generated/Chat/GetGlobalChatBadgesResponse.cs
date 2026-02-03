using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetGlobalChatBadgesResponse : Resource, ITwitcherSharp<GetGlobalChatBadgesResponse>
{
    private GodotObject _data;
	public ChatBadge[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGlobalChatBadgesResponse object.
    /// </summary> 
    public static GetGlobalChatBadgesResponse FromObject(GodotObject data)
    {
        return new GetGlobalChatBadgesResponse
        {

			Data = data.Get("data").As<ChatBadge[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_global_chat_badges_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
