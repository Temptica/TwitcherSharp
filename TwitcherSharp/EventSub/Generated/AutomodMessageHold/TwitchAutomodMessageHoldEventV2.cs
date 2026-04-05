using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEventV2>
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
    /// The ID of the held message.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// The body of the message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// The timestamp of when automod saved the message.
    /// </summary>
    public string HeldAt { get; set; }

    /// <summary> 
    /// Possible values are: automodblocked_term
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
    /// Transforms the godot data into a TwitchAutomodMessageHoldEventV2 object.
    /// </summary> 
    public static TwitchAutomodMessageHoldEventV2 FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodMessageHoldEventV2
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            MessageId = data.Get("message_id").AsString(),
            Message = TwitchMessage.FromObject(data.Get("message").AsGodotObject()),
            HeldAt = data.Get("held_at").AsString(),
            Reason = data.Get("reason").AsString(),
            Automod = TwitchAutomod.FromObject(data.Get("automod").AsGodotObject()),
            BlockedTerm = TwitchBlockedTerm.FromObject(data.Get("blocked_term").AsGodotObject()),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
        var eventV2Class = script.Get("EventV2").As<GDScript>();
        var request = eventV2Class.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("message_id", MessageId);
        request.Set("message", Message.ToGodotObject());
        request.Set("held_at", HeldAt);
        request.Set("reason", Reason);
        request.Set("automod", Automod.ToGodotObject());
        request.Set("blocked_term", BlockedTerm.ToGodotObject());
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
            var messageClass = script.Get("Message").As<GDScript>();
            var request = messageClass.New().AsGodotObject();
            request.Set("text", Text);
            request.Set("fragments", new Godot.Collections.Array(Fragments.Select(x => x.ToGodotObject()).ToArray()));
            return request;
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            /// <summary> 
            /// One of three options:textemotecheermote
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Message text in a fragment.
            /// </summary>
            public string Text { get; set; }
        
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
                    Type = data.Get("type").AsString(),
                    Text = data.Get("text").AsString(),
                    Emote = TwitchEmote.FromObject(data.Get("emote").AsGodotObject()),
                    Cheermote = TwitchCheermote.FromObject(data.Get("cheermote").AsGodotObject()),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                request.Set("type", Type);
                request.Set("text", Text);
                request.Set("emote", Emote.ToGodotObject());
                request.Set("cheermote", Cheermote.ToGodotObject());
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                    var emoteClass = script.Get("Emote").As<GDScript>();
                    var request = emoteClass.New().AsGodotObject();
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                    var cheermoteClass = script.Get("Cheermote").As<GDScript>();
                    var request = cheermoteClass.New().AsGodotObject();
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
            var automodClass = script.Get("Automod").As<GDScript>();
            var request = automodClass.New().AsGodotObject();
            request.Set("category", Category);
            request.Set("level", Level);
            request.Set("boundaries", new Godot.Collections.Array(Boundaries.Select(x => x.ToGodotObject()).ToArray()));
            return request;
        }
    
    
        public partial class TwitchBoundaries : RefCounted, ITwitcherSharpEventSub<TwitchBoundaries>
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var boundariesClass = script.Get("Boundaries").As<GDScript>();
                var request = boundariesClass.New().AsGodotObject();
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
            var blockedTermClass = script.Get("BlockedTerm").As<GDScript>();
            var request = blockedTermClass.New().AsGodotObject();
            request.Set("terms_found", new Godot.Collections.Array(TermsFound.Select(x => x.ToGodotObject()).ToArray()));
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
                    Boundary = TwitchBoundary.FromObject(data.Get("boundary").AsGodotObject()),
                    OwnerBroadcasterUserId = data.Get("owner_broadcaster_user_id").AsString(),
                    OwnerBroadcasterUserLogin = data.Get("owner_broadcaster_user_login").AsString(),
                    OwnerBroadcasterUserName = data.Get("owner_broadcaster_user_name").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                var termsFoundClass = script.Get("TermsFound").As<GDScript>();
                var request = termsFoundClass.New().AsGodotObject();
                request.Set("term_id", TermId);
                request.Set("boundary", Boundary.ToGodotObject());
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
                    var boundaryClass = script.Get("Boundary").As<GDScript>();
                    var request = boundaryClass.New().AsGodotObject();
                    request.Set("start_pos", StartPos);
                    request.Set("end_pos", EndPos);
                    return request;
                }
            }
        }
    }
}
