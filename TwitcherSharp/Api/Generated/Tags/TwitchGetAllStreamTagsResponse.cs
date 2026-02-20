using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchGetAllStreamTagsResponse : Resource, ITwitcherSharp<TwitchGetAllStreamTagsResponse>
{
    private GodotObject _data;
	public TwitchStreamTag[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetAllStreamTagsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetAllStreamTagsResponse
		{
			Data = dataArray.Select(TwitchStreamTag.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}

}
