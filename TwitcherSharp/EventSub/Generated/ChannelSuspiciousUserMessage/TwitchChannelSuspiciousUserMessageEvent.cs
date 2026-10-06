using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserMessage;

public partial class TwitchChannelSuspiciousUserMessageEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserMessageEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The login of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the user that sent the message.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user name of the user that sent the message.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”
    /// </summary>
    public string? LowTrustStatus { get; set; }

    /// <summary> 
    /// A list of channel IDs where the suspicious user is also banned.
    /// </summary>
    public string[]? SharedBanChannelIds { get; set; }

    /// <summary> 
    /// User types (if any) that apply to the suspicious user, can be “manually_added”, “ban_evader”, or “banned_in_shared_channel”.
    /// </summary>
    public string[]? Types { get; set; }

    /// <summary> 
    /// A ban evasion likelihood value (if any) that as been applied to the user automatically by Twitch, can be “unknown”, “possible”, or “likely”.
    /// </summary>
    public string? BanEvasionEvaluation { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserMessageEvent object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserMessageEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSuspiciousUserMessageEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            LowTrustStatus = data.Read("low_trust_status", static v => v.AsString()),
            Types = data.Read("types", static v => v.AsStringArray()),
            BanEvasionEvaluation = data.Read("ban_evasion_evaluation", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(LowTrustStatus != null) request.SetValue("low_trust_status", LowTrustStatus);
        if(SharedBanChannelIds != null) request.SetValue("shared_ban_channel_ids", new Godot.Collections.Array<string>(SharedBanChannelIds));
        if(Types != null) request.SetValue("types", Types);
        if(BanEvasionEvaluation != null) request.SetValue("ban_evasion_evaluation", BanEvasionEvaluation);
        if(Message != null) request.SetObject("message", Message);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private Variant _data;
        
        /// <summary> 
        /// The UUID that identifies the message.
        /// </summary>
        public string? MessageId { get; set; }
    
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[]? Fragments { get => field ??= _data.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                MessageId = data.Read("message_id", static v => v.AsString()),
                Text = data.Read("text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd", "Message");
            if(MessageId != null) request.SetValue("message_id", MessageId);
            if(Text != null) request.SetValue("text", Text);
            if(Fragments != null) request.SetArray("fragments", Fragments);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private Variant _data;
            
            /// <summary> 
            /// The type of message fragment. Possible values: -text -cheermote -emote
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Message text in fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote? Cheermote { get => field ??= _data.Get<TwitchCheermote>("cheermote"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Type = data.Read("type", static v => v.AsString()),
                    Text = data.Read("text", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd", "Fragments");
                if(Type != null) request.SetValue("type", Type);
                if(Text != null) request.SetValue("text", Text);
                if(Cheermote != null) request.SetObject("cheermote", Cheermote);
                if(Emote != null) request.SetObject("emote", Emote);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
        
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private Variant _data;
                
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.   For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
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
                        Prefix = data.Read("prefix", static v => v.AsString()),
                        Bits = data.Read("bits", static v => v.AsInt32()),
                        Tier = data.Read("tier", static v => v.AsInt32()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd", "Cheermote");
                    if(Prefix != null) request.SetValue("prefix", Prefix);
                    request.SetValue("bits", Bits);
                    request.SetValue("tier", Tier);
                    return request;
                }
            
                /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                protected override void Dispose(bool disposing)
                {
                    if (disposing) _data.Dispose();
                    base.Dispose(disposing);
                }
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private Variant _data;
                
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
                        Id = data.Read("id", static v => v.AsString()),
                        EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_message.gd", "Emote");
                    if(Id != null) request.SetValue("id", Id);
                    if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
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
    }
}
