using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class CreateConduitsResponse : Resource, ITwitcherSharp<CreateConduitsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateConduitsResponse object.
    /// </summary> 
    public static CreateConduitsResponse FromObject(GodotObject data)
    {
        return new CreateConduitsResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_conduits_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
