using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelFollowersResponse : Resource, ITwitcherSharp<TwitchGetChannelFollowersResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelFollowersResponse object.
    /// </summary> 
    public static TwitchGetChannelFollowersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetChannelFollowersResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_followers.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		request.Set("total", Total);
		return request;
	}
}
