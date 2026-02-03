using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Search;
 
/// <summary> 
///  
/// </summary>
public partial class SearchChannelsResponse : Resource, ITwitcherSharp<SearchChannelsResponse>
{
    private GodotObject _data;
	public Channel[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SearchChannelsResponse object.
    /// </summary> 
    public static SearchChannelsResponse FromObject(GodotObject data)
    {
        return new SearchChannelsResponse
        {

			Data = data.Get("data").As<Channel[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_channels_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
