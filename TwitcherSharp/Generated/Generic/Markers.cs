using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The list of markers in this video. The list in ascending order by when the marker was created. 
/// </summary>
public partial class Markers : Resource, ITwitcherSharp<Markers>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string CreatedAt { get; set; }
	public string Description { get; set; }
	public int PositionSeconds { get; set; }
	public string Url { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Markers object.
    /// </summary> 
    public static Markers FromObject(GodotObject data)
    {
        return new Markers
        {

			Id = data.Get("id").AsString(),
			CreatedAt = data.Get("created_at").AsString(),
			Description = data.Get("description").AsString(),
			PositionSeconds = data.Get("position_seconds").AsInt32(),
			Url = data.Get("url").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_markers.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("created_at", CreatedAt);
		request.Set("description", Description);
		request.Set("position_seconds", PositionSeconds);
		request.Set("url", Url);
		return request;
	}
}
