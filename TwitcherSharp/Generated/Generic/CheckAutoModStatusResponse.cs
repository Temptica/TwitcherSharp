using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class CheckAutoModStatusResponse : Resource, ITwitcherSharp<CheckAutoModStatusResponse>
{
    private GodotObject _data;
	public AutoModStatus[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CheckAutoModStatusResponse object.
    /// </summary> 
    public static CheckAutoModStatusResponse FromObject(GodotObject data)
    {
        return new CheckAutoModStatusResponse
        {

			Data = data.Get("data").As<AutoModStatus[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_auto_mod_status_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
