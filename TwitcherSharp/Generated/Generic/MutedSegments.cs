using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The segments that Twitch Audio Recognition muted; otherwise, **null**. 
/// </summary>
public partial class MutedSegments : Resource, ITwitcherSharp<MutedSegments>
{
    private GodotObject _data;
	public int Duration { get; set; }
	public int Offset { get; set; }
    /// <summary> 
    /// Transforms the godot data into a MutedSegments object.
    /// </summary> 
    public static MutedSegments FromObject(GodotObject data)
    {
        return new MutedSegments
        {

			Duration = data.Get("duration").AsInt32(),
			Offset = data.Get("offset").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_muted_segments.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("duration", Duration);
		request.Set("offset", Offset);
		return request;
	}
}
