using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchPredictionOutcome : Resource, ITwitcherSharp<TwitchPredictionOutcome>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Title { get; set; }
	public int Users { get; set; }
	public int ChannelPoints { get; set; }
	public TwitchTopPredictors[] TopPredictors { get; set; }
	public string Color { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchPredictionOutcome object.
    /// </summary> 
    public static TwitchPredictionOutcome FromObject(GodotObject data)
    {
		var topPredictorsArray = data.Get("top_predictors").AsGodotArray<GodotObject>();
		return new TwitchPredictionOutcome
		{
			Id = data.Get("id").AsString(),
			Title = data.Get("title").AsString(),
			Users = data.Get("users").AsInt32(),
			ChannelPoints = data.Get("channel_points").AsInt32(),
			TopPredictors = topPredictorsArray.Select(TwitchTopPredictors.FromObject).ToArray(),
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
