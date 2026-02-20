using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchEventSubSubscription : Resource, ITwitcherSharp<TwitchEventSubSubscription>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public Variant Condition { get; set; }
    public string CreatedAt { get; set; }
    public TwitchTransport Transport { get; set; }
    public int Cost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEventSubSubscription object.
    /// </summary> 
    public static TwitchEventSubSubscription FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchEventSubSubscription
        {
            Id = data.Get("id").AsString(),
            Status = data.Get("status").AsString(),
            Type = data.Get("type").AsString(),
            Version = data.Get("version").AsString(),
            Condition = data.Get("condition").As<Variant>(),
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
        request.Set("condition", Condition);
        request.Set("created_at", CreatedAt);
        request.Set("transport", Transport);
        request.Set("cost", Cost);
        return request;
    }
    
    /// <summary> 
    /// The transport details used to send the notifications. 
    /// </summary>
    public partial class TwitchTransport : Resource, ITwitcherSharp<TwitchTransport>
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
