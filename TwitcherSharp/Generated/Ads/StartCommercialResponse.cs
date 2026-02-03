using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Ads;
 
/// <summary> 
///  
/// </summary>
public partial class StartCommercialResponse : Resource, ITwitcherSharp<StartCommercialResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a StartCommercialResponse object.
    /// </summary> 
    public static StartCommercialResponse FromObject(GodotObject data)
    {
        return new StartCommercialResponse
        {

			Data = data.Get("data").As<Data[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
