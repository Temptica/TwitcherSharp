using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetHypeTrainEventsResponse : Resource, ITwitcherSharp<TwitchGetHypeTrainEventsResponse>
{
    private GodotObject _data;
	public TwitchHypeTrainEvent[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainEventsResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainEventsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetHypeTrainEventsResponse
		{
			Data = dataArray.Select(TwitchHypeTrainEvent.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_events.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
