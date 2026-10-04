using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchCreateEventSubSubscriptionBody<T> : RefCounted, ITwitcherSharp<TwitchCreateEventSubSubscriptionBody<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private Variant _data;
    public string Type { get; set; } = null!;
    public string Version { get; set; } = null!;
    public ITwitcherSharpCondition<T> Condition { get => field ??= T.FromDictionary(_data.Read("condition", static v => v.AsGodotDictionary())!); set; } = null!;
    public TwitchBodyTransport Transport { get => field ??= _data.Get<TwitchBodyTransport>("transport")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionBody object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionBody<T>? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateEventSubSubscriptionBody<T>
        {
            Type = data.Read("type", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd", "Body");
        if(Type != null) request.SetValue("type", Type);
        if(Version != null) request.SetValue("version", Version);
        if(Condition != null) request.SetValue("condition", new Godot.Collections.Dictionary<string,Variant>(Condition.ToDictionary()));
        if(Transport != null) request.SetObject("transport", Transport);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The transport details that you want Twitch to use when sending you notifications. 
    /// </summary>
    public partial class TwitchBodyTransport : RefCounted, ITwitcherSharp<TwitchBodyTransport>
    {
        private Variant _data;
        public string Method { get; set; } = null!;
        public string? Callback { get; set; }
        public string? Secret { get; set; }
        public string? SessionId { get; set; }
        public string? ConduitId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyTransport object.
        /// </summary> 
        public static TwitchBodyTransport? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyTransport
            {
                Method = data.Read("method", static v => v.AsString()),
                Callback = data.Read("callback", static v => v.AsString()),
                Secret = data.Read("secret", static v => v.AsString()),
                SessionId = data.Read("session_id", static v => v.AsString()),
                ConduitId = data.Read("conduit_id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd", "BodyTransport");
            if(Method != null) request.SetValue("method", Method);
            if(Callback != null) request.SetValue("callback", Callback);
            if(Secret != null) request.SetValue("secret", Secret);
            if(SessionId != null) request.SetValue("session_id", SessionId);
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
