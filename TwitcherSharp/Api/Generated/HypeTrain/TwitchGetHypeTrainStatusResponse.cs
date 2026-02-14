using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetHypeTrainStatusResponse : Resource, ITwitcherSharp<TwitchGetHypeTrainStatusResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchAllTimeHigh AllTimeHigh { get; set; }
	public TwitchSharedAllTimeHigh SharedAllTimeHigh { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainStatusResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetHypeTrainStatusResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			AllTimeHigh = data.Get("all_time_high").As<TwitchAllTimeHigh>(),
			SharedAllTimeHigh = data.Get("shared_all_time_high").As<TwitchSharedAllTimeHigh>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("all_time_high", AllTimeHigh);
		request.Set("shared_all_time_high", SharedAllTimeHigh);
		return request;
	}
}
