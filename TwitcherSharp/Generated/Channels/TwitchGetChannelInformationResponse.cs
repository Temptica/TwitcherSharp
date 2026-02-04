using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelInformationResponse : Resource, ITwitcherSharp<TwitchGetChannelInformationResponse>
{
    private GodotObject _data;
	public TwitchChannelInformation[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelInformationResponse object.
    /// </summary> 
    public static TwitchGetChannelInformationResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetChannelInformationResponse
		{
			Data = dataArray.Select(TwitchChannelInformation.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_information.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
