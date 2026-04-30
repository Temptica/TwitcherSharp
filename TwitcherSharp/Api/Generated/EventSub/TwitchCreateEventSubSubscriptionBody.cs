using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchCreateEventSubSubscriptionBody<T> : RefCounted, ITwitcherSharp<TwitchCreateEventSubSubscriptionBody<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private GodotObject _data;
    public string Type { get; set; }
    public string Version { get; set; }
    public ITwitcherSharpCondition<T> Condition { get; set; }
    public TwitchBodyTransport Transport { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionBody object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionBody<T> FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCreateEventSubSubscriptionBody<T>
        {
            Type = data.Get("type").AsString(),
            Version = data.Get("version").AsString(),
            Condition = T.FromDictionary(data.Get("condition").AsGodotDictionary()),
            Transport = data.Get("transport").As<TwitchBodyTransport>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("type", Type);
        request.Set("version", Version);
        if(Condition != null) request.Set("condition", new Godot.Collections.Dictionary<string,Variant>(Condition.ToDictionary()));
        request.Set("transport", Transport?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The transport details that you want Twitch to use when sending you notifications. 
    /// </summary>
    public partial class TwitchBodyTransport : RefCounted, ITwitcherSharp<TwitchBodyTransport>
    {
        private GodotObject _data;
        public string Method { get; set; }
        public string Callback { get; set; }
        public string Secret { get; set; }
        public string SessionId { get; set; }
        public string ConduitId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyTransport object.
        /// </summary> 
        public static TwitchBodyTransport FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchBodyTransport
            {
                Method = data.Get("method").AsString(),
                Callback = data.Get("callback").AsString(),
                Secret = data.Get("secret").AsString(),
                SessionId = data.Get("session_id").AsString(),
                ConduitId = data.Get("conduit_id").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd");
            var twitchBodyTransportClass = script.Get("BodyTransport").AsGodotObject();
            var request = twitchBodyTransportClass.Call("new").AsGodotObject();
            request.Set("method", Method);
            if(Callback != null) request.Set("callback", Callback);
            if(Secret != null) request.Set("secret", Secret);
            if(SessionId != null) request.Set("session_id", SessionId);
            if(ConduitId != null) request.Set("conduit_id", ConduitId);
            return request;
        }
    
    }

}
