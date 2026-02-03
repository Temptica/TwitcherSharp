using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// An object describing the current Hype Train. Null if a Hype Train is not active. 
/// </summary>
public partial class Current : Resource, ITwitcherSharp<Current>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string BroadcasterUserId { get; set; }
	public string BroadcasterUserLogin { get; set; }
	public string BroadcasterUserName { get; set; }
	public int Level { get; set; }
	public int Total { get; set; }
	public int Progress { get; set; }
	public int Goal { get; set; }
	public TopContributions[] TopContributions { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Current object.
    /// </summary> 
    public static Current FromObject(GodotObject data)
    {
        return new Current
        {

			Id = data.Get("id").AsString(),
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
			Level = data.Get("level").AsInt32(),
			Total = data.Get("total").AsInt32(),
			Progress = data.Get("progress").AsInt32(),
			Goal = data.Get("goal").AsInt32(),
			TopContributions = data.Get("top_contributions").As<TopContributions[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_current.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		request.Set("level", Level);
		request.Set("total", Total);
		request.Set("progress", Progress);
		request.Set("goal", Goal);
		request.Set("top_contributions", TopContributions);
		return request;
	}
}
