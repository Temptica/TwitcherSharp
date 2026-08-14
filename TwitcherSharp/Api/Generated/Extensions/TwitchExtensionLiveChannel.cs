using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionLiveChannel : RefCounted, ITwitcherSharp<TwitchExtensionLiveChannel>
{
    private GodotObject? _data;
    public string? BroadcasterId { get; set; }
    public string? BroadcasterName { get; set; }
    public string? GameName { get; set; }
    public string? GameId { get; set; }
    public string? Title { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionLiveChannel object.
    /// </summary> 
    public static TwitchExtensionLiveChannel? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionLiveChannel
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            GameName = data.Get("game_name").AsString(),
            GameId = data.Get("game_id").AsString(),
            Title = data.Get("title").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_live_channel.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(GameName != null) request.Set("game_name", GameName);
        if(GameId != null) request.Set("game_id", GameId);
        if(Title != null) request.Set("title", Title);
        return request;
    }

}
