using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchModifyChannelInformationBody : RefCounted, ITwitcherSharp<TwitchModifyChannelInformationBody>
{
    private GodotObject? _data;
    public string? GameId { get; set; }
    public string? BroadcasterLanguage { get; set; }
    public string? Title { get; set; }
    public int? Delay { get; set; }
    public string[]? Tags { get; set; }
    public TwitchBodyContentClassificationLabels[]? ContentClassificationLabels { get => field ??= _data?.GetArray<TwitchBodyContentClassificationLabels>("content_classification_labels"); set; }
    public bool? IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchModifyChannelInformationBody object.
    /// </summary> 
    public static TwitchModifyChannelInformationBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchModifyChannelInformationBody
        {
            GameId = data.Get("game_id").AsString(),
            BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
            Title = data.Get("title").AsString(),
            Delay = data.Get("delay").AsInt32(),
            Tags = data.Get("tags").AsStringArray(),
            IsBrandedContent = data.Get("is_branded_content").AsBool(),
        };
        
        instance._data = data;
        return instance;
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
        if(Tags != null) request.Set("tags", new Godot.Collections.Array<string>(Tags));
        if(ContentClassificationLabels != null) request.Set("content_classification_labels", ContentClassificationLabels.ToGodotArray());
        if(IsBrandedContent.HasValue) request.Set("is_branded_content", IsBrandedContent.Value);
        return request;
    }
    
    /// <summary> 
    /// List of labels that should be set as the Channel’s CCLs.  
    /// **Note:** To clear CCLs for a channel, set all `is_enabled` for all possible CCLs to `false` 
    /// </summary>
    public partial class TwitchBodyContentClassificationLabels : RefCounted, ITwitcherSharp<TwitchBodyContentClassificationLabels>
    {
        private GodotObject? _data;
        public string Id { get; set; } = null!;
        public bool IsEnabled { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyContentClassificationLabels object.
        /// </summary> 
        public static TwitchBodyContentClassificationLabels? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyContentClassificationLabels
            {
                Id = data.Get("id").AsString(),
                IsEnabled = data.Get("is_enabled").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_modify_channel_information.gd");
            var twitchBodyContentClassificationLabelsClass = script.Get("BodyContentClassificationLabels").AsGodotObject();
            var request = twitchBodyContentClassificationLabelsClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            request.Set("is_enabled", IsEnabled);
            return request;
        }
    
    }

}
