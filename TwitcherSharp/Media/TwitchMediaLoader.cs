using Godot;
using TwitcherSharp.Api.Generated.Bits;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Media;

public partial class TwitchMediaLoader : RefCounted, ITwitcherSharpSingleton<TwitchMediaLoader>
{
    private GodotObject? _data;
    public bool IsLinked => _data is not null;
    public static string ScriptPath => "res://addons/twitcher/media/twitch_media_loader.gd";

    public static TwitchMediaLoader? Instance
    {
        get => ITwitcherSharpSingleton<TwitchMediaLoader>.Instance;
        private set => ITwitcherSharpSingleton<TwitchMediaLoader>.Instance = value;
    }
    public static TwitchMediaLoader CreateInstance(Action<TwitchMediaLoader>? configure = null) =>
        ITwitcherSharpSingleton<TwitchMediaLoader>.CreateInstance(configure);
    
    public static TwitchMediaLoader Required => ITwitcherSharpSingleton<TwitchMediaLoader>.Required;

    [Signal]
    public delegate void EmojiLoadedEventHandler();

    public TwitchImageTransformer? ImageTransformer
    {
        get => _data is null
            ? field
            : _data.Get<TwitchImageTransformer>("image_transformer");
        set
        {
            _data?.SetObject("image_transformer", value);
            field = value;
        }
    } = new();

    public Texture2D? FallbackTexture
    {
        get => _data is null
            ? field
            : _data.Read("fallback_texture", static v => v.As<Texture2D>());
        set
        {
            if (value != null) _data?.SetValue("fallback_texture", value);
            field = value;
        }
    }

    public Texture2D? FallbackProfile
    {
        get => _data is null
            ? field
            : _data.Read("fallback_profile", static v => v.As<Texture2D>());
        set
        {
            if (value != null) _data?.SetValue("fallback_profile", value);
            field = value;
        }
    }

    public string ImageCdnHost
    {
        get => _data is null
            ? field
            : _data.Read("image_cdn_host", static v => v.AsString());
        set
        {
            _data?.SetValue("image_cdn_host", value);
            field = value;
        }
    } = "https://static-cdn.jtvnw.net/";

    /// <summary>
    /// Will preload the whole badge and emote cache also to editor time (use it when you make an Editor Plugin with Twitch Support)
    /// </summary>
    public bool LoadCacheInEditor
    {
        get => _data is null
            ? field
            : _data.Read("load_cache_in_editor", static v => v.AsBool());
        set
        {
            _data?.SetValue("load_cache_in_editor", value);
            field = value;
        }
    }

    public string CacheEmote
    {
        get => _data is null
            ? field
            : _data.Read("cache_emote", static v => v.AsString());
        set
        {
            _data?.SetValue("cache_emote", value);
            field = value;
        }
    } = "user://emotes";

    public string CacheBadge
    {
        get => _data is null
            ? field
            : _data.Read("cache_badge", static v => v.AsString());
        set
        {
            _data?.SetValue("cache_badge", value);
            field = value;
        }
    } = "user://badges";

    public string CacheCheermote
    {
        get => _data is null
            ? field
            : _data.Read("cache_cheermote", static v => v.AsString());
        set
        {
            _data?.SetValue("cache_cheermote", value);
            field = value;
        }
    } = "user://cheermote";

    public string CacheProfile
    {
        get => _data is null
            ? field
            : _data.Read("cache_profile", static v => v.AsString());
        set
        {
            _data?.SetValue("cache_profile", value);
            field = value;
        }
    } = "user://profiles";

    #region Emotes

    public async Task PreloadEmotes(string channelId = "global")
        => await _data!.InvokeAsync("preload_emotes", channelId);

    public async Task<Godot.Collections.Dictionary<string, SpriteFrames>> GetEmotes(string[] emoteIds)
    {
        var ids = new Godot.Collections.Array<string>(emoteIds);
        return await _data!.InvokeAsync("get_emotes", static v => v.AsGodotDictionary<string, SpriteFrames>(), ids);
    }

    public async Task<Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames>> GetEmotesByDefinition(
        TwitchEmoteDefinition[] emoteDefinitions)
    {
        using var definitions = emoteDefinitions.ToTypedArray("res://addons/twitcher/media/twitch_emote_definition.gd");
        return await _data!.CallDictionaryKeyAsync<TwitchEmoteDefinition, SpriteFrames>("get_emotes_by_definition", definitions);
    }

    public async Task<Dictionary<string, ITwitchEmote>> GetCachedEmotes(string channelId)
    {
        using var result = await _data!.CallAsync("get_cached_emotes");
        using var source = result.AsGodotDictionary();
        var emotes = new Dictionary<string, ITwitchEmote>();
        foreach (var (key, value) in source)
        {
            using (key)
            using (value)
            {
                var godotObject = value.AsGodotObject();
                ITwitchEmote? emote = godotObject?.GetClass() switch
                {
                    "TwitchGlobalEmote" => TwitchGlobalEmote.FromObject(godotObject),
                    "TwitchChannelEmote" => TwitchChannelEmote.FromObject(godotObject),
                    _ => null
                };
                godotObject.Release();
                if (emote != null) emotes[key.AsString()] = emote;
            }
        }

        return emotes;
    }

    #endregion

    #region Badges

    public async Task PreloadBadges(string channelId = "global") => await _data!.InvokeAsync("preload_badges", channelId);

    public async Task<Godot.Collections.Dictionary<TwitchBadgeDefinition, SpriteFrames>> GetBadges(
        TwitchBadgeDefinition[] badges)
    {
        using var definitions = badges.ToTypedArray("res://addons/twitcher/media/twitch_badge_definition.gd");
        return await _data!.CallDictionaryKeyAsync<TwitchBadgeDefinition, SpriteFrames>("get_badges", definitions);
    }

    #endregion

    #region Cheermotes

    public partial class CheerResult(
        TwitchCheermote cheermote,
        TwitchCheermote.TwitchResponseTiers tier,
        SpriteFrames spriteFrames) : RefCounted, ITwitcherSharp<CheerResult>
    {
        public TwitchCheermote Cheermote { get; set; } = cheermote;
        public TwitchCheermote.TwitchResponseTiers Tier { get; set; } = tier;
        public SpriteFrames SpriteFrames { get; set; } = spriteFrames;

        public static CheerResult? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new CheerResult(
                data.Get<TwitchCheermote>("cheermote")!,
                data.Get<TwitchCheermote.TwitchResponseTiers>("tier")!,
                data.Read("spriteframes", static v => v.As<SpriteFrames>()));
        }

        public GodotObject ToGodotObject()
        {
            using var cheermote = GodotObjectExtension.ToVariant(Cheermote);
            using var tier = GodotObjectExtension.ToVariant(Tier);
            return InteropExtension.NewInner(ScriptPath, "CheerResult", cheermote, tier, SpriteFrames);
        }
    }

    public List<TwitchCheermote> AllCheermotes() => _data!.CallList<TwitchCheermote>("all_cheermotes");

    /// <summary>
    /// Resolves an info with spriteframes for a specific cheer definition contains also spriteframes for the given tier.
    /// Can be null when not found.
    /// </summary>
    /// <param name="cheermoteDefinition"></param>
    /// <returns></returns>
    public async Task<CheerResult> GetCheerInfo(TwitchCheermoteDefinition cheermoteDefinition) =>
        await _data!.CallAsync<CheerResult>("get_cheer_info", cheermoteDefinition);

    /// <summary>
    /// Finds the tier depending on the given number
    /// </summary>
    /// <param name="number"></param>
    /// <param name="cheerData"></param>
    /// <returns></returns>
    public TwitchCheermote.TwitchResponseTiers FindCheerTier(int number, TwitchCheermote cheerData)
    {
        using var cheerArg = GodotObjectExtension.ToVariant(cheerData);
        return _data!.Call<TwitchCheermote.TwitchResponseTiers>("find_cheer_tier", number, cheerArg);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cheermoteDefinition"></param>
    /// <returns><see cref="SpriteFrames"/> mapped by <see cref="TwitchCheermote.TwitchResponseTiers"/> for a <see cref="TwitchCheermote"/></returns>
    public async Task<Godot.Collections.Dictionary<TwitchCheermote.TwitchResponseTiers, SpriteFrames>> GetCheermotes(
        TwitchCheermoteDefinition cheermoteDefinition)
    {
        using var definition = GodotObjectExtension.ToVariant(cheermoteDefinition);
        return await _data!.CallDictionaryKeyAsync<TwitchCheermote.TwitchResponseTiers, SpriteFrames>("get_cheermotes",
            definition);
    }

    #endregion

    #region Utils

    public async Task<Image> LoadImage(string url)
    {
        using var result = await _data!.CallAsync("load_image", url);
        return result.As<Image>();
    }

    /// <summary>
    /// Get the image of a user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<ImageTexture> LoadProfileImage(TwitchUser user)
    {
        using var userArg = GodotObjectExtension.ToVariant(user);
        using var result = await _data!.CallAsync("load_profile_image", userArg);
        return result.As<ImageTexture>();
    }

    #endregion

    public static TwitchMediaLoader? FromObject(GodotObject? data)
    {
        if (data is null) return null;

        var mediaLoader = new TwitchMediaLoader()
        {
            ImageTransformer = data.Get<TwitchImageTransformer>("image_transformer"),
            FallbackTexture = data.Read("fallback_texture", static v => v.As<Texture2D>()),
            FallbackProfile = data.Read("fallback_profile", static v => v.As<Texture2D>()),
            ImageCdnHost = data.Read("image_cdn_host", static v => v.AsString()),
            LoadCacheInEditor = data.Read("load_cache_in_editor", static v => v.AsBool()),
            CacheEmote = data.Read("cache_emote", static v => v.AsString()),
            CacheBadge = data.Read("cache_badge", static v => v.AsString()),
            CacheCheermote = data.Read("cache_cheermote", static v => v.AsString()),
            CacheProfile = data.Read("cache_profile", static v => v.AsString()),
            _data = data, //must be last to avoid setting itself (performance boost)
        };
        data.SetMeta("_twitcher_sharp_instance", mediaLoader);


        Instance = mediaLoader;

        return mediaLoader;
    }

    public GodotObject ToGodotObject()
    {
        if (_data is not null) return _data;

        _data = InteropExtension.NewObject(ScriptPath);
        _data.SetObject("image_transformer", ImageTransformer);
        if (FallbackTexture != null) _data.SetValue("fallback_texture", FallbackTexture);
        if (FallbackProfile != null) _data.SetValue("fallback_profile", FallbackProfile);
        _data.SetValue("image_cdn_host", ImageCdnHost);
        _data.SetValue("load_cache_in_editor", LoadCacheInEditor);
        _data.SetValue("cache_emote", CacheEmote);
        _data.SetValue("cache_badge", CacheBadge);
        _data.SetValue("cache_cheermote", CacheCheermote);
        _data.SetValue("cache_profile", CacheProfile);
        return _data;
    }

    public void FreeInstance()
    {
        if (_data is null) return;
        _data.SetMeta("_twitcher_sharp_instance", Instance!);
        _data = null;
    }
}