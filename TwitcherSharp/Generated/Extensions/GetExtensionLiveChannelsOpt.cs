using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionLiveChannels 
/// </summary>
public partial class GetExtensionLiveChannelsOpt : Resource, ITwitcherSharp<GetExtensionLiveChannelsOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionLiveChannelsOpt object.
    /// </summary> 
    public static GetExtensionLiveChannelsOpt FromObject(GodotObject data)
    {
        return new GetExtensionLiveChannelsOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
