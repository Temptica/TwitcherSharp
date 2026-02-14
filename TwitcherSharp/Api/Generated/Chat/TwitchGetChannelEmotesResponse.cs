using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelEmotesResponse : Resource, ITwitcherSharp<TwitchGetChannelEmotesResponse>
{
    private GodotObject _data;
	public TwitchChannelEmote[] Data { get; set; }
	public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEmotesResponse object.
    /// </summary> 
    public static TwitchGetChannelEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetChannelEmotesResponse
		{
			Data = dataArray.Select(TwitchChannelEmote.FromObject).ToArray(),
			Template = data.Get("template").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_emotes.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("template", Template);
		return request;
	}
}
