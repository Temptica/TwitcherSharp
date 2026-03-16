using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.HypeTrainEnd;

public partial class TwitchHypeTrainEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchHypeTrainEndEvent>
{
    /// <summary> 
    /// The Hype Train ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// Total points contributed to the Hype Train.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// The contributors with the most points contributed.
    /// </summary>
    public TwitchTopContributions[] TopContributions { get; set; }

    /// <summary> 
    /// The current level of the Hype Train.
    /// </summary>
    public int Level { get; set; }

    /// <summary> 
    /// Optional. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    /// </summary>
    public TwitchSharedTrainParticipants[] SharedTrainParticipants { get; set; }

    /// <summary> 
    /// The time when the Hype Train started.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train cooldown ends so that the next Hype Train can start.
    /// </summary>
    public string CooldownEndsAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train ended.
    /// </summary>
    public string EndedAt { get; set; }

    /// <summary> 
    /// The type of the Hype Train. Possible values are: treasure golden_kapparegular
    /// </summary>
    public string Type { get; set; }

    /// <summary> 
    /// Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
    /// </summary>
    public TwitchIsSharedTrain[] IsSharedTrain { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainEndEvent object.
    /// </summary> 
    public static TwitchHypeTrainEndEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var topContributionsArray = data.Get("top_contributions").AsGodotArray<GodotObject>();
        var sharedTrainParticipantsArray = data.Get("shared_train_participants").AsGodotArray<GodotObject>();
        var isSharedTrainArray = data.Get("is_shared_train").AsGodotArray<GodotObject>();
        return new TwitchHypeTrainEndEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Total = data.Get("total").AsInt32(),
            TopContributions = topContributionsArray.Select(TwitchTopContributions.FromObject).ToArray(),
            Level = data.Get("level").AsInt32(),
            SharedTrainParticipants = sharedTrainParticipantsArray.Select(TwitchSharedTrainParticipants.FromObject).ToArray(),
            StartedAt = data.Get("started_at").AsString(),
            CooldownEndsAt = data.Get("cooldown_ends_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
            Type = data.Get("type").AsString(),
            IsSharedTrain = isSharedTrainArray.Select(TwitchIsSharedTrain.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("total", Total);
        request.Set("top_contributions", TopContributions);
        request.Set("level", Level);
        request.Set("shared_train_participants", SharedTrainParticipants);
        request.Set("started_at", StartedAt);
        request.Set("cooldown_ends_at", CooldownEndsAt);
        request.Set("ended_at", EndedAt);
        request.Set("type", Type);
        request.Set("is_shared_train", IsSharedTrain);
        return request;
    }

    public partial class TwitchTopContributions : RefCounted, ITwitcherSharpEventSub<TwitchTopContributions>
    {
        /// <summary> 
        /// The ID of the user that made the contribution.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The user’s login name.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user’s display name.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The contribution method used. Possible values are: bits - Bits contributions with Cheering, Power-ups, and Extensions. subscription - Subscription activity like subscribing or gifting subscriptions. other - Covers other contribution methods not listed.
        /// </summary>
        public TwitchType[] Type { get; set; }
    
        /// <summary> 
        /// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
        /// </summary>
        public int Total { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTopContributions object.
        /// </summary> 
        public static TwitchTopContributions FromObject(GodotObject data)
        {
            if(data == null) return null;
            var typeArray = data.Get("type").AsGodotArray<GodotObject>();
            return new TwitchTopContributions
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Type = typeArray.Select(TwitchType.FromObject).ToArray(),
                Total = data.Get("total").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
            var topContributionsClass = script.Get("TopContributions").AsGodotObject();
            var request = topContributionsClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("type", Type);
            request.Set("total", Total);
            return request;
        }
    
        public partial class TwitchType : RefCounted, ITwitcherSharpEventSub<TwitchType>
        {
        
            /// <summary> 
            /// Transforms the godot data into a TwitchType object.
            /// </summary> 
            public static TwitchType FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchType
                {
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
                var typeClass = script.Get("Type").AsGodotObject();
                var request = typeClass.Call("new").AsGodotObject();
                return request;
            }
        }
    }

    public partial class TwitchSharedTrainParticipants : RefCounted, ITwitcherSharpEventSub<TwitchSharedTrainParticipants>
    {
        /// <summary> 
        /// The ID of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string BroadcasterUserId { get; set; }
    
        /// <summary> 
        /// The login of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string BroadcasterUserLogin { get; set; }
    
        /// <summary> 
        /// The display name of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string BroadcasterUserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedTrainParticipants object.
        /// </summary> 
        public static TwitchSharedTrainParticipants FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedTrainParticipants
            {
                BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
            var sharedTrainParticipantsClass = script.Get("SharedTrainParticipants").AsGodotObject();
            var request = sharedTrainParticipantsClass.Call("new").AsGodotObject();
            request.Set("broadcaster_user_id", BroadcasterUserId);
            request.Set("broadcaster_user_login", BroadcasterUserLogin);
            request.Set("broadcaster_user_name", BroadcasterUserName);
            return request;
        }
    }

    public partial class TwitchIsSharedTrain : RefCounted, ITwitcherSharpEventSub<TwitchIsSharedTrain>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchIsSharedTrain object.
        /// </summary> 
        public static TwitchIsSharedTrain FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchIsSharedTrain
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd");
            var isSharedTrainClass = script.Get("IsSharedTrain").AsGodotObject();
            var request = isSharedTrainClass.Call("new").AsGodotObject();
            return request;
        }
    }
}
