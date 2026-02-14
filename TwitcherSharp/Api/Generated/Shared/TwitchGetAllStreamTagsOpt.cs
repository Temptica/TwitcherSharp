using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetAllStreamTags 
/// </summary>
public partial class TwitchGetAllStreamTagsOpt : Resource, ITwitcherSharp<TwitchGetAllStreamTagsOpt>
{
    private GodotObject _data;
	public string[] TagId { get; set; }
	public int? First { get; set; }
	public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsOpt object.
    /// </summary> 
    public static TwitchGetAllStreamTagsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetAllStreamTagsOpt
		{
			TagId = data.Get("tag_id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(TagId != null) request.Set("tag_id", TagId);
		if(First.HasValue) request.Set("first", First.Value);
		if(After != null) request.Set("after", After);
		return request;
	}
}
