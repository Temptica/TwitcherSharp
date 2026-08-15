using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.HypeTrainBegin;

public partial class TwitchHypeTrainBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchHypeTrainBeginEvent>
{
    private GodotObject _data;
    
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
    /// The total amount contributed. If type is bits, total represents the amount of Bits used. If type is subscription, total is 500, 1000, or 2500 to represent tier 1, 2, or 3 subscriptions, respectively.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// The number of points contributed to the Hype Train at the current level.
    /// </summary>
    public int Progress { get; set; }

    /// <summary> 
    /// The number of points required to reach the next level.
    /// </summary>
    public int Goal { get; set; }

    /// <summary> 
    /// The top contributor for a contribution type. For example, the top contributor using BITS (by aggregate) or the top contributor using subscriptions (by count).
    /// </summary>
    public TwitchTopContributions[] TopContributions { get => field ??= _data?.GetArray<TwitchTopContributions>("top_contributions"); set; }

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
    /// The type of the Hype Train. Possible values are: treasure golden_kapparegular
    /// </summary>
    public string Type { get; set; }

    /// <summary> 
    /// The current level of the Hype Train.
    /// </summary>
    public int Level { get; set; }

    /// <summary> 
    /// The all-time high level this type of Hype Train has reached for this broadcaster.
    /// </summary>
    public int AllTimeHighLevel { get; set; }

    /// <summary> 
    /// The all-time high total this type of Hype Train has reached for this broadcaster.
    /// </summary>
    public int AllTimeHighTotal { get; set; }

    /// <summary> 
    /// Optional. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    /// </summary>
    public TwitchSharedTrainParticipants[] SharedTrainParticipants { get => field ??= _data?.GetArray<TwitchSharedTrainParticipants>("shared_train_participants"); set; }

    /// <summary> 
    /// The time when the Hype Train started.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
    /// </summary>
    public string ExpiresAt { get; set; }

    /// <summary> 
    /// Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
    /// </summary>
    public bool IsSharedTrain { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainBeginEvent object.
    /// </summary> 
    public static TwitchHypeTrainBeginEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchHypeTrainBeginEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Total = data.Get("total").AsInt32(),
            Progress = data.Get("progress").AsInt32(),
            Goal = data.Get("goal").AsInt32(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Type = data.Get("type").AsString(),
            Level = data.Get("level").AsInt32(),
            AllTimeHighLevel = data.Get("all_time_high_level").AsInt32(),
            AllTimeHighTotal = data.Get("all_time_high_total").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
            ExpiresAt = data.Get("expires_at").AsString(),
            IsSharedTrain = data.Get("is_shared_train").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_begin.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("total", Total);
        request.Set("progress", Progress);
        request.Set("goal", Goal);
        if(TopContributions != null) request.SetArray("top_contributions", TopContributions);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("type", Type);
        request.Set("level", Level);
        request.Set("all_time_high_level", AllTimeHighLevel);
        request.Set("all_time_high_total", AllTimeHighTotal);
        if(SharedTrainParticipants != null) request.SetArray("shared_train_participants", SharedTrainParticipants);
        request.Set("started_at", StartedAt);
        request.Set("expires_at", ExpiresAt);
        request.Set("is_shared_train", IsSharedTrain);
        return request;
    }


    public partial class TwitchSharedTrainParticipants : RefCounted, ITwitcherSharpEventSub<TwitchSharedTrainParticipants>
    {
        private GodotObject _data;
        
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
            var instance = new TwitchSharedTrainParticipants
            {
                BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_begin.gd");
            var sharedTrainParticipantsClass = script.Get("SharedTrainParticipants").As<GDScript>();
            var request = sharedTrainParticipantsClass.New().AsGodotObject();
            request.Set("broadcaster_user_id", BroadcasterUserId);
            request.Set("broadcaster_user_login", BroadcasterUserLogin);
            request.Set("broadcaster_user_name", BroadcasterUserName);
            return request;
        }
    }
}
