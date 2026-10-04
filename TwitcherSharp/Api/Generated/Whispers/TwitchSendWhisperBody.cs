using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Whispers;

public partial class TwitchSendWhisperBody : RefCounted, ITwitcherSharp<TwitchSendWhisperBody>
{
    private Variant _data;
    public string Message { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchSendWhisperBody object.
    /// </summary> 
    public static TwitchSendWhisperBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendWhisperBody
        {
            Message = data.Read("message", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_whisper.gd", "Body");
        if(Message != null) request.SetValue("message", Message);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
