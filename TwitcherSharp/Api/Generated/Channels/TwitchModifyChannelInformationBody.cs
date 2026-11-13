using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchModifyChannelInformationBody : RefCounted, ITwitcherSharp<TwitchModifyChannelInformationBody>
{
    private Variant _data;
    public string? GameId { get; set; }
    public string? BroadcasterLanguage { get; set; }
    public string? Title { get; set; }
    public int? Delay { get; set; }
    public string[]? Tags { get; set; }
    public TwitchBodyContentClassificationLabels[]? ContentClassificationLabels { get => field ??= _data.GetArray<TwitchBodyContentClassificationLabels>("content_classification_labels"); set; }
    public bool? IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchModifyChannelInformationBody object.
    /// </summary> 
    public static TwitchModifyChannelInformationBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchModifyChannelInformationBody
        {
            GameId = data.ReadAsString("game_id"),
            BroadcasterLanguage = data.ReadAsString("broadcaster_language"),
            Title = data.ReadAsString("title"),
            Delay = data.ReadAsInt32("delay"),
            Tags = data.ReadAsStringArray("tags"),
            IsBrandedContent = data.ReadAsBool("is_branded_content"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_modify_channel_information.gd", "Body");
        if(GameId != null) request.SetValue("game_id", GameId);
        if(BroadcasterLanguage != null) request.SetValue("broadcaster_language", BroadcasterLanguage);
        if(Title != null) request.SetValue("title", Title);
        if(Delay.HasValue) request.SetValue("delay", Delay.Value);
        if(Tags != null) request.SetValue("tags", new Godot.Collections.Array<string>(Tags));
        if(ContentClassificationLabels != null) request.SetArray("content_classification_labels", ContentClassificationLabels);
        if(IsBrandedContent.HasValue) request.SetValue("is_branded_content", IsBrandedContent.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// List of labels that should be set as the Channel’s CCLs.  
    /// **Note:** To clear CCLs for a channel, set all `is_enabled` for all possible CCLs to `false` 
    /// </summary>
    public partial class TwitchBodyContentClassificationLabels : RefCounted, ITwitcherSharp<TwitchBodyContentClassificationLabels>
    {
        private Variant _data;
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
                Id = data.ReadAsString("id"),
                IsEnabled = data.ReadAsBool("is_enabled"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_modify_channel_information.gd", "BodyContentClassificationLabels");
            if(Id != null) request.SetValue("id", Id);
            request.SetValue("is_enabled", IsEnabled);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
