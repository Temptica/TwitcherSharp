using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchChannelInformation : RefCounted, ITwitcherSharp<TwitchChannelInformation>
{
    private Variant _data;
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
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            BroadcasterLanguage = data.Read("broadcaster_language", static v => v.AsString()),
            GameName = data.Read("game_name", static v => v.AsString()),
            GameId = data.Read("game_id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Delay = data.Read("delay", static v => v.AsInt32()),
            Tags = data.Read("tags", static v => v.AsStringArray()),
            ContentClassificationLabels = data.Read("content_classification_labels", static v => v.AsStringArray()),
            IsBrandedContent = data.Read("is_branded_content", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_channel_information.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(BroadcasterLanguage != null) request.SetValue("broadcaster_language", BroadcasterLanguage);
        if(GameName != null) request.SetValue("game_name", GameName);
        if(GameId != null) request.SetValue("game_id", GameId);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("delay", Delay);
        if(Tags != null) request.SetValue("tags", new Godot.Collections.Array<string>(Tags));
        if(ContentClassificationLabels != null) request.SetValue("content_classification_labels", new Godot.Collections.Array<string>(ContentClassificationLabels));
        request.SetValue("is_branded_content", IsBrandedContent);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
