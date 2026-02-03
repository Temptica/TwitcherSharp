using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateAutoModSettingsResponse : Resource, ITwitcherSharp<UpdateAutoModSettingsResponse>
{
    private GodotObject _data;
	public AutoModSettings[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateAutoModSettingsResponse object.
    /// </summary> 
    public static UpdateAutoModSettingsResponse FromObject(GodotObject data)
    {
        return new UpdateAutoModSettingsResponse
        {

			Data = data.Get("data").As<AutoModSettings[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_auto_mod_settings_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
