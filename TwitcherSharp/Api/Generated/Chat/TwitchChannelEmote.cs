using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChannelEmote : RefCounted, ITwitcherSharp<TwitchChannelEmote>, ITwitchEmote
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ITwitchImages Images { get => field ??= _data.Get<TwitchResponseImages>("images")!; set; } = null!;
    public string Tier { get; set; } = null!;
    public string EmoteType { get; set; } = null!;
    public string EmoteSetId { get; set; } = null!;
    public string[] Format { get; set; } = null!;
    public string[] Scale { get; set; } = null!;
    public string[] ThemeMode { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelEmote object.
    /// </summary> 
    public static TwitchChannelEmote? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelEmote
        {
            Id = data.Read("id", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            Tier = data.Read("tier", static v => v.AsString()),
            EmoteType = data.Read("emote_type", static v => v.AsString()),
            EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
            Format = data.Read("format", static v => v.AsStringArray()),
            Scale = data.Read("scale", static v => v.AsStringArray()),
            ThemeMode = data.Read("theme_mode", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_channel_emote.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Name != null) request.SetValue("name", Name);
        if(Images != null) request.SetObject("images", Images);
        if(Tier != null) request.SetValue("tier", Tier);
        if(EmoteType != null) request.SetValue("emote_type", EmoteType);
        if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
        if(Format != null) request.SetValue("format", new Godot.Collections.Array<string>(Format));
        if(Scale != null) request.SetValue("scale", new Godot.Collections.Array<string>(Scale));
        if(ThemeMode != null) request.SetValue("theme_mode", new Godot.Collections.Array<string>(ThemeMode));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The image URLs for the emote. These image URLs always provide a static, non-animated emote image with a light background.  
    ///   
    /// **NOTE:** You should use the templated URL in the `template` field to fetch the image instead of using these URLs. 
    /// </summary>
    public partial class TwitchResponseImages : RefCounted, ITwitcherSharp<TwitchResponseImages>, ITwitchImages
    {
        private Variant _data;
        public string Url1x { get; set; } = null!;
        public string Url2x { get; set; } = null!;
        public string Url4x { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseImages object.
        /// </summary> 
        public static TwitchResponseImages? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseImages
            {
                Url1x = data.Read("url_1x", static v => v.AsString()),
                Url2x = data.Read("url_2x", static v => v.AsString()),
                Url4x = data.Read("url_4x", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_channel_emote.gd", "Images");
            if(Url1x != null) request.SetValue("url_1x", Url1x);
            if(Url2x != null) request.SetValue("url_2x", Url2x);
            if(Url4x != null) request.SetValue("url_4x", Url4x);
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
