using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchExtensionAnalytics : Resource, ITwitcherSharp<TwitchExtensionAnalytics>
{
    private GodotObject _data;
	public string ExtensionId { get; set; }
	public string URL { get; set; }
	public string Type { get; set; }
	public TwitchDateRange DateRange { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionAnalytics object.
    /// </summary> 
    public static TwitchExtensionAnalytics FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchExtensionAnalytics
		{
			ExtensionId = data.Get("extension_id").AsString(),
			URL = data.Get("u_r_l").AsString(),
			Type = data.Get("type").AsString(),
			DateRange = data.Get("date_range").As<TwitchDateRange>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_analytics.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("extension_id", ExtensionId);
		request.Set("u_r_l", URL);
		request.Set("type", Type);
		request.Set("date_range", DateRange);
		return request;
	}
}
