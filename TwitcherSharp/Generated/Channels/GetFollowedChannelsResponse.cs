using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class GetFollowedChannelsResponse : Resource, ITwitcherSharp<GetFollowedChannelsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public Pagination Pagination { get; set; }
	public int Total { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetFollowedChannelsResponse object.
    /// </summary> 
    public static GetFollowedChannelsResponse FromObject(GodotObject data)
    {
        return new GetFollowedChannelsResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		request.Set("total", Total);
		return request;
	}
}
