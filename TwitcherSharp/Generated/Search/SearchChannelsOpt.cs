using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Search;
 
/// <summary> 
/// All optional parameters for TwitchAPI.SearchChannels 
/// </summary>
public partial class SearchChannelsOpt : Resource, ITwitcherSharp<SearchChannelsOpt>
{
    private GodotObject _data;
	public bool LiveOnly { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SearchChannelsOpt object.
    /// </summary> 
    public static SearchChannelsOpt FromObject(GodotObject data)
    {
        return new SearchChannelsOpt
        {

			LiveOnly = data.Get("live_only").AsBool(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_channels_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("live_only", LiveOnly);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
