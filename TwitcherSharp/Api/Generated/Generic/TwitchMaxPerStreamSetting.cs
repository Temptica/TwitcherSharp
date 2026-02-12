using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream. 
/// </summary>
public partial class TwitchMaxPerStreamSetting : Resource, ITwitcherSharp<TwitchMaxPerStreamSetting>
{
    private GodotObject _data;
	public bool IsEnabled { get; set; }
	public int MaxPerStream { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMaxPerStreamSetting object.
    /// </summary> 
    public static TwitchMaxPerStreamSetting FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchMaxPerStreamSetting
		{
			IsEnabled = data.Get("is_enabled").AsBool(),
			MaxPerStream = data.Get("max_per_stream").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_max_per_stream_setting.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_enabled", IsEnabled);
		request.Set("max_per_stream", MaxPerStream);
		return request;
	}
}
