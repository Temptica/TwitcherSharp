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
    /// Total points contributed to the Hype Train.
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
    /// The contributors with the most points contributed.
    /// </summary>
    public TwitchTopContributions[]? TopContributions { get => field ??= _data.GetArray<TwitchTopContributions>("top_contributions"); set; }

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
    /// The type of the Hype Train. Possible values are: treasure golden_kapparegular
    /// </summary>
    public string? Type { get; set; }

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
            Level = data.Read("level", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            ExpiresAt = data.Read("expires_at", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
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
        if(TopContributions != null) request.SetArray("top_contributions", TopContributions);
        request.SetValue("level", Level);
        if(SharedTrainParticipants != null) request.SetArray("shared_train_participants", SharedTrainParticipants);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
        if(Type != null) request.SetValue("type", Type);
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
