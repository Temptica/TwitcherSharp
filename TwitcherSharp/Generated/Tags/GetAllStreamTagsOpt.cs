using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Tags;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetAllStreamTags 
/// </summary>
public partial class GetAllStreamTagsOpt : Resource, ITwitcherSharp<GetAllStreamTagsOpt>
{
    private GodotObject _data;
	public string[] TagId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetAllStreamTagsOpt object.
    /// </summary> 
    public static GetAllStreamTagsOpt FromObject(GodotObject data)
    {
        return new GetAllStreamTagsOpt
        {

			TagId = data.Get("tag_id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("tag_id", TagId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
