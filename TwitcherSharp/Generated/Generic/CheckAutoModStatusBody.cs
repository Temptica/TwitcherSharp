using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class CheckAutoModStatusBody : Resource, ITwitcherSharp<CheckAutoModStatusBody>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CheckAutoModStatusBody object.
    /// </summary> 
    public static CheckAutoModStatusBody FromObject(GodotObject data)
    {
        return new CheckAutoModStatusBody
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
