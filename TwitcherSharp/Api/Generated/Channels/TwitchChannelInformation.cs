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
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            BroadcasterName = data.ReadAsString("broadcaster_name"),
            BroadcasterLanguage = data.ReadAsString("broadcaster_language"),
            GameName = data.ReadAsString("game_name"),
            GameId = data.ReadAsString("game_id"),
            Title = data.ReadAsString("title"),
            Delay = data.ReadAsInt32("delay"),
            Tags = data.ReadAsStringArray("tags"),
            ContentClassificationLabels = data.ReadAsStringArray("content_classification_labels"),
            IsBrandedContent = data.ReadAsBool("is_branded_content"),
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
