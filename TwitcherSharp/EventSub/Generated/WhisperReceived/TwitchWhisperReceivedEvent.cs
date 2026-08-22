using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.WhisperReceived;

public partial class TwitchWhisperReceivedEvent : RefCounted, ITwitcherSharpEventSub<TwitchWhisperReceivedEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the user sending the message.
    /// </summary>
    public string? FromUserId { get; set; }

    /// <summary> 
    /// The name of the user sending the message.
    /// </summary>
    public string? FromUserName { get; set; }

    /// <summary> 
    /// The login of the user sending the message.
    /// </summary>
    public string? FromUserLogin { get; set; }

    /// <summary> 
    /// The ID of the user receiving the message.
    /// </summary>
    public string? ToUserId { get; set; }

    /// <summary> 
    /// The name of the user receiving the message.
    /// </summary>
    public string? ToUserName { get; set; }

    /// <summary> 
    /// The login of the user receiving the message.
    /// </summary>
    public string? ToUserLogin { get; set; }

    /// <summary> 
    /// The whisper ID.
    /// </summary>
    public string? WhisperId { get; set; }

    /// <summary> 
    /// Object containing whisper information.
    /// </summary>
    public TwitchWhisper? Whisper { get => field ??= _data?.Get<TwitchWhisper>("whisper"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWhisperReceivedEvent object.
    /// </summary> 
    public static TwitchWhisperReceivedEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchWhisperReceivedEvent
        {
            FromUserId = data.Get("from_user_id").AsString(),
            FromUserName = data.Get("from_user_name").AsString(),
            FromUserLogin = data.Get("from_user_login").AsString(),
            ToUserId = data.Get("to_user_id").AsString(),
            ToUserName = data.Get("to_user_name").AsString(),
            ToUserLogin = data.Get("to_user_login").AsString(),
            WhisperId = data.Get("whisper_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(FromUserId != null) request.Set("from_user_id", FromUserId);
        if(FromUserName != null) request.Set("from_user_name", FromUserName);
        if(FromUserLogin != null) request.Set("from_user_login", FromUserLogin);
        if(ToUserId != null) request.Set("to_user_id", ToUserId);
        if(ToUserName != null) request.Set("to_user_name", ToUserName);
        if(ToUserLogin != null) request.Set("to_user_login", ToUserLogin);
        if(WhisperId != null) request.Set("whisper_id", WhisperId);
        if(Whisper != null) request.Set("whisper", Whisper.ToGodotObject());
        return request;
    }


    public partial class TwitchWhisper : RefCounted, ITwitcherSharpEventSub<TwitchWhisper>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The body of the whisper message.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchWhisper object.
        /// </summary> 
        public static TwitchWhisper? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchWhisper
            {
                Text = data.Get("text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd");
            var whisperClass = script.Get("Whisper").As<GDScript>();
            var request = whisperClass.New().AsGodotObject();
            if(Text != null) request.Set("text", Text);
            return request;
        }
    }
}
