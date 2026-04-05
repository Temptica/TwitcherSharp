using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchEventSubSubscription<T> : RefCounted, ITwitcherSharp<TwitchEventSubSubscription<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public ITwitcherSharpCondition<T> Condition { get; set; }
    public string CreatedAt { get; set; }
    public TwitchTransport Transport { get; set; }
    public int Cost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventSubSubscription object.
    /// </summary> 
    public static TwitchEventSubSubscription<T> FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchEventSubSubscription<T>
        {
            Id = data.Get("id").AsString(),
            Status = data.Get("status").AsString(),
            Type = data.Get("type").AsString(),
            Version = data.Get("version").AsString(),
            Condition = T.FromDictionary(data.Get("condition").AsGodotDictionary()),
            CreatedAt = data.Get("created_at").AsString(),
            Transport = data.Get("transport").As<TwitchTransport>(),
            Cost = data.Get("cost").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_event_sub_subscription.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("status", Status);
        request.Set("type", Type);
        request.Set("version", Version);
        request.Set("condition", new Godot.Collections.Dictionary<string,Variant>(Condition.ToDictionary()));
        request.Set("created_at", CreatedAt);
        request.Set("transport", Transport?.ToGodotObject());
        request.Set("cost", Cost);
        return request;
    }
    
    /// <summary> 
    /// The transport details used to send the notifications. 
    /// </summary>
    public partial class TwitchTransport : RefCounted, ITwitcherSharp<TwitchTransport>
    {
        private GodotObject _data;
        public string Method { get; set; }
        public string Callback { get; set; }
        public string SessionId { get; set; }
        public string ConnectedAt { get; set; }
        public string DisconnectedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTransport object.
        /// </summary> 
        public static TwitchTransport FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchTransport
            {
                Method = data.Get("method").AsString(),
                Callback = data.Get("callback").AsString(),
                SessionId = data.Get("session_id").AsString(),
                ConnectedAt = data.Get("connected_at").AsString(),
                DisconnectedAt = data.Get("disconnected_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_transport.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("method", Method);
            if(Callback != null) request.Set("callback", Callback);
            if(SessionId != null) request.Set("session_id", SessionId);
            if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
            if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
            return request;
        }
    
    }

}
