using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;


/// <summary> 
/// All optional parameters for TwitchAPI.PinChatMessage 
/// </summary>
public partial class TwitchPinChatMessageOpt : RefCounted, ITwitcherSharp<TwitchPinChatMessageOpt>
{
    private GodotObject? _data;
    public int? DurationSeconds { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPinChatMessageOpt object.
    /// </summary> 
    public static TwitchPinChatMessageOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPinChatMessageOpt
        {
            DurationSeconds = data.Get("duration_seconds").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_pin_chat_message.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(DurationSeconds.HasValue) request.Set("duration_seconds", DurationSeconds.Value);
        return request;
    }

}
