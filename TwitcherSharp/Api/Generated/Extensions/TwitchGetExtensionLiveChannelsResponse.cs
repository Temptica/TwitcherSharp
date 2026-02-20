using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionLiveChannelsResponse : Resource, ITwitcherSharp<TwitchGetExtensionLiveChannelsResponse>
{
    private GodotObject _data;
    public TwitchExtensionLiveChannel[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

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
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_live_channels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public partial class TwitchExtensionLiveChannel : Resource, ITwitcherSharp<TwitchExtensionLiveChannel>
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
