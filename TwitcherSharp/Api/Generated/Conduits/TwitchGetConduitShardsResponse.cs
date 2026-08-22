using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchGetConduitShardsResponse : RefCounted, ITwitcherSharp<TwitchGetConduitShardsResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetConduitShardsResponse object.
    /// </summary> 
    public static TwitchGetConduitShardsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetConduitShardsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetConduitShardsResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetConduitShardsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject? _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    
    /// <summary> 
    /// List of information about a conduit's shards. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string Id { get; set; } = null!;
        public string Status { get; set; } = null!;
        public TwitchResponseTransport Transport { get => field ??= _data?.Get<TwitchResponseTransport>("transport")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                Status = data.Get("status").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(Status != null) request.Set("status", Status);
            if(Transport != null) request.Set("transport", Transport.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// The transport details used to send the notifications. 
        /// </summary>
        public partial class TwitchResponseTransport : RefCounted, ITwitcherSharp<TwitchResponseTransport>
        {
            private GodotObject? _data;
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
                    Method = data.Get("method").AsString(),
                    Callback = data.Get("callback").AsString(),
                    SessionId = data.Get("session_id").AsString(),
                    ConnectedAt = data.Get("connected_at").AsString(),
                    DisconnectedAt = data.Get("disconnected_at").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
                var twitchResponseTransportClass = script.Get("ResponseTransport").AsGodotObject();
                var request = twitchResponseTransportClass.Call("new").AsGodotObject();
                if(Method != null) request.Set("method", Method);
                if(Callback != null) request.Set("callback", Callback);
                if(SessionId != null) request.Set("session_id", SessionId);
                if(ConnectedAt != null) request.Set("connected_at", ConnectedAt);
                if(DisconnectedAt != null) request.Set("disconnected_at", DisconnectedAt);
                return request;
            }
        
        }
    
    }

}
