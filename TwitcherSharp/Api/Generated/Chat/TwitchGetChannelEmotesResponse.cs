using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChannelEmotesResponse : Resource, ITwitcherSharp<TwitchGetChannelEmotesResponse>
{
    private GodotObject _data;
    public TwitchChannelEmote[] Data { get; set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelEmotesResponse object.
    /// </summary> 
    public static TwitchGetChannelEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelEmotesResponse
        {
            Data = dataArray.Select(TwitchChannelEmote.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        request.Set("template", Template);
        return request;
    }
    public partial class TwitchChannelEmote : Resource, ITwitcherSharp<TwitchChannelEmote>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Name { get; set; }
        public TwitchImages Images { get; set; }
        public string Tier { get; set; }
        public string EmoteType { get; set; }
        public string EmoteSetId { get; set; }
        public string[] Format { get; set; }
        public string[] Scale { get; set; }
        public string[] ThemeMode { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchChannelEmote object.
        /// </summary> 
        public static TwitchChannelEmote FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchChannelEmote
            {
                Id = data.Get("id").AsString(),
                Name = data.Get("name").AsString(),
                Images = data.Get("images").As<TwitchImages>(),
                Tier = data.Get("tier").AsString(),
                EmoteType = data.Get("emote_type").AsString(),
                EmoteSetId = data.Get("emote_set_id").AsString(),
                Format = data.Get("format").AsStringArray(),
                Scale = data.Get("scale").AsStringArray(),
                ThemeMode = data.Get("theme_mode").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_emote.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("name", Name);
            request.Set("images", Images);
            request.Set("tier", Tier);
            request.Set("emote_type", EmoteType);
            request.Set("emote_set_id", EmoteSetId);
            request.Set("format", Format);
            request.Set("scale", Scale);
            request.Set("theme_mode", ThemeMode);
            return request;
        }
        
        /// <summary> 
        /// The image URLs for the emote. These image URLs always provide a static, non-animated emote image with a light background.  
        ///   
        /// **NOTE:** You should use the templated URL in the `template` field to fetch the image instead of using these URLs. 
        /// </summary>
        public partial class TwitchImages : Resource, ITwitcherSharp<TwitchImages>
        {
            private GodotObject _data;
            public string Url1x { get; set; }
            public string Url2x { get; set; }
            public string Url4x { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchImages object.
            /// </summary> 
            public static TwitchImages FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchImages
                {
                    Url1x = data.Get("url_1x").AsString(),
                    Url2x = data.Get("url_2x").AsString(),
                    Url4x = data.Get("url_4x").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_images.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("url_1x", Url1x);
                request.Set("url_2x", Url2x);
                request.Set("url_4x", Url4x);
                return request;
            }
        
        }
    
    }

}
