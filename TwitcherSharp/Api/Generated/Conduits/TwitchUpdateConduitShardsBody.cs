using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsBody : RefCounted, ITwitcherSharp<TwitchUpdateConduitShardsBody>
{
    private GodotObject _data;
    public string ConduitId { get; set; }
    public TwitchShards[] Shards { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsBody object.
    /// </summary> 
    public static TwitchUpdateConduitShardsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var shardsArray = data.Get("shards").AsGodotArray<GodotObject>();
        return new TwitchUpdateConduitShardsBody
        {
            ConduitId = data.Get("conduit_id").AsString(),
            Shards = shardsArray.Select(TwitchShards.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("conduit_id", ConduitId);
        request.Set("shards", Shards.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    
    /// <summary> 
    /// List of shards to update. 
    /// </summary>
    public partial class TwitchShards : RefCounted, ITwitcherSharp<TwitchShards>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public TwitchTransport Transport { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchShards object.
        /// </summary> 
        public static TwitchShards FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchShards
            {
                Id = data.Get("id").AsString(),
                Transport = data.Get("transport").As<TwitchTransport>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_shards.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("transport", Transport);
            return request;
        }
        
        /// <summary> 
        /// The transport details that you want Twitch to use when sending you notifications. 
        /// </summary>
        public partial class TwitchTransport : RefCounted, ITwitcherSharp<TwitchTransport>
        {
            private GodotObject _data;
            public string Method { get; set; }
            public string Callback { get; set; }
            public string Secret { get; set; }
            public string SessionId { get; set; }
        
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
                    Secret = data.Get("secret").AsString(),
                    SessionId = data.Get("session_id").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_transport.gd");
                var request = script.Call("new").AsGodotObject();
                if(Method != null) request.Set("method", Method);
                if(Callback != null) request.Set("callback", Callback);
                if(Secret != null) request.Set("secret", Secret);
                if(SessionId != null) request.Set("session_id", SessionId);
                return request;
            }
        
        }
    
    }

}
