using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetStreams 
/// </summary>
public partial class TwitchGetStreamsOpt : Resource, ITwitcherSharp<TwitchGetStreamsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public string[] UserLogin { get; set; }
	public string[] GameId { get; set; }
	public string Type { get; set; }
	public string[] Language { get; set; }
	public int First { get; set; }
	public string Before { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamsOpt object.
    /// </summary> 
    public static TwitchGetStreamsOpt FromObject(GodotObject data)
    {
		return new TwitchGetStreamsOpt
		{
			UserId = data.Get("user_id").AsStringArray(),
			UserLogin = data.Get("user_login").AsStringArray(),
			GameId = data.Get("game_id").AsStringArray(),
			Type = data.Get("type").AsString(),
			Language = data.Get("language").AsStringArray(),
			First = data.Get("first").AsInt32(),
			Before = data.Get("before").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_streams.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("game_id", GameId);
		request.Set("type", Type);
		request.Set("language", Language);
		request.Set("first", First);
		request.Set("before", Before);
		request.Set("after", After);
		return request;
	}
}
