using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetChatters 
/// </summary>
public partial class GetChattersOpt : Resource, ITwitcherSharp<GetChattersOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChattersOpt object.
    /// </summary> 
    public static GetChattersOpt FromObject(GodotObject data)
    {
        return new GetChattersOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
