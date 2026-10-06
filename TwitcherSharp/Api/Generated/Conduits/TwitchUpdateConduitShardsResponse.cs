using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitShardsResponse : RefCounted, ITwitcherSharp<TwitchUpdateConduitShardsResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public TwitchResponseErrors[] Errors { get => field ??= _data.GetArray<TwitchResponseErrors>("errors")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsResponse object.
    /// </summary> 
    public static TwitchUpdateConduitShardsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateConduitShardsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Errors != null) request.SetArray("errors", Errors);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// List of successful shard updates. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Status { get; set; } = null!;
        public TwitchResponseTransport Transport { get => field ??= _data.Get<TwitchResponseTransport>("transport")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Read("id", static v => v.AsString()),
                Status = data.Read("status", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "ResponseData");
            if(Id != null) request.SetValue("id", Id);
            if(Status != null) request.SetValue("status", Status);
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
        /// The transport details used to send the notifications. 
        /// </summary>
        public partial class TwitchResponseTransport : RefCounted, ITwitcherSharp<TwitchResponseTransport>
        {
            private Variant _data;
            public string Method { get; set; } = null!;
            public string? Callback { get; set; }
            public string? SessionId { get; set; }
            public string? ConnectedAt { get; set; }
            public string? DisconnectedAt { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseTransport object.
            /// </summary> 
            public static TwitchResponseTransport? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseTransport
                {
                    Method = data.Read("method", static v => v.AsString()),
                    Callback = data.Read("callback", static v => v.AsString()),
                    SessionId = data.Read("session_id", static v => v.AsString()),
                    ConnectedAt = data.Read("connected_at", static v => v.AsString()),
                    DisconnectedAt = data.Read("disconnected_at", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "ResponseTransport");
                if(Method != null) request.SetValue("method", Method);
                if(Callback != null) request.SetValue("callback", Callback);
                if(SessionId != null) request.SetValue("session_id", SessionId);
                if(ConnectedAt != null) request.SetValue("connected_at", ConnectedAt);
                if(DisconnectedAt != null) request.SetValue("disconnected_at", DisconnectedAt);
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
    
    /// <summary> 
    /// List of unsuccessful updates. 
    /// </summary>
    public partial class TwitchResponseErrors : RefCounted, ITwitcherSharp<TwitchResponseErrors>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Code { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseErrors object.
        /// </summary> 
        public static TwitchResponseErrors? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseErrors
            {
                Id = data.Read("id", static v => v.AsString()),
                Message = data.Read("message", static v => v.AsString()),
                Code = data.Read("code", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduit_shards.gd", "ResponseErrors");
            if(Id != null) request.SetValue("id", Id);
            if(Message != null) request.SetValue("message", Message);
            if(Code != null) request.SetValue("code", Code);
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
