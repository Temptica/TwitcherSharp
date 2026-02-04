using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.HypeTrain;
 
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
		request.Set("pagination", Pagination);
		return request;
	}
}
