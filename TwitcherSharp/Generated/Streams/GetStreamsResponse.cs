using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class GetStreamsResponse : Resource, ITwitcherSharp<GetStreamsResponse>
{
    private GodotObject _data;
	public TwitchStream[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetStreamsResponse object.
    /// </summary> 
    public static GetStreamsResponse FromObject(GodotObject data)
    {
        return new GetStreamsResponse
        {

			Data = data.Get("data").As<TwitchStream[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_streams_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
