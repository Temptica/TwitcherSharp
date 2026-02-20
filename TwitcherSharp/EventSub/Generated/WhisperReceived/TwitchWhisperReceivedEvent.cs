using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.WhisperReceived;

public partial class TwitchWhisperReceivedEvent : Resource, ITwitcherSharpEventSub<TwitchWhisperReceivedEvent>
{
    /// <summary> 
    /// The ID of the user sending the message.
    /// </summary>
    public string FromUserId { get; set; }

    /// <summary> 
    /// The name of the user sending the message.
    /// </summary>
    public string FromUserName { get; set; }

    /// <summary> 
    /// The login of the user sending the message.
    /// </summary>
    public string FromUserLogin { get; set; }

    /// <summary> 
    /// The ID of the user receiving the message.
    /// </summary>
    public string ToUserId { get; set; }

    /// <summary> 
    /// The name of the user receiving the message.
    /// </summary>
    public string ToUserName { get; set; }

    /// <summary> 
    /// The login of the user receiving the message.
    /// </summary>
    public string ToUserLogin { get; set; }

    /// <summary> 
    /// The whisper ID.
    /// </summary>
    public string WhisperId { get; set; }

    /// <summary> 
    /// Object containing whisper information.
    /// </summary>
    public TwitchWhisper Whisper { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWhisperReceivedEvent object.
    /// </summary> 
    public static TwitchWhisperReceivedEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchWhisperReceivedEvent
        {
            FromUserId = data.Get("from_user_id").AsString(),
            FromUserName = data.Get("from_user_name").AsString(),
            FromUserLogin = data.Get("from_user_login").AsString(),
            ToUserId = data.Get("to_user_id").AsString(),
            ToUserName = data.Get("to_user_name").AsString(),
            ToUserLogin = data.Get("to_user_login").AsString(),
            WhisperId = data.Get("whisper_id").AsString(),
            Whisper = data.Get("whisper").As<TwitchWhisper>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("from_user_id", FromUserId);
        request.Set("from_user_name", FromUserName);
        request.Set("from_user_login", FromUserLogin);
        request.Set("to_user_id", ToUserId);
        request.Set("to_user_name", ToUserName);
        request.Set("to_user_login", ToUserLogin);
        request.Set("whisper_id", WhisperId);
        request.Set("whisper", Whisper);
        return request;
    }

    public partial class TwitchWhisper : Resource, ITwitcherSharpEventSub<TwitchWhisper>
    {
        /// <summary> 
        /// The body of the whisper message.
        /// </summary>
        public string Text { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchWhisper object.
        /// </summary> 
        public static TwitchWhisper FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchWhisper
            {
                Text = data.Get("text").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd");
            var whisperClass = script.Get("Whisper").AsGodotObject();
            var request = whisperClass.Call("new").AsGodotObject();
            request.Set("text", Text);
            return request;
        }
    }
}
