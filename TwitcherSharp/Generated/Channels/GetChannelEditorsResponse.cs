using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelEditorsResponse : Resource, ITwitcherSharp<GetChannelEditorsResponse>
{
    private GodotObject _data;
	public ChannelEditor[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelEditorsResponse object.
    /// </summary> 
    public static GetChannelEditorsResponse FromObject(GodotObject data)
    {
        return new GetChannelEditorsResponse
        {

			Data = data.Get("data").As<ChannelEditor[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_editors_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
