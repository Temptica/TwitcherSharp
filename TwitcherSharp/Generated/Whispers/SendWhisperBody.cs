using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Whispers;
 
/// <summary> 
///  
/// </summary>
public partial class SendWhisperBody : Resource, ITwitcherSharp<SendWhisperBody>
{
    private GodotObject _data;
	public string Message { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SendWhisperBody object.
    /// </summary> 
    public static SendWhisperBody FromObject(GodotObject data)
    {
        return new SendWhisperBody
        {

			Message = data.Get("message").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_whisper_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("message", Message);
		return request;
	}
}
