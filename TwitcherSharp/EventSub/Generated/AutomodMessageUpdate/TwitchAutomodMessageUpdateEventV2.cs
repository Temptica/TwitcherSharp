using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageUpdate;

public partial class TwitchAutomodMessageUpdateEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodMessageUpdateEventV2>
{
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The message sender’s user ID.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The message sender’s login name.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The message sender’s display name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The ID of the moderator.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// TThe moderator’s user name.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The ID of the message that was flagged by automod.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// The body of the message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// The message’s status. Possible values are:ApprovedDeniedExpired
    /// </summary>
    public string Status { get; set; }

    /// <summary> 
    /// The timestamp of when automod saved the message.
    /// </summary>
    public string HeldAt { get; set; }

    /// <summary> 
    /// The reason why the message was caught. Possible values are: automodblocked_term
    /// </summary>
    public string Reason { get; set; }

    /// <summary> 
    /// Optional. If the message was caught by automod, this will be populated.
    /// </summary>
    public TwitchAutomod Automod { get; set; }

    /// <summary> 
    /// Optional. If the message was caught due to a blocked term, this will be populated.
    /// </summary>
    public TwitchBlockedTerm BlockedTerm { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageUpdateEventV2 object.
    /// </summary> 
    public static TwitchAutomodMessageUpdateEventV2 FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodMessageUpdateEventV2
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            MessageId = data.Get("message_id").AsString(),
            Message = data.Get("message").As<TwitchMessage>(),
            Status = data.Get("status").AsString(),
            HeldAt = data.Get("held_at").AsString(),
            Reason = data.Get("reason").AsString(),
            Automod = data.Get("automod").As<TwitchAutomod>(),
            BlockedTerm = data.Get("blocked_term").As<TwitchBlockedTerm>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
        var automodMessageUpdateEventV2V2Class = script.Get("AutomodMessageUpdateEventV2V2").AsGodotObject();
        var request = automodMessageUpdateEventV2V2Class.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("message_id", MessageId);
        request.Set("message", Message);
        request.Set("status", Status);
        request.Set("held_at", HeldAt);
        request.Set("reason", Reason);
        request.Set("automod", Automod);
        request.Set("blocked_term", BlockedTerm);
        return request;
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        /// <summary> 
        /// The contents of the message caught by automod.
        /// </summary>
        public string Text { get; set; }
    
        /// <summary> 
        /// Metadata surrounding the potential inappropriate fragments of the message.
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
                Text = data.Get("text").AsString(),
                Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
            var messageClass = script.Get("Message").AsGodotObject();
            var request = messageClass.Call("new").AsGodotObject();
            request.Set("text", Text);
            request.Set("fragments", Fragments);
            return request;
        }
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            /// <summary> 
            /// Message text in a fragment.
            /// </summary>
            public string Text { get; set; }
        
            /// <summary> 
            /// One of three options:textemotecheermote
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote Cheermote { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchFragments
                {
                    Text = data.Get("text").AsString(),
                    Type = data.Get("type").AsString(),
                    Emote = data.Get("emote").As<TwitchEmote>(),
                    Cheermote = data.Get("cheermote").As<TwitchCheermote>(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                var fragmentsClass = script.Get("Fragments").AsGodotObject();
                var request = fragmentsClass.Call("new").AsGodotObject();
                request.Set("text", Text);
                request.Set("type", Type);
                request.Set("emote", Emote);
                request.Set("cheermote", Cheermote);
                return request;
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                    var emoteClass = script.Get("Emote").AsGodotObject();
                    var request = emoteClass.Call("new").AsGodotObject();
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    return request;
                }
            }
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.  For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string Prefix { get; set; }
            
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
                public static TwitchCheermote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                    var cheermoteClass = script.Get("Cheermote").AsGodotObject();
                    var request = cheermoteClass.Call("new").AsGodotObject();
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        }
    }

    public partial class TwitchAutomod : RefCounted, ITwitcherSharpEventSub<TwitchAutomod>
    {
        /// <summary> 
        /// The category of the caught message.
        /// </summary>
        public string Category { get; set; }
    
        /// <summary> 
        /// The level of severity (1-4).
        /// </summary>
        public int Level { get; set; }
    
        /// <summary> 
        /// The bounds of the text that caused the message to be caught.
        /// </summary>
        public TwitchBoundaries[] Boundaries { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutomod object.
        /// </summary> 
        public static TwitchAutomod FromObject(GodotObject data)
        {
            if(data == null) return null;
            var boundariesArray = data.Get("boundaries").AsGodotArray<GodotObject>();
            return new TwitchAutomod
            {
                Category = data.Get("category").AsString(),
                Level = data.Get("level").AsInt32(),
                Boundaries = boundariesArray.Select(TwitchBoundaries.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
            var automodClass = script.Get("Automod").AsGodotObject();
            var request = automodClass.Call("new").AsGodotObject();
            request.Set("category", Category);
            request.Set("level", Level);
            request.Set("boundaries", Boundaries);
            return request;
        }
    
        public partial class TwitchBoundaries : RefCounted, ITwitcherSharpEventSub<TwitchBoundaries>
        {
            /// <summary> 
            /// Index in the message for the start of the problem (Starting at 0).
            /// </summary>
            public int StartPos { get; set; }
        
            /// <summary> 
            /// Index in the message for the end of the problem (Starting at 0).
            /// </summary>
            public int EndPos { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchBoundaries object.
            /// </summary> 
            public static TwitchBoundaries FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchBoundaries
                {
                    StartPos = data.Get("start_pos").AsInt32(),
                    EndPos = data.Get("end_pos").AsInt32(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                var boundariesClass = script.Get("Boundaries").AsGodotObject();
                var request = boundariesClass.Call("new").AsGodotObject();
                request.Set("start_pos", StartPos);
                request.Set("end_pos", EndPos);
                return request;
            }
        }
    }

    public partial class TwitchBlockedTerm : RefCounted, ITwitcherSharpEventSub<TwitchBlockedTerm>
    {
        /// <summary> 
        /// The list of blocked terms found in the message.
        /// </summary>
        public TwitchTermsFound[] TermsFound { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBlockedTerm object.
        /// </summary> 
        public static TwitchBlockedTerm FromObject(GodotObject data)
        {
            if(data == null) return null;
            var termsFoundArray = data.Get("terms_found").AsGodotArray<GodotObject>();
            return new TwitchBlockedTerm
            {
                TermsFound = termsFoundArray.Select(TwitchTermsFound.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
            var blockedTermClass = script.Get("BlockedTerm").AsGodotObject();
            var request = blockedTermClass.Call("new").AsGodotObject();
            request.Set("terms_found", TermsFound);
            return request;
        }
    
        public partial class TwitchTermsFound : RefCounted, ITwitcherSharpEventSub<TwitchTermsFound>
        {
            /// <summary> 
            /// The id of the blocked term found.
            /// </summary>
            public string TermId { get; set; }
        
            /// <summary> 
            /// The bounds of the text that caused the message to be caught.
            /// </summary>
            public TwitchBoundary Boundary { get; set; }
        
            /// <summary> 
            /// The id of the broadcaster that owns the blocked term.
            /// </summary>
            public string OwnerBroadcasterUserId { get; set; }
        
            /// <summary> 
            /// The login of the broadcaster that owns the blocked term.
            /// </summary>
            public string OwnerBroadcasterUserLogin { get; set; }
        
            /// <summary> 
            /// The username of the broadcaster that owns the blocked term.
            /// </summary>
            public string OwnerBroadcasterUserName { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchTermsFound object.
            /// </summary> 
            public static TwitchTermsFound FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchTermsFound
                {
                    TermId = data.Get("term_id").AsString(),
                    Boundary = data.Get("boundary").As<TwitchBoundary>(),
                    OwnerBroadcasterUserId = data.Get("owner_broadcaster_user_id").AsString(),
                    OwnerBroadcasterUserLogin = data.Get("owner_broadcaster_user_login").AsString(),
                    OwnerBroadcasterUserName = data.Get("owner_broadcaster_user_name").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                var termsFoundClass = script.Get("TermsFound").AsGodotObject();
                var request = termsFoundClass.Call("new").AsGodotObject();
                request.Set("term_id", TermId);
                request.Set("boundary", Boundary);
                request.Set("owner_broadcaster_user_id", OwnerBroadcasterUserId);
                request.Set("owner_broadcaster_user_login", OwnerBroadcasterUserLogin);
                request.Set("owner_broadcaster_user_name", OwnerBroadcasterUserName);
                return request;
            }
        
            public partial class TwitchBoundary : RefCounted, ITwitcherSharpEventSub<TwitchBoundary>
            {
                /// <summary> 
                /// Index in the message for the start of the problem (0 indexed, inclusive).
                /// </summary>
                public int StartPos { get; set; }
            
                /// <summary> 
                /// Index in the message for the end of the problem (0 indexed, inclusive).
                /// </summary>
                public int EndPos { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchBoundary object.
                /// </summary> 
                public static TwitchBoundary FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchBoundary
                    {
                        StartPos = data.Get("start_pos").AsInt32(),
                        EndPos = data.Get("end_pos").AsInt32(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_update.gd");
                    var boundaryClass = script.Get("Boundary").AsGodotObject();
                    var request = boundaryClass.Call("new").AsGodotObject();
                    request.Set("start_pos", StartPos);
                    request.Set("end_pos", EndPos);
                    return request;
                }
            }
        }
    }
}
