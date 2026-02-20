using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserMessage;

public partial class TwitchChannelSuspiciousUserMessageEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserMessageEvent>
{
    /// <summary> 
    /// The ID of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The login of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the user that sent the message.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user name of the user that sent the message.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”
    /// </summary>
    public string LowTrustStatus { get; set; }

    /// <summary> 
    /// A list of channel IDs where the suspicious user is also banned.
    /// </summary>
    public string[] SharedBanChannelIds { get; set; }

    /// <summary> 
    /// User types (if any) that apply to the suspicious user, can be “manually_added”, “ban_evader”, or “banned_in_shared_channel”.
    /// </summary>
    public string[] Types { get; set; }

    /// <summary> 
    /// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “unknown”, “possible”, or “likely”.
    /// </summary>
    public string BanEvasionEvaluation { get; set; }

    /// <summary> 
    /// The structured chat message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserMessageEvent object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserMessageEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSuspiciousUserMessageEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            LowTrustStatus = data.Get("low_trust_status").AsString(),
            SharedBanChannelIds = data.Get("shared_ban_channel_ids").AsStringArray(),
            Types = data.Get("types").AsStringArray(),
            BanEvasionEvaluation = data.Get("ban_evasion_evaluation").AsString(),
            Message = data.Get("message").As<TwitchMessage>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("user_id", UserId);
        request.Set("user_name", UserName);
        request.Set("user_login", UserLogin);
        request.Set("low_trust_status", LowTrustStatus);
        request.Set("shared_ban_channel_ids", SharedBanChannelIds);
        request.Set("types", Types);
        request.Set("ban_evasion_evaluation", BanEvasionEvaluation);
        request.Set("message", Message);
        return request;
    }

    public partial class TwitchMessage : Resource, ITwitcherSharpEventSub<TwitchMessage>
    {
        /// <summary> 
        /// The UUID that identifies the message.
        /// </summary>
        public string MessageId { get; set; }
    
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[] Fragments { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage FromObject(GodotObject data)
        {
            if(data == null) return null;
            var fragmentsArray = data.Get("fragments").AsGodotArray<GodotObject>();
            return new TwitchMessage
            {
                MessageId = data.Get("message_id").AsString(),
                Text = data.Get("text").AsString(),
                Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
            var messageClass = script.Get("Message").AsGodotObject();
            var request = messageClass.Call("new").AsGodotObject();
            request.Set("message_id", MessageId);
            request.Set("text", Text);
            request.Set("fragments", Fragments);
            return request;
        }
    
        public partial class TwitchFragments : Resource, ITwitcherSharpEventSub<TwitchFragments>
        {
            /// <summary> 
            /// The type of message fragment. Possible values: -text -cheermote -emote
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Message text in fragment.
            /// </summary>
            public string Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote Cheermote { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchFragments
                {
                    Type = data.Get("type").AsString(),
                    Text = data.Get("text").AsString(),
                    Cheermote = data.Get("cheermote").As<TwitchCheermote>(),
                    Emote = data.Get("emote").As<TwitchEmote>(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
                var fragmentsClass = script.Get("Fragments").AsGodotObject();
                var request = fragmentsClass.Call("new").AsGodotObject();
                request.Set("type", Type);
                request.Set("text", Text);
                request.Set("cheermote", Cheermote);
                request.Set("emote", Emote);
                return request;
            }
        
            public partial class TwitchCheermote : Resource, ITwitcherSharpEventSub<TwitchCheermote>
            {
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.   For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string Prefix { get; set; }
            
                /// <summary> 
                /// The amount of Bits cheered.
                /// </summary>
                public string Bits { get; set; }
            
                /// <summary> 
                /// The tier level of the cheermote.
                /// </summary>
                public string Tier { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchCheermote object.
                /// </summary> 
                public static TwitchCheermote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsString(),
                        Tier = data.Get("tier").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
                    var cheermoteClass = script.Get("Cheermote").AsGodotObject();
                    var request = cheermoteClass.Call("new").AsGodotObject();
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        
            public partial class TwitchEmote : Resource, ITwitcherSharpEventSub<TwitchEmote>
            {
                /// <summary> 
                /// An ID that uniquely identifies this emote.
                /// </summary>
                public string Id { get; set; }
            
                /// <summary> 
                /// An ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string EmoteSetId { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd");
                    var emoteClass = script.Get("Emote").AsGodotObject();
                    var request = emoteClass.Call("new").AsGodotObject();
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    return request;
                }
            }
        }
    }
}
