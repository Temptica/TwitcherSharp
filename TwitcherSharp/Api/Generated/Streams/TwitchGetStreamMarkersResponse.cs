using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetStreamMarkersResponse : Resource, ITwitcherSharp<TwitchGetStreamMarkersResponse>
{
    private GodotObject _data;
	public TwitchStreamMarkers[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamMarkersResponse object.
    /// </summary> 
    public static TwitchGetStreamMarkersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetStreamMarkersResponse
		{
			Data = dataArray.Select(TwitchStreamMarkers.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_markers.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
