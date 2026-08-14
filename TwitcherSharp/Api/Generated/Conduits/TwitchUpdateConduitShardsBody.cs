using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsBody : RefCounted, ITwitcherSharp<TwitchUpdateConduitShardsBody>
{
    private GodotObject? _data;
    public string? ConduitId { get; set; }
    public TwitchBodyShards[]? Shards { get => field ??= _data?.GetArray<TwitchBodyShards>("shards"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsBody object.
    /// </summary> 
    public static TwitchUpdateConduitShardsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateConduitShardsBody
        {
            ConduitId = data.Get("conduit_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(ConduitId != null) request.Set("conduit_id", ConduitId);
        if(Shards != null) request.Set("shards", Shards.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// List of shards to update. 
    /// </summary>
    public partial class TwitchBodyShards : RefCounted, ITwitcherSharp<TwitchBodyShards>
    {
        private GodotObject? _data;
        public string? Id { get; set; }
        public TwitchBodyTransport? Transport { get => field ??= _data?.Get<TwitchBodyTransport>("transport"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyShards object.
        /// </summary> 
        public static TwitchBodyShards? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyShards
            {
                Id = data.Get("id").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
            var twitchBodyShardsClass = script.Get("BodyShards").AsGodotObject();
            var request = twitchBodyShardsClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(Transport != null) request.Set("transport", Transport.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The transport details that you want Twitch to use when sending you notifications. 
        /// </summary>
        public partial class TwitchBodyTransport : RefCounted, ITwitcherSharp<TwitchBodyTransport>
        {
            private GodotObject? _data;
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
                    Method = data.Get("method").AsString(),
                    Callback = data.Get("callback").AsString(),
                    Secret = data.Get("secret").AsString(),
                    SessionId = data.Get("session_id").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
                var twitchBodyTransportClass = script.Get("BodyTransport").AsGodotObject();
                var request = twitchBodyTransportClass.Call("new").AsGodotObject();
                if(Method != null) request.Set("method", Method);
                if(Callback != null) request.Set("callback", Callback);
                if(Secret != null) request.Set("secret", Secret);
                if(SessionId != null) request.Set("session_id", SessionId);
                return request;
            }
        
        }
    
    }

}
