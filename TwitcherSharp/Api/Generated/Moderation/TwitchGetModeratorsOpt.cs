using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

/// <summary> 
/// All optional parameters for TwitchAPI.GetModerators 
/// </summary>
public partial class TwitchGetModeratorsOpt : Resource, ITwitcherSharp<TwitchGetModeratorsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public string First { get; set; }
	public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratorsOpt object.
    /// </summary> 
    public static TwitchGetModeratorsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetModeratorsOpt
		{
			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderators.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(UserId != null) request.Set("user_id", UserId);
		if(First != null) request.Set("first", First);
		if(After != null) request.Set("after", After);
		return request;
	}

}
