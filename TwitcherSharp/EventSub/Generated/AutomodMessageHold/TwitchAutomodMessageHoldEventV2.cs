using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEventV2>
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
    /// The message sender’s user ID.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The message sender’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The message sender’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The ID of the held message.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The timestamp of when automod saved the message.
    /// </summary>
    public string? HeldAt { get; set; }

    /// <summary> 
    /// Possible values are: automodblocked_term
    /// </summary>
    public string? Reason { get; set; }

    /// <summary> 
    /// Optional. If the message was caught by automod, this will be populated.
    /// </summary>
    public TwitchAutomodV2? AutomodV2 { get => field ??= _data?.Get<TwitchAutomodV2>("automod_v_2"); set; }

    /// <summary> 
    /// Optional. If the message was caught due to a blocked term, this will be populated.
    /// </summary>
    public TwitchBlockedTermV2? BlockedTermV2 { get => field ??= _data?.Get<TwitchBlockedTermV2>("blocked_term_v_2"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldEventV2 object.
    /// </summary> 
    public static TwitchAutomodMessageHoldEventV2? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodMessageHoldEventV2
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            MessageId = data.Get("message_id").AsString(),
            HeldAt = data.Get("held_at").AsString(),
            Reason = data.Get("reason").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
        var eventV2Class = script.Get("EventV2").As<GDScript>();
        var request = eventV2Class.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(MessageId != null) request.Set("message_id", MessageId);
        if(Message != null) request.Set("message", Message.ToGodotObject());
        if(HeldAt != null) request.Set("held_at", HeldAt);
        if(Reason != null) request.Set("reason", Reason);
        if(AutomodV2 != null) request.Set("automod_v_2", AutomodV2.ToGodotObject());
        if(BlockedTermV2 != null) request.Set("blocked_term_v_2", BlockedTermV2.ToGodotObject());
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
        /// Metadata surrounding the potential inappropriate fragments of the message.
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
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
            /// One of three options:textemotecheermote
            /// </summary>
            public string? Type { get; set; }
        
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
                    Type = data.Get("type").AsString(),
                    Text = data.Get("text").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                if(Type != null) request.Set("type", Type);
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
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
                /// The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.For example, if the prefix is “cheer” and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
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

    public partial class TwitchAutomodV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The category of the caught message.
        /// </summary>
        public string? Category { get; set; }
    
        /// <summary> 
        /// The level of severity (1-4).
        /// </summary>
        public int Level { get; set; }
    
        /// <summary> 
        /// The bounds of the text that caused the message to be caught.
        /// </summary>
        public TwitchBoundariesV2[]? Boundaries { get => field ??= _data?.GetArray<TwitchBoundariesV2>("boundaries"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutomodV2 object.
        /// </summary> 
        public static TwitchAutomodV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAutomodV2
            {
                Category = data.Get("category").AsString(),
                Level = data.Get("level").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
            var automodV2Class = script.Get("AutomodV2").As<GDScript>();
            var request = automodV2Class.New().AsGodotObject();
            if(Category != null) request.Set("category", Category);
            request.Set("level", Level);
            if(Boundaries != null) request.Set("boundaries", Boundaries.ToGodotArray());
            return request;
        }
    
    
        public partial class TwitchBoundariesV2 : RefCounted, ITwitcherSharpEventSub<TwitchBoundariesV2>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// Index in the message for the start of the problem (0 indexed, inclusive).
            /// </summary>
            public int StartPos { get; set; }
        
            /// <summary> 
            /// Index in the message for the end of the problem (0 indexed, inclusive).
            /// </summary>
            public int EndPos { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchBoundariesV2 object.
            /// </summary> 
            public static TwitchBoundariesV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchBoundariesV2
                {
                    StartPos = data.Get("start_pos").AsInt32(),
                    EndPos = data.Get("end_pos").AsInt32(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var boundariesV2Class = script.Get("BoundariesV2").As<GDScript>();
                var request = boundariesV2Class.New().AsGodotObject();
                request.Set("start_pos", StartPos);
                request.Set("end_pos", EndPos);
                return request;
            }
        }
    }

    public partial class TwitchBlockedTermV2 : RefCounted, ITwitcherSharpEventSub<TwitchBlockedTermV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The list of blocked terms found in the message.
        /// </summary>
        public TwitchTermsFoundV2[]? TermsFound { get => field ??= _data?.GetArray<TwitchTermsFoundV2>("terms_found"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBlockedTermV2 object.
        /// </summary> 
        public static TwitchBlockedTermV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBlockedTermV2
            {
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
            var blockedTermV2Class = script.Get("BlockedTermV2").As<GDScript>();
            var request = blockedTermV2Class.New().AsGodotObject();
            if(TermsFound != null) request.Set("terms_found", TermsFound.ToGodotArray());
            return request;
        }
    
    
        public partial class TwitchTermsFoundV2 : RefCounted, ITwitcherSharpEventSub<TwitchTermsFoundV2>
        {
            private GodotObject? _data;
            
            /// <summary> 
            /// The id of the blocked term found.
            /// </summary>
            public string? TermId { get; set; }
        
            /// <summary> 
            /// The bounds of the text that caused the message to be caught.
            /// </summary>
            public TwitchBoundaryV2? BoundaryV2 { get => field ??= _data?.Get<TwitchBoundaryV2>("boundary_v_2"); set; }
        
            /// <summary> 
            /// The id of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserId { get; set; }
        
            /// <summary> 
            /// The login of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserLogin { get; set; }
        
            /// <summary> 
            /// The username of the broadcaster that owns the blocked term.
            /// </summary>
            public string? OwnerBroadcasterUserName { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchTermsFoundV2 object.
            /// </summary> 
            public static TwitchTermsFoundV2? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchTermsFoundV2
                {
                    TermId = data.Get("term_id").AsString(),
                    OwnerBroadcasterUserId = data.Get("owner_broadcaster_user_id").AsString(),
                    OwnerBroadcasterUserLogin = data.Get("owner_broadcaster_user_login").AsString(),
                    OwnerBroadcasterUserName = data.Get("owner_broadcaster_user_name").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var termsFoundV2Class = script.Get("TermsFoundV2").As<GDScript>();
                var request = termsFoundV2Class.New().AsGodotObject();
                if(TermId != null) request.Set("term_id", TermId);
                if(BoundaryV2 != null) request.Set("boundary_v_2", BoundaryV2.ToGodotObject());
                if(OwnerBroadcasterUserId != null) request.Set("owner_broadcaster_user_id", OwnerBroadcasterUserId);
                if(OwnerBroadcasterUserLogin != null) request.Set("owner_broadcaster_user_login", OwnerBroadcasterUserLogin);
                if(OwnerBroadcasterUserName != null) request.Set("owner_broadcaster_user_name", OwnerBroadcasterUserName);
                return request;
            }
        
        
            public partial class TwitchBoundaryV2 : RefCounted, ITwitcherSharpEventSub<TwitchBoundaryV2>
            {
                private GodotObject? _data;
                
                /// <summary> 
                /// Index in the message for the start of the problem (0 indexed, inclusive).
                /// </summary>
                public int StartPos { get; set; }
            
                /// <summary> 
                /// Index in the message for the end of the problem (0 indexed, inclusive).
                /// </summary>
                public int EndPos { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchBoundaryV2 object.
                /// </summary> 
                public static TwitchBoundaryV2? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchBoundaryV2
                    {
                        StartPos = data.Get("start_pos").AsInt32(),
                        EndPos = data.Get("end_pos").AsInt32(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                    var boundaryV2Class = script.Get("BoundaryV2").As<GDScript>();
                    var request = boundaryV2Class.New().AsGodotObject();
                    request.Set("start_pos", StartPos);
                    request.Set("end_pos", EndPos);
                    return request;
                }
            }
        }
    }
}
