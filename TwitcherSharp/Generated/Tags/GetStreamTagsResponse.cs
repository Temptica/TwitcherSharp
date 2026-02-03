using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Tags;
 
/// <summary> 
///  
/// </summary>
public partial class GetStreamTagsResponse : Resource, ITwitcherSharp<GetStreamTagsResponse>
{
    private GodotObject _data;
	public StreamTag[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetStreamTagsResponse object.
    /// </summary> 
    public static GetStreamTagsResponse FromObject(GodotObject data)
    {
        return new GetStreamTagsResponse
        {

			Data = data.Get("data").As<StreamTag[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_tags_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
