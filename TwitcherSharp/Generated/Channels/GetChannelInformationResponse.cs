using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelInformationResponse : Resource, ITwitcherSharp<GetChannelInformationResponse>
{
    private GodotObject _data;
	public ChannelInformation[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelInformationResponse object.
    /// </summary> 
    public static GetChannelInformationResponse FromObject(GodotObject data)
    {
        return new GetChannelInformationResponse
        {

			Data = data.Get("data").As<ChannelInformation[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_information_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
