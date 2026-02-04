using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Whispers;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSendWhisperBody : Resource, ITwitcherSharp<TwitchSendWhisperBody>
{
    private GodotObject _data;
	public string Message { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSendWhisperBody object.
    /// </summary> 
    public static TwitchSendWhisperBody FromObject(GodotObject data)
    {
		return new TwitchSendWhisperBody
		{
			Message = data.Get("message").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_whisper.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("message", Message);
		return request;
	}
}
