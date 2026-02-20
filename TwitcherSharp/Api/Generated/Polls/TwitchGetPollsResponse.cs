using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchGetPollsResponse : Resource, ITwitcherSharp<TwitchGetPollsResponse>
{
    private GodotObject _data;
	public TwitchPoll[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPollsResponse object.
    /// </summary> 
    public static TwitchGetPollsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetPollsResponse
		{
			Data = dataArray.Select(TwitchPoll.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_polls.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}

}
