using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class PredictionOutcome : Resource, ITwitcherSharp<PredictionOutcome>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Title { get; set; }
	public int Users { get; set; }
	public int ChannelPoints { get; set; }
	public TopPredictors[] TopPredictors { get; set; }
	public string Color { get; set; }
    /// <summary> 
    /// Transforms the godot data into a PredictionOutcome object.
    /// </summary> 
    public static PredictionOutcome FromObject(GodotObject data)
    {
        return new PredictionOutcome
        {

			Id = data.Get("id").AsString(),
			Title = data.Get("title").AsString(),
			Users = data.Get("users").AsInt32(),
			ChannelPoints = data.Get("channel_points").AsInt32(),
			TopPredictors = data.Get("top_predictors").As<TopPredictors[]>(),
			Color = data.Get("color").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction_outcome.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("title", Title);
		request.Set("users", Users);
		request.Set("channel_points", ChannelPoints);
		request.Set("top_predictors", TopPredictors);
		request.Set("color", Color);
		return request;
	}
}
