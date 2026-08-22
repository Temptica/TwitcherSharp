using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchEventSubSubscription<T> : RefCounted, ITwitcherSharp<TwitchEventSubSubscription<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Version { get; set; } = null!;
    public ITwitcherSharpCondition<T> Condition { get => field ??= T.FromDictionary(_data?.Get("condition").AsGodotDictionary()!); set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public TwitchTransport Transport { get => field ??= _data?.Get<TwitchTransport>("transport")!; set; } = null!;
    public int Cost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventSubSubscription object.
    /// </summary> 
    public static TwitchEventSubSubscription<T>? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEventSubSubscription<T>
        {
            Id = data.Get("id").AsString(),
            Status = data.Get("status").AsString(),
            Type = data.Get("type").AsString(),
            Version = data.Get("version").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            Cost = data.Get("cost").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_sub_subscription.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Status != null) request.Set("status", Status);
        if(Type != null) request.Set("type", Type);
        if(Version != null) request.Set("version", Version);
        if(Condition != null) request.Set("condition", new Godot.Collections.Dictionary<string,Variant>(Condition.ToDictionary()));
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        if(Transport != null) request.Set("transport", Transport.ToGodotObject());
        request.Set("cost", Cost);
        return request;
    }
    
    /// <summary> 
    /// The transport details used to send the notifications. 
    /// </summary>
    public partial class TwitchTransport : RefCounted, ITwitcherSharp<TwitchTransport>
    {
        private GodotObject? _data;
        public string Method { get; set; } = null!;
        public string? Callback { get; set; }
        public string? SessionId { get; set; }
        public string? ConnectedAt { get; set; }
        public string? DisconnectedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTransport object.
        /// </summary> 
        public static TwitchTransport? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTransport
            {
                Method = data.Get("method").AsString(),
                Callback = data.Get("callback").AsString(),
                SessionId = data.Get("session_id").AsString(),
                ConnectedAt = data.Get("connected_at").AsString(),
                DisconnectedAt = data.Get("disconnected_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_sub_subscription.gd");
            var twitchTransportClass = script.Get("Transport").AsGodotObject();
            var request = twitchTransportClass.Call("new").AsGodotObject();
            if(Method != null) request.Set("method", Method);
            if(Callback != null) request.Set("callback", Callback);
            if(SessionId != null) request.Set("session_id", SessionId);
            if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
            if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
            return request;
        }
    
    }

}
