using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Tags;
 
/// <summary> 
///  
/// </summary>
public partial class GetAllStreamTagsResponse : Resource, ITwitcherSharp<GetAllStreamTagsResponse>
{
    private GodotObject _data;
	public StreamTag[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetAllStreamTagsResponse object.
    /// </summary> 
    public static GetAllStreamTagsResponse FromObject(GodotObject data)
    {
        return new GetAllStreamTagsResponse
        {

			Data = data.Get("data").As<StreamTag[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
