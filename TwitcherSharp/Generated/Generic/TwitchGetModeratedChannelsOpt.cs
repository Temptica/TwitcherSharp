using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetModeratedChannels 
/// </summary>
public partial class TwitchGetModeratedChannelsOpt : Resource, ITwitcherSharp<TwitchGetModeratedChannelsOpt>
{
    private GodotObject _data;
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratedChannelsOpt object.
    /// </summary> 
    public static TwitchGetModeratedChannelsOpt FromObject(GodotObject data)
    {
		return new TwitchGetModeratedChannelsOpt
		{
			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderated_channels.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
