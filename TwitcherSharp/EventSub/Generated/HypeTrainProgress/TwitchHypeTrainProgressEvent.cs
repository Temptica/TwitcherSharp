using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.HypeTrainProgress;

public partial class TwitchHypeTrainProgressEvent : RefCounted, ITwitcherSharpEventSub<TwitchHypeTrainProgressEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The Hype Train ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

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
    public TwitchTopContributions? TopContributions { get => field ??= _data.Get<TwitchTopContributions>("top_contributions"); set; }

    /// <summary> 
    /// The ID of the user that made the contribution.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The type of the Hype Train. Possible values are: treasure golden_kapparegular
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// The current level of the Hype Train.
    /// </summary>
    public int Level { get; set; }

    /// <summary> 
    /// Optional. Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    /// </summary>
    public TwitchSharedTrainParticipants[]? SharedTrainParticipants { get => field ??= _data.GetArray<TwitchSharedTrainParticipants>("shared_train_participants"); set; }

    /// <summary> 
    /// The time when the Hype Train started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train expires. The expiration is extended when the Hype Train reaches a new level.
    /// </summary>
    public string? ExpiresAt { get; set; }

    /// <summary> 
    /// Indicates if the Hype Train is shared. When true, shared_train_participants will contain the list of broadcasters the train is shared with.
    /// </summary>
    public bool IsSharedTrain { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainProgressEvent object.
    /// </summary> 
    public static TwitchHypeTrainProgressEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchHypeTrainProgressEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Total = data.Read("total", static v => v.AsInt32()),
            Progress = data.Read("progress", static v => v.AsInt32()),
            Goal = data.Read("goal", static v => v.AsInt32()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            Level = data.Read("level", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            ExpiresAt = data.Read("expires_at", static v => v.AsString()),
            IsSharedTrain = data.Read("is_shared_train", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_progress.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        request.SetValue("total", Total);
        request.SetValue("progress", Progress);
        request.SetValue("goal", Goal);
        if(TopContributions != null) request.SetObject("top_contributions", TopContributions);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Type != null) request.SetValue("type", Type);
        request.SetValue("level", Level);
        if(SharedTrainParticipants != null) request.SetArray("shared_train_participants", SharedTrainParticipants);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
        request.SetValue("is_shared_train", IsSharedTrain);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchSharedTrainParticipants : RefCounted, ITwitcherSharpEventSub<TwitchSharedTrainParticipants>
    {
        private Variant _data;
        
        /// <summary> 
        /// The ID of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string? BroadcasterUserId { get; set; }
    
        /// <summary> 
        /// The login of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string? BroadcasterUserLogin { get; set; }
    
        /// <summary> 
        /// The display name of the broadcaster participating in the shared Hype Train.
        /// </summary>
        public string? BroadcasterUserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedTrainParticipants object.
        /// </summary> 
        public static TwitchSharedTrainParticipants? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSharedTrainParticipants
            {
                BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
                BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
                BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_progress.gd", "SharedTrainParticipants");
            if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
            if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
            if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
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
