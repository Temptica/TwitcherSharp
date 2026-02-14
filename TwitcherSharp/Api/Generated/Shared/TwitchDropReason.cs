using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// The reason the message was dropped, if any. 
/// </summary>
public partial class TwitchDropReason : Resource, ITwitcherSharp<TwitchDropReason>
{
    private GodotObject _data;
	public string Code { get; set; }
	public string Message { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropReason object.
    /// </summary> 
    public static TwitchDropReason FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchDropReason
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
