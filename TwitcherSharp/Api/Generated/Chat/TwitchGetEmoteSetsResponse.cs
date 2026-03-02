using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetEmoteSetsResponse : Resource, ITwitcherSharp<TwitchGetEmoteSetsResponse>
{
    private GodotObject _data;
    public TwitchEmote[] Data { get; set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEmoteSetsResponse object.
    /// </summary> 
    public static TwitchGetEmoteSetsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetEmoteSetsResponse
        {
            Data = dataArray.Select(TwitchEmote.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_emote_sets.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        request.Set("template", Template);
        return request;
    }
    public partial class TwitchEmote : Resource, ITwitcherSharp<TwitchEmote>, ITwitchEmote
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Name { get; set; }
        public TwitchImages Images { get; set; }
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
                Images = data.Get("images").As<TwitchImages>(),
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
            request.Set("images", Images);
            request.Set("emote_type", EmoteType);
            request.Set("emote_set_id", EmoteSetId);
            request.Set("owner_id", OwnerId);
            request.Set("format", Format);
            request.Set("scale", Scale);
            request.Set("theme_mode", ThemeMode);
            return request;
        }
    
    }

}
