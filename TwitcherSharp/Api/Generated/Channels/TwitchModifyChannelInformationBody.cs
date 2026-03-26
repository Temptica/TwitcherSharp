using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchModifyChannelInformationBody : RefCounted, ITwitcherSharp<TwitchModifyChannelInformationBody>
{
    private GodotObject _data;
    public string GameId { get; set; }
    public string BroadcasterLanguage { get; set; }
    public string Title { get; set; }
    public int? Delay { get; set; }
    public string[] Tags { get; set; }
    public TwitchContentClassificationLabels[] ContentClassificationLabels { get; set; }
    public bool? IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchModifyChannelInformationBody object.
    /// </summary> 
    public static TwitchModifyChannelInformationBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var contentClassificationLabelsArray = data.Get("content_classification_labels").AsGodotArray<GodotObject>();
        return new TwitchModifyChannelInformationBody
        {
            GameId = data.Get("game_id").AsString(),
            BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
            Title = data.Get("title").AsString(),
            Delay = data.Get("delay").AsInt32(),
            Tags = data.Get("tags").AsStringArray(),
            ContentClassificationLabels = contentClassificationLabelsArray.Select(TwitchContentClassificationLabels.FromObject).ToArray(),
            IsBrandedContent = data.Get("is_branded_content").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_modify_channel_information.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(GameId != null) request.Set("game_id", GameId);
        if(BroadcasterLanguage != null) request.Set("broadcaster_language", BroadcasterLanguage);
        if(Title != null) request.Set("title", Title);
        if(Delay.HasValue) request.Set("delay", Delay.Value);
        if(Tags != null) request.Set("tags", Tags);
        request.Set("content_classification_labels", ContentClassificationLabels.Select(x => x.ToGodotObject()).ToArray());
        if(IsBrandedContent.HasValue) request.Set("is_branded_content", IsBrandedContent.Value);
        return request;
    }
    
    /// <summary> 
    /// List of labels that should be set as the Channel’s CCLs. 
    /// </summary>
    public partial class TwitchContentClassificationLabels : RefCounted, ITwitcherSharp<TwitchContentClassificationLabels>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public bool IsEnabled { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchContentClassificationLabels object.
        /// </summary> 
        public static TwitchContentClassificationLabels FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchContentClassificationLabels
            {
                Id = data.Get("id").AsString(),
                IsEnabled = data.Get("is_enabled").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_content_classification_labels.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("is_enabled", IsEnabled);
            return request;
        }
    
    }

}
