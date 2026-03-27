using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionLiveChannelsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionLiveChannelsResponse>
{
    private GodotObject _data;
    public TwitchExtensionLiveChannel[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionLiveChannelsResponse object.
    /// </summary> 
    public static TwitchGetExtensionLiveChannelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetExtensionLiveChannelsResponse
        {
            Data = dataArray.Select(TwitchExtensionLiveChannel.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetExtensionLiveChannelsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetExtensionLiveChannelsResponse>("next_page");
    
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
    public partial class TwitchExtensionLiveChannel : RefCounted, ITwitcherSharp<TwitchExtensionLiveChannel>
    {
        private GodotObject _data;
        public string BroadcasterId { get; set; }
        public string BroadcasterName { get; set; }
        public string GameName { get; set; }
        public string GameId { get; set; }
        public string Title { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchExtensionLiveChannel object.
        /// </summary> 
        public static TwitchExtensionLiveChannel FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchExtensionLiveChannel
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                GameName = data.Get("game_name").AsString(),
                GameId = data.Get("game_id").AsString(),
                Title = data.Get("title").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_live_channel.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("game_name", GameName);
            request.Set("game_id", GameId);
            request.Set("title", Title);
            return request;
        }
    
    }

}
