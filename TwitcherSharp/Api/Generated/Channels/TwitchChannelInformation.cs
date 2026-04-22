using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchChannelInformation : RefCounted, ITwitcherSharp<TwitchChannelInformation>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string BroadcasterLogin { get; set; }
    public string BroadcasterName { get; set; }
    public string BroadcasterLanguage { get; set; }
    public string GameName { get; set; }
    public string GameId { get; set; }
    public string Title { get; set; }
    public int Delay { get; set; }
    public string[] Tags { get; set; }
    public string[] ContentClassificationLabels { get; set; }
    public bool IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelInformation object.
    /// </summary> 
    public static TwitchChannelInformation FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelInformation
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
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_information.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("broadcaster_name", BroadcasterName);
        request.Set("broadcaster_language", BroadcasterLanguage);
        request.Set("game_name", GameName);
        request.Set("game_id", GameId);
        request.Set("title", Title);
        request.Set("delay", Delay);
        if(Tags != null) request.Set("tags", new Godot.Collections.Array<string>(Tags));
        if(ContentClassificationLabels != null) request.Set("content_classification_labels", new Godot.Collections.Array<string>(ContentClassificationLabels));
        request.Set("is_branded_content", IsBrandedContent);
        return request;
    }

}
