using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchGetConduitShardsResponse : RefCounted, ITwitcherSharp<TwitchGetConduitShardsResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetConduitShardsResponse object.
    /// </summary> 
    public static TwitchGetConduitShardsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetConduitShardsResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetConduitShardsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetConduitShardsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject _data;
        public string Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/response_pagination.gd");
            var paginationClass = script.Get("Pagination").AsGodotObject();
            var request = paginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    
    /// <summary> 
    /// List of information about a conduit's shards. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Status { get; set; }
        public TwitchTransport Transport { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                Id = data.Get("id").AsString(),
                Status = data.Get("status").AsString(),
                Transport = data.Get("transport").As<TwitchTransport>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("status", Status);
            request.Set("transport", Transport);
            return request;
        }
        
        /// <summary> 
        /// The transport details used to send the notifications. 
        /// </summary>
        public partial class TwitchTransport : RefCounted, ITwitcherSharp<TwitchTransport>
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

}
