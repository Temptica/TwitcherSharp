using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
///  
/// </summary>
public partial class CreateStreamMarkerResponse : Resource, ITwitcherSharp<CreateStreamMarkerResponse>
{
    private GodotObject _data;
	public StreamMarkerCreated[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateStreamMarkerResponse object.
    /// </summary> 
    public static CreateStreamMarkerResponse FromObject(GodotObject data)
    {
        return new CreateStreamMarkerResponse
        {

			Data = data.Get("data").As<StreamMarkerCreated[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_stream_marker_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
