using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class CreateStreamMarkerBody : Resource, ITwitcherSharp<CreateStreamMarkerBody>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string Description { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateStreamMarkerBody object.
    /// </summary> 
    public static CreateStreamMarkerBody FromObject(GodotObject data)
    {
        return new CreateStreamMarkerBody
        {

			UserId = data.Get("user_id").AsString(),
			Description = data.Get("description").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_stream_marker_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("description", Description);
		return request;
	}
}
