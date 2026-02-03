using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
///  
/// </summary>
public partial class CreateClipResponse : Resource, ITwitcherSharp<CreateClipResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateClipResponse object.
    /// </summary> 
    public static CreateClipResponse FromObject(GodotObject data)
    {
        return new CreateClipResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
