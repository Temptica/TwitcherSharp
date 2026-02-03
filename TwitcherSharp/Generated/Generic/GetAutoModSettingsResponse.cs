using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GetAutoModSettingsResponse : Resource, ITwitcherSharp<GetAutoModSettingsResponse>
{
    private GodotObject _data;
	public AutoModSettings[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetAutoModSettingsResponse object.
    /// </summary> 
    public static GetAutoModSettingsResponse FromObject(GodotObject data)
    {
        return new GetAutoModSettingsResponse
        {

			Data = data.Get("data").As<AutoModSettings[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_auto_mod_settings_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
