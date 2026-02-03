using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The reason the message was dropped, if any. 
/// </summary>
public partial class DropReason : Resource, ITwitcherSharp<DropReason>
{
    private GodotObject _data;
	public string Code { get; set; }
	public string Message { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DropReason object.
    /// </summary> 
    public static DropReason FromObject(GodotObject data)
    {
        return new DropReason
        {

			Code = data.Get("code").AsString(),
			Message = data.Get("message").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drop_reason.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("code", Code);
		request.Set("message", Message);
		return request;
	}
}
