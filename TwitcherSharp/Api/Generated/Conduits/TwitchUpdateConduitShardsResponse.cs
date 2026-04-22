using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsResponse : RefCounted, ITwitcherSharp<TwitchUpdateConduitShardsResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }
    public TwitchResponseErrors[] Errors { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsResponse object.
    /// </summary> 
    public static TwitchUpdateConduitShardsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        var errorsArray = data.Get("errors").AsGodotArray<GodotObject>();
        return new TwitchUpdateConduitShardsResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
            Errors = errorsArray.Select(TwitchResponseErrors.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        if(Errors != null) request.Set("errors", Errors?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// List of successful shard updates. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Status { get; set; }
        public TwitchResponseTransport Transport { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                Status = data.Get("status").AsString(),
                Transport = data.Get("transport").As<TwitchResponseTransport>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("status", Status);
            request.Set("transport", Transport?.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The transport details used to send the notifications. 
        /// </summary>
        public partial class TwitchResponseTransport : RefCounted, ITwitcherSharp<TwitchResponseTransport>
        {
            private GodotObject _data;
            public string Method { get; set; }
            public string Callback { get; set; }
            public string SessionId { get; set; }
            public string ConnectedAt { get; set; }
            public string DisconnectedAt { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseTransport object.
            /// </summary> 
            public static TwitchResponseTransport FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchResponseTransport
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
                var twitchResponseTransportClass = script.Get("ResponseTransport").AsGodotObject();
                var request = twitchResponseTransportClass.Call("new").AsGodotObject();
                request.Set("method", Method);
                if(Callback != null) request.Set("callback", Callback);
                if(SessionId != null) request.Set("session_id", SessionId);
                if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
                if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
                return request;
            }
        
        }
    
    }
    
    /// <summary> 
    /// List of unsuccessful updates. 
    /// </summary>
    public partial class TwitchResponseErrors : RefCounted, ITwitcherSharp<TwitchResponseErrors>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseErrors object.
        /// </summary> 
        public static TwitchResponseErrors FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseErrors
            {
                Id = data.Get("id").AsString(),
                Message = data.Get("message").AsString(),
                Code = data.Get("code").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
            var twitchResponseErrorsClass = script.Get("ResponseErrors").AsGodotObject();
            var request = twitchResponseErrorsClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("message", Message);
            request.Set("code", Code);
            return request;
        }
    
    }

}
