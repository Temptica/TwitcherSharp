using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateConduitsResponse : Resource, ITwitcherSharp<UpdateConduitsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateConduitsResponse object.
    /// </summary> 
    public static UpdateConduitsResponse FromObject(GodotObject data)
    {
        return new UpdateConduitsResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduits_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
