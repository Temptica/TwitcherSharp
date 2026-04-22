using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchEmote : RefCounted, ITwitcherSharp<TwitchEmote>, ITwitchEmote
{
    private GodotObject _data;
    public string Id { get; set; }
    public string Name { get; set; }
    public ITwitchImages Images { get; set; }
    public string EmoteType { get; set; }
    public string EmoteSetId { get; set; }
    public string OwnerId { get; set; }
    public string[] Format { get; set; }
    public string[] Scale { get; set; }
    public string[] ThemeMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEmote object.
    /// </summary> 
    public static TwitchEmote FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchEmote
        {
            Id = data.Get("id").AsString(),
            Name = data.Get("name").AsString(),
            Images = data.Get("images").As<TwitchResponseImages>(),
            EmoteType = data.Get("emote_type").AsString(),
            EmoteSetId = data.Get("emote_set_id").AsString(),
            OwnerId = data.Get("owner_id").AsString(),
            Format = data.Get("format").AsStringArray(),
            Scale = data.Get("scale").AsStringArray(),
            ThemeMode = data.Get("theme_mode").AsStringArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_emote.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("name", Name);
        request.Set("images", Images?.ToGodotObject());
        request.Set("emote_type", EmoteType);
        request.Set("emote_set_id", EmoteSetId);
        request.Set("owner_id", OwnerId);
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
        private GodotObject _data;
        public string Url1x { get; set; }
        public string Url2x { get; set; }
        public string Url4x { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseImages object.
        /// </summary> 
        public static TwitchResponseImages FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseImages
            {
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_response_images.gd");
            var twitchResponseImagesClass = script.Get("ResponseImages").AsGodotObject();
            var request = twitchResponseImagesClass.Call("new").AsGodotObject();
            request.Set("url_1x", Url1x);
            request.Set("url_2x", Url2x);
            request.Set("url_4x", Url4x);
            return request;
        }
    
    }

}
