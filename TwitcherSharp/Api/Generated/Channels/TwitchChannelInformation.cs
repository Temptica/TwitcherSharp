using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchChannelInformation : RefCounted, ITwitcherSharp<TwitchChannelInformation>
{
    private GodotObject? _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string BroadcasterLanguage { get; set; } = null!;
    public string GameName { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Delay { get; set; }
    public string[] Tags { get; set; } = null!;
    public string[] ContentClassificationLabels { get; set; } = null!;
    public bool IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelInformation object.
    /// </summary> 
    public static TwitchChannelInformation? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelInformation
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
            GameName = data.Get("game_name").AsString(),
            GameId = data.Get("game_id").AsString(),
            Title = data.Get("title").AsString(),
            Delay = data.Get("delay").AsInt32(),
            Tags = data.Get("tags").AsStringArray(),
            ContentClassificationLabels = data.Get("content_classification_labels").AsStringArray(),
            IsBrandedContent = data.Get("is_branded_content").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_information.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(BroadcasterLanguage != null) request.Set("broadcaster_language", BroadcasterLanguage);
        if(GameName != null) request.Set("game_name", GameName);
        if(GameId != null) request.Set("game_id", GameId);
        if(Title != null) request.Set("title", Title);
        request.Set("delay", Delay);
        if(Tags != null) request.Set("tags", new Godot.Collections.Array<string>(Tags));
        if(ContentClassificationLabels != null) request.Set("content_classification_labels", new Godot.Collections.Array<string>(ContentClassificationLabels));
        request.Set("is_branded_content", IsBrandedContent);
        return request;
    }

}
