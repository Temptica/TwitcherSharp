using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class GetStreamMarkersResponse : Resource, ITwitcherSharp<GetStreamMarkersResponse>
{
    private GodotObject _data;
	public StreamMarkers[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetStreamMarkersResponse object.
    /// </summary> 
    public static GetStreamMarkersResponse FromObject(GodotObject data)
    {
        return new GetStreamMarkersResponse
        {

			Data = data.Get("data").As<StreamMarkers[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_markers_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
