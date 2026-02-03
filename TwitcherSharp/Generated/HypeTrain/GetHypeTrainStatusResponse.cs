using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.HypeTrain;
 
/// <summary> 
///  
/// </summary>
public partial class GetHypeTrainStatusResponse : Resource, ITwitcherSharp<GetHypeTrainStatusResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public AllTimeHigh AllTimeHigh { get; set; }
	public SharedAllTimeHigh SharedAllTimeHigh { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetHypeTrainStatusResponse object.
    /// </summary> 
    public static GetHypeTrainStatusResponse FromObject(GodotObject data)
    {
        return new GetHypeTrainStatusResponse
        {

			Data = data.Get("data").As<Data[]>(),
			AllTimeHigh = data.Get("all_time_high").As<AllTimeHigh>(),
			SharedAllTimeHigh = data.Get("shared_all_time_high").As<SharedAllTimeHigh>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("all_time_high", AllTimeHigh);
		request.Set("shared_all_time_high", SharedAllTimeHigh);
		return request;
	}
}
