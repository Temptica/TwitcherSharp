using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchGetConduitShardsResponse : RefCounted, ITwitcherSharp<TwitchGetConduitShardsResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetConduitShardsResponse object.
    /// </summary> 
    public static TwitchGetConduitShardsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetConduitShardsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_conduit_shards.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public async Task<TwitchGetConduitShardsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetConduitShardsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private Variant _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Read("cursor", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_conduit_shards.gd", "ResponsePagination");
            if(Cursor != null) request.SetValue("cursor", Cursor);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }
    
    /// <summary> 
    /// List of information about a conduit's shards. 
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_conduit_shards.gd", "ResponseData");
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_conduit_shards.gd", "ResponseTransport");
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

}
