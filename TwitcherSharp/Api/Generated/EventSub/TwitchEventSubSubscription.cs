using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchEventSubSubscription<T> : RefCounted, ITwitcherSharp<TwitchEventSubSubscription<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Version { get; set; } = null!;
    public ITwitcherSharpCondition<T> Condition { get => field ??= T.FromDictionary(_data.Read("condition", static v => v.AsGodotDictionary())!); set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public TwitchTransport Transport { get => field ??= _data.Get<TwitchTransport>("transport")!; set; } = null!;
    public int Cost { get; set; }
    public bool? IsBatchingEnabled { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventSubSubscription object.
    /// </summary> 
    public static TwitchEventSubSubscription<T>? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEventSubSubscription<T>
        {
            Id = data.ReadAsString("id"),
            Status = data.ReadAsString("status"),
            Type = data.ReadAsString("type"),
            Version = data.ReadAsString("version"),
            CreatedAt = data.ReadAsString("created_at"),
            Cost = data.ReadAsInt32("cost"),
            IsBatchingEnabled = data.ReadAsBool("is_batching_enabled"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_event_sub_subscription.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Status != null) request.SetValue("status", Status);
        if(Type != null) request.SetValue("type", Type);
        if(Version != null) request.SetValue("version", Version);
        if(Condition != null) request.SetValue("condition", new Godot.Collections.Dictionary<string,Variant>(Condition.ToDictionary()));
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(Transport != null) request.SetObject("transport", Transport);
        request.SetValue("cost", Cost);
        if(IsBatchingEnabled.HasValue) request.SetValue("is_batching_enabled", IsBatchingEnabled.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The transport details used to send the notifications. 
    /// </summary>
    public partial class TwitchTransport : RefCounted, ITwitcherSharp<TwitchTransport>
    {
        private Variant _data;
        public string Method { get; set; } = null!;
        public string? Callback { get; set; }
        public string? SessionId { get; set; }
        public string? ConnectedAt { get; set; }
        public string? ConduitId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTransport object.
        /// </summary> 
        public static TwitchTransport? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTransport
            {
                Method = data.ReadAsString("method"),
                Callback = data.ReadAsString("callback"),
                SessionId = data.ReadAsString("session_id"),
                ConnectedAt = data.ReadAsString("connected_at"),
                ConduitId = data.ReadAsString("conduit_id"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_event_sub_subscription.gd", "Transport");
            if(Method != null) request.SetValue("method", Method);
            if(Callback != null) request.SetValue("callback", Callback);
            if(SessionId != null) request.SetValue("session_id", SessionId);
            if(ConnectedAt != null) request.SetValue("connected_at", ConnectedAt);
            if(ConduitId != null) request.SetValue("conduit_id", ConduitId);
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
