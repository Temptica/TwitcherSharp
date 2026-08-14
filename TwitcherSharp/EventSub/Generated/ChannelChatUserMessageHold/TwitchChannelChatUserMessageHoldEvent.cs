using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatUserMessageHold;

public partial class TwitchChannelChatUserMessageHoldEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatUserMessageHoldEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The User ID of the message sender.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The message sender’s login.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The message sender’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The ID of the message that was flagged by automod.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatUserMessageHoldEvent object.
    /// </summary> 
    public static TwitchChannelChatUserMessageHoldEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatUserMessageHoldEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            MessageId = data.Get("message_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_hold.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(MessageId != null) request.Set("message_id", MessageId);
        if(Message != null) request.Set("message", Message.ToGodotObject());
        return request;
    }


    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The contents of the message caught by automod.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[]? Fragments { get => field ??= _data?.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                Text = data.Get("text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_hold.gd");
            var messageClass = script.Get("Message").As<GDScript>();
            var request = messageClass.New().AsGodotObject();
            if(Text != null) request.Set("text", Text);
            if(Fragments != null) request.Set("fragments", Fragments.ToGodotArray());
            return request;
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// Message text in a fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote? Cheermote { get => field ??= _data?.Get<TwitchCheermote>("cheermote"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Text = data.Get("text").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_hold.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                if(Text != null) request.Set("text", Text);
                if(Emote != null) request.Set("emote", Emote.ToGodotObject());
                if(Cheermote != null) request.Set("cheermote", Cheermote.ToGodotObject());
                return request;
            }
        
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// An ID that uniquely identifies this emote.
                /// </summary>
                public string? Id { get; set; }
            
                /// <summary> 
                /// An ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string? EmoteSetId { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_hold.gd");
                    var emoteClass = script.Get("Emote").As<GDScript>();
                    var request = emoteClass.New().AsGodotObject();
                    if(Id != null) request.Set("id", Id);
                    if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
                    return request;
                }
            }
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.  For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string? Prefix { get; set; }
            
                /// <summary> 
                /// The amount of Bits cheered.
                /// </summary>
                public int Bits { get; set; }
            
                /// <summary> 
                /// The tier level of the cheermote.
                /// </summary>
                public int Tier { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchCheermote object.
                /// </summary> 
                public static TwitchCheermote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_user_message_hold.gd");
                    var cheermoteClass = script.Get("Cheermote").As<GDScript>();
                    var request = cheermoteClass.New().AsGodotObject();
                    if(Prefix != null) request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        }
    }
}
