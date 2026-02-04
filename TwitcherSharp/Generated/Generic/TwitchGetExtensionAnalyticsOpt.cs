using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionAnalytics 
/// </summary>
public partial class TwitchGetExtensionAnalyticsOpt : Resource, ITwitcherSharp<TwitchGetExtensionAnalyticsOpt>
{
    private GodotObject _data;
	public string ExtensionId { get; set; }
	public string Type { get; set; }
	public string StartedAt { get; set; }
	public string EndedAt { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionAnalyticsOpt object.
    /// </summary> 
    public static TwitchGetExtensionAnalyticsOpt FromObject(GodotObject data)
    {
		return new TwitchGetExtensionAnalyticsOpt
		{
			ExtensionId = data.Get("extension_id").AsString(),
			Type = data.Get("type").AsString(),
			StartedAt = data.Get("started_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_analytics.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("extension_id", ExtensionId);
		request.Set("type", Type);
		request.Set("started_at", StartedAt);
		request.Set("ended_at", EndedAt);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
