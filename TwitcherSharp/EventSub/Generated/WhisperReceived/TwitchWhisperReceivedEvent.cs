using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.WhisperReceived;

public partial class TwitchWhisperReceivedEvent : RefCounted, ITwitcherSharpEventSub<TwitchWhisperReceivedEvent>
{
    private Variant _data;
    
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
    public TwitchWhisper? Whisper { get => field ??= _data.Get<TwitchWhisper>("whisper"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWhisperReceivedEvent object.
    /// </summary> 
    public static TwitchWhisperReceivedEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchWhisperReceivedEvent
        {
            FromUserId = data.Read("from_user_id", static v => v.AsString()),
            FromUserName = data.Read("from_user_name", static v => v.AsString()),
            FromUserLogin = data.Read("from_user_login", static v => v.AsString()),
            ToUserId = data.Read("to_user_id", static v => v.AsString()),
            ToUserName = data.Read("to_user_name", static v => v.AsString()),
            ToUserLogin = data.Read("to_user_login", static v => v.AsString()),
            WhisperId = data.Read("whisper_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd", "Event");
        if(FromUserId != null) request.SetValue("from_user_id", FromUserId);
        if(FromUserName != null) request.SetValue("from_user_name", FromUserName);
        if(FromUserLogin != null) request.SetValue("from_user_login", FromUserLogin);
        if(ToUserId != null) request.SetValue("to_user_id", ToUserId);
        if(ToUserName != null) request.SetValue("to_user_name", ToUserName);
        if(ToUserLogin != null) request.SetValue("to_user_login", ToUserLogin);
        if(WhisperId != null) request.SetValue("whisper_id", WhisperId);
        if(Whisper != null) request.SetObject("whisper", Whisper);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchWhisper : RefCounted, ITwitcherSharpEventSub<TwitchWhisper>
    {
        private Variant _data;
        
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
                Text = data.Read("text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_whisper_received.gd", "Whisper");
            if(Text != null) request.SetValue("text", Text);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }
}
