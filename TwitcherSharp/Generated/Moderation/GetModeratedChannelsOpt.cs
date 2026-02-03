using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetModeratedChannels 
/// </summary>
public partial class GetModeratedChannelsOpt : Resource, ITwitcherSharp<GetModeratedChannelsOpt>
{
    private GodotObject _data;
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetModeratedChannelsOpt object.
    /// </summary> 
    public static GetModeratedChannelsOpt FromObject(GodotObject data)
    {
        return new GetModeratedChannelsOpt
        {

			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderated_channels_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
