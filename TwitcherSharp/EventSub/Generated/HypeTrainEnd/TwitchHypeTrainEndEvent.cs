using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.HypeTrainEnd;

public partial class TwitchHypeTrainEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchHypeTrainEndEvent>
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
    /// The contributors with the most points contributed.
    /// </summary>
    public TwitchTopContributions[]? TopContributions { get => field ??= _data.GetArray<TwitchTopContributions>("top_contributions"); set; }

    /// <summary> 
    /// The current level of the Hype Train.
    /// </summary>
    public int Level { get; set; }

    /// <summary> 
    /// Non-null for a shared Hype Train. Contains the list of broadcasters in the shared Hype Train.
    /// </summary>
    public TwitchSharedTrainParticipants[]? SharedTrainParticipants { get => field ??= _data.GetArray<TwitchSharedTrainParticipants>("shared_train_participants"); set; }

    /// <summary> 
    /// The time when the Hype Train started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train cooldown ends so that the next Hype Train can start.
    /// </summary>
    public string? CooldownEndsAt { get; set; }

    /// <summary> 
    /// The time when the Hype Train ended.
    /// </summary>
    public string? EndedAt { get; set; }

    /// <summary> 
    /// The type of the Hype Train. Possible values: - `treasure` - `golden_kappa` - `regular`
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// Indicates if the Hype Train is shared. When true, `shared_train_participants` will contain the list of broadcasters the train is shared with.
    /// </summary>
    public bool IsSharedTrain { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchHypeTrainEndEvent object.
    /// </summary> 
    public static TwitchHypeTrainEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchHypeTrainEndEvent
        {
            Id = data.ReadAsString("id"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            Total = data.ReadAsInt32("total"),
            Level = data.ReadAsInt32("level"),
            StartedAt = data.ReadAsString("started_at"),
            CooldownEndsAt = data.ReadAsString("cooldown_ends_at"),
            EndedAt = data.ReadAsString("ended_at"),
            Type = data.ReadAsString("type"),
            IsSharedTrain = data.ReadAsBool("is_shared_train"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        request.SetValue("total", Total);
        if(TopContributions != null) request.SetArray("top_contributions", TopContributions);
        request.SetValue("level", Level);
        if(SharedTrainParticipants != null) request.SetArray("shared_train_participants", SharedTrainParticipants);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(CooldownEndsAt != null) request.SetValue("cooldown_ends_at", CooldownEndsAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
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
                BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
                BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
                BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_hype_train_end.gd", "SharedTrainParticipants");
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
