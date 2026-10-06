using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;


/// <summary> 
/// All optional parameters for TwitchAPI.PinChatMessage 
/// </summary>
public partial class TwitchPinChatMessageOpt : RefCounted, ITwitcherSharp<TwitchPinChatMessageOpt>
{
    private Variant _data;
    public int? DurationSeconds { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPinChatMessageOpt object.
    /// </summary> 
    public static TwitchPinChatMessageOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPinChatMessageOpt
        {
            DurationSeconds = data.Read("duration_seconds", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_pin_chat_message.gd", "Opt");
        if(DurationSeconds.HasValue) request.SetValue("duration_seconds", DurationSeconds.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
