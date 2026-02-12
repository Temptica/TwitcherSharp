using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetFollowedChannelsResponse : Resource, ITwitcherSharp<TwitchGetFollowedChannelsResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedChannelsResponse object.
    /// </summary> 
    public static TwitchGetFollowedChannelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetFollowedChannelsResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		request.Set("total", Total);
		return request;
	}
}
