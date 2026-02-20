using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;


/// <summary> 
/// All optional parameters for TwitchAPI.GetFollowedStreams 
/// </summary>
public partial class TwitchGetFollowedStreamsOpt : Resource, ITwitcherSharp<TwitchGetFollowedStreamsOpt>
{
    private GodotObject _data;
	public int? First { get; set; }
	public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedStreamsOpt object.
    /// </summary> 
    public static TwitchGetFollowedStreamsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetFollowedStreamsOpt
		{
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_streams.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(First.HasValue) request.Set("first", First.Value);
		if(After != null) request.Set("after", After);
		return request;
	}

}
