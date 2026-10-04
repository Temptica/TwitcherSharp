using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionLiveChannel : RefCounted, ITwitcherSharp<TwitchExtensionLiveChannel>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string GameName { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string Title { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionLiveChannel object.
    /// </summary> 
    public static TwitchExtensionLiveChannel? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionLiveChannel
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            GameName = data.Read("game_name", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_live_channel.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(GameName != null) request.SetValue("game_name", GameName);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Title != null) request.SetValue("title", Title);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
