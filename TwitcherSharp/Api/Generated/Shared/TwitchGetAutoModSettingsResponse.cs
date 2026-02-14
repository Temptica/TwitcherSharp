using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetAutoModSettingsResponse : Resource, ITwitcherSharp<TwitchGetAutoModSettingsResponse>
{
    private GodotObject _data;
	public TwitchAutoModSettings[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAutoModSettingsResponse object.
    /// </summary> 
    public static TwitchGetAutoModSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetAutoModSettingsResponse
		{
			Data = dataArray.Select(TwitchAutoModSettings.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_auto_mod_settings.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
