using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelChatBadgesResponse : Resource, ITwitcherSharp<TwitchGetChannelChatBadgesResponse>
{
    private GodotObject _data;
	public TwitchChatBadge[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelChatBadgesResponse object.
    /// </summary> 
    public static TwitchGetChannelChatBadgesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetChannelChatBadgesResponse
		{
			Data = dataArray.Select(TwitchChatBadge.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_chat_badges.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
