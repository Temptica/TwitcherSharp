using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.HypeTrain;
 
/// <summary> 
///  
/// </summary>
public partial class GetHypeTrainEventsResponse : Resource, ITwitcherSharp<GetHypeTrainEventsResponse>
{
    private GodotObject _data;
	public HypeTrainEvent[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetHypeTrainEventsResponse object.
    /// </summary> 
    public static GetHypeTrainEventsResponse FromObject(GodotObject data)
    {
        return new GetHypeTrainEventsResponse
        {

			Data = data.Get("data").As<HypeTrainEvent[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_events_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
