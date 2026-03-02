using Godot;
using Godot.Collections;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchMediaLoader : Resource, ITwitcherSharpSingleton<TwitchMediaLoader>
{
    private GodotObject _data;
    public static TwitchMediaLoader Instance { get; }

    [Signal]
    public delegate void EmojiLoadedEventHandler();

    public TwitchImageTransformer ImageTransformer
    {
        get;
        set
        {
            _data?.Set("image_transformer", value.ToGodotObject());
            field = value;
        }
    } = new();

    public Texture2D FallbackTexture { get; set; }
    public Texture2D FallbackProfile { get; set; }
    public string ImageCdnHost { get; set; } = "https://static-cdn.jtvnw.net/";

    /// <summary>
    /// Will preload the whole badge and emote cache also to editor time (use it when you make an Editor Plugin with Twitch Support)
    /// </summary>
    public bool LoadCacheInEditor { get; set; }

    public string CacheEmote { get; set; } = "user://emotes";
    public string CacheBadge { get; set; } = "user://badges";
    public string CacheCheermote { get; set; } = "user://cheermote";
    public string CacheProfile { get; set; } = "user://profiles";

    public void PreloadEmotes(string channelId = "global")
        => _data.Call("preload_emotes", channelId);

    public Godot.Collections.Dictionary<string, SpriteFrames> GetEmotes(string[] emoteIds)
        => _data.Call("get_emotes", emoteIds).AsGodotDictionary<string, SpriteFrames>();

    public Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames> GetEmotesByDefinition(
        TwitchEmoteDefinition[] emoteDefinitions)
    {
        var resultDictionary = new Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames>();

        var result = _data
            .Call("get_emotes_by_definition", emoteDefinitions.Select(ed => ed.ToGodotObject()).ToArray())
            .AsGodotDictionary<GodotObject, SpriteFrames>()
            .Select(kvp => (TwitchEmoteDefinition.FromObject(kvp.Key), kvp.Value));
        
        foreach (var (key, value) in result)
        {
            resultDictionary.Add(key, value);
        }

        return resultDictionary;
    }
    
    public async Task<Dictionary> GetCachedEmotes(string channelId)
    {
        var result = await _data.CallAsync("get_cached_emotes");
        return result.AsGodotDictionary();
    }

    public async Task<TwitchGetChannelEmotesResponse.TwitchChannelEmote[]> GetCachedChannelEmotes(string channelId)
    {
        
    }

    public static TwitchMediaLoader FromObject(GodotObject data)
    {
        throw new NotImplementedException();
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }

    public static TwitchMediaLoader Create()
    {
        throw new NotImplementedException();
    }
}