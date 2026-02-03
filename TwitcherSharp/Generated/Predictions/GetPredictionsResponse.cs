using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class GetPredictionsResponse : Resource, ITwitcherSharp<GetPredictionsResponse>
{
    private GodotObject _data;
	public Prediction[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetPredictionsResponse object.
    /// </summary> 
    public static GetPredictionsResponse FromObject(GodotObject data)
    {
        return new GetPredictionsResponse
        {

			Data = data.Get("data").As<Prediction[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_predictions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
