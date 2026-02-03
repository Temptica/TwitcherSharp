using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Analytics;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionAnalyticsResponse : Resource, ITwitcherSharp<GetExtensionAnalyticsResponse>
{
    private GodotObject _data;
	public ExtensionAnalytics[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionAnalyticsResponse object.
    /// </summary> 
    public static GetExtensionAnalyticsResponse FromObject(GodotObject data)
    {
        return new GetExtensionAnalyticsResponse
        {

			Data = data.Get("data").As<ExtensionAnalytics[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_analytics_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
