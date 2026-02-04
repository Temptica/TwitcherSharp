using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetFollowedStreamsResponse : Resource, ITwitcherSharp<TwitchGetFollowedStreamsResponse>
{
    private GodotObject _data;
	public TwitchStream[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedStreamsResponse object.
    /// </summary> 
    public static TwitchGetFollowedStreamsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetFollowedStreamsResponse
		{
			Data = dataArray.Select(TwitchStream.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_streams.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
