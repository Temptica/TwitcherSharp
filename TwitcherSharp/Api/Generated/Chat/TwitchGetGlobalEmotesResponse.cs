using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetGlobalEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetGlobalEmotesResponse>
{
    private GodotObject _data;
    public TwitchGlobalEmote[] Data { get; set; }
    public string Template { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGlobalEmotesResponse object.
    /// </summary> 
    public static TwitchGetGlobalEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGlobalEmotesResponse
        {
            Data = dataArray.Select(TwitchGlobalEmote.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_global_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        request.Set("template", Template);
        return request;
    }
    public partial class TwitchGlobalEmote : RefCounted, ITwitcherSharp<TwitchGlobalEmote>, ITwitchEmote
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Name { get; set; }
        public TwitchImages Images { get; set; }
        public string[] Format { get; set; }
        public string[] Scale { get; set; }
        public string[] ThemeMode { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGlobalEmote object.
        /// </summary> 
        public static TwitchGlobalEmote FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchGlobalEmote
            {
                Id = data.Get("id").AsString(),
                Name = data.Get("name").AsString(),
                Images = data.Get("images").As<TwitchImages>(),
                Format = data.Get("format").AsStringArray(),
                Scale = data.Get("scale").AsStringArray(),
                ThemeMode = data.Get("theme_mode").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_global_emote.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("name", Name);
            request.Set("images", Images);
            request.Set("format", Format);
            request.Set("scale", Scale);
            request.Set("theme_mode", ThemeMode);
            return request;
        }
    
    }

}
