using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The most recent contribution towards the Hype Train’s goal. 
/// </summary>
public partial class LastContribution : Resource, ITwitcherSharp<LastContribution>
{
    private GodotObject _data;
	public int Total { get; set; }
	public string Type { get; set; }
	public string User { get; set; }
    /// <summary> 
    /// Transforms the godot data into a LastContribution object.
    /// </summary> 
    public static LastContribution FromObject(GodotObject data)
    {
        return new LastContribution
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
