using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Whispers;

public partial class TwitchSendWhisperBody : RefCounted, ITwitcherSharp<TwitchSendWhisperBody>
{
    private GodotObject _data;
    public string Message { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendWhisperBody object.
    /// </summary> 
    public static TwitchSendWhisperBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchSendWhisperBody
        {
            Message = data.Get("message").AsString(),
        };
        
        instance._data = data;
        return instance;
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
