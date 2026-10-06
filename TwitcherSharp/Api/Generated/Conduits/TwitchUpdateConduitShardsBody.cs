using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsBody : RefCounted, ITwitcherSharp<TwitchUpdateConduitShardsBody>
{
    private Variant _data;
    public string ConduitId { get; set; } = null!;
    public TwitchBodyShards[] Shards { get => field ??= _data.GetArray<TwitchBodyShards>("shards")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsBody object.
    /// </summary> 
    public static TwitchUpdateConduitShardsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateConduitShardsBody
        {
            ConduitId = data.Read("conduit_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "Body");
        if(ConduitId != null) request.SetValue("conduit_id", ConduitId);
        if(Shards != null) request.SetArray("shards", Shards);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// List of shards to update. 
    /// </summary>
    public partial class TwitchBodyShards : RefCounted, ITwitcherSharp<TwitchBodyShards>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public TwitchBodyTransport Transport { get => field ??= _data.Get<TwitchBodyTransport>("transport")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyShards object.
        /// </summary> 
        public static TwitchBodyShards? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyShards
            {
                Id = data.Read("id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "BodyShards");
            if(Id != null) request.SetValue("id", Id);
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
            public string? Method { get; set; }
            public string? Callback { get; set; }
            public string? Secret { get; set; }
            public string? SessionId { get; set; }
        
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
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "BodyTransport");
                if(Method != null) request.SetValue("method", Method);
                if(Callback != null) request.SetValue("callback", Callback);
                if(Secret != null) request.SetValue("secret", Secret);
                if(SessionId != null) request.SetValue("session_id", SessionId);
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

}
