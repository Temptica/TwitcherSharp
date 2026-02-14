using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream. 
/// </summary>
public partial class TwitchMaxPerUserPerStreamSetting : Resource, ITwitcherSharp<TwitchMaxPerUserPerStreamSetting>
{
    private GodotObject _data;
	public bool IsEnabled { get; set; }
	public int MaxPerUserPerStream { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMaxPerUserPerStreamSetting object.
    /// </summary> 
    public static TwitchMaxPerUserPerStreamSetting FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchMaxPerUserPerStreamSetting
		{
			IsEnabled = data.Get("is_enabled").AsBool(),
			MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_max_per_user_per_stream_setting.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_enabled", IsEnabled);
		request.Set("max_per_user_per_stream", MaxPerUserPerStream);
		return request;
	}
}
