using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The most recent contribution towards the Hype Train’s goal. 
/// </summary>
public partial class TwitchLastContribution : Resource, ITwitcherSharp<TwitchLastContribution>
{
    private GodotObject _data;
	public int Total { get; set; }
	public string Type { get; set; }
	public string User { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchLastContribution object.
    /// </summary> 
    public static TwitchLastContribution FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchLastContribution
		{
			Total = data.Get("total").AsInt32(),
			Type = data.Get("type").AsString(),
			User = data.Get("user").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_last_contribution.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("total", Total);
		request.Set("type", Type);
		request.Set("user", User);
		return request;
	}
}
