using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelEmotesResponse : Resource, ITwitcherSharp<GetChannelEmotesResponse>
{
    private GodotObject _data;
	public ChannelEmote[] Data { get; set; }
	public string Template { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelEmotesResponse object.
    /// </summary> 
    public static GetChannelEmotesResponse FromObject(GodotObject data)
    {
        return new GetChannelEmotesResponse
        {

			Data = data.Get("data").As<ChannelEmote[]>(),
			Template = data.Get("template").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_emotes_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		return request;
	}
}
