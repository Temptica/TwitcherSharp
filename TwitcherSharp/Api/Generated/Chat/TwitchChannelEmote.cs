using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChannelEmote : RefCounted, ITwitcherSharp<TwitchChannelEmote>, ITwitchEmote
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ITwitchImages Images { get => field ??= _data?.Get<TwitchResponseImages>("images")!; set; } = null!;
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
            Id = data.Get("id").AsString(),
            Name = data.Get("name").AsString(),
            Tier = data.Get("tier").AsString(),
            EmoteType = data.Get("emote_type").AsString(),
            EmoteSetId = data.Get("emote_set_id").AsString(),
            Format = data.Get("format").AsStringArray(),
            Scale = data.Get("scale").AsStringArray(),
            ThemeMode = data.Get("theme_mode").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_emote.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Name != null) request.Set("name", Name);
        if(Images != null) request.Set("images", Images.ToGodotObject());
        if(Tier != null) request.Set("tier", Tier);
        if(EmoteType != null) request.Set("emote_type", EmoteType);
        if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
        if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
        if(Scale != null) request.Set("scale", new Godot.Collections.Array<string>(Scale));
        if(ThemeMode != null) request.Set("theme_mode", new Godot.Collections.Array<string>(ThemeMode));
        return request;
    }
    
    /// <summary> 
    /// The image URLs for the emote. These image URLs always provide a static, non-animated emote image with a light background.  
    ///   
    /// **NOTE:** You should use the templated URL in the `template` field to fetch the image instead of using these URLs. 
    /// </summary>
    public partial class TwitchResponseImages : RefCounted, ITwitcherSharp<TwitchResponseImages>, ITwitchImages
    {
        private GodotObject? _data;
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
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_response_images.gd");
            var twitchResponseImagesClass = script.Get("ResponseImages").AsGodotObject();
            var request = twitchResponseImagesClass.Call("new").AsGodotObject();
            if(Url1x != null) request.Set("url_1x", Url1x);
            if(Url2x != null) request.Set("url_2x", Url2x);
            if(Url4x != null) request.Set("url_4x", Url4x);
            return request;
        }
    
    }

}
