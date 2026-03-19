using Godot;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitchCheermote = TwitcherSharp.Api.Generated.Bits.TwitchGetCheermotesResponse.TwitchCheermote;

namespace TwitcherSharp.Media;

public partial class TwitchMediaLoader : RefCounted, ITwitcherSharpSingleton<TwitchMediaLoader>
{
    private GodotObject _data;
    public bool IsLinked => _data is not null;
    public static TwitchMediaLoader Instance { get; private set; }

    [Signal]
    public delegate void EmojiLoadedEventHandler();

    public TwitchImageTransformer ImageTransformer
    {
        get => _data is null
            ? field
            : TwitchImageTransformer.FromObject(_data.Get("image_transformer").AsGodotObject());
        set
        {
            _data?.Set("image_transformer", value?.ToGodotObject());
            field = value;
        }
    } = new();

    public Texture2D FallbackTexture
    {
        get => _data is null
            ? field
            : _data.Get("fallback_texture").As<Texture2D>();
        set
        {
            _data?.Set("fallback_texture", value);
            field = value;
        }
    }

    public Texture2D FallbackProfile
    {
        get => _data is null
            ? field
            : _data.Get("fallback_profile").As<Texture2D>();
        set
        {
            _data?.Set("fallback_profile", value);
            field = value;
        }
    }

    public string ImageCdnHost
    {
        get => _data is null
            ? field
            : _data.Get("image_cdn_host").AsString();
        set
        {
            _data?.Set("image_cdn_host", value);
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
            : _data.Get("load_cache_in_editor").AsBool();
        set
        {
            _data?.Set("load_cache_in_editor", value);
            field = value;
        }
    }

    public string CacheEmote
    {
        get => _data is null
            ? field
            : _data.Get("cache_emote").AsString();
        set
        {
            _data?.Set("cache_emote", value);
            field = value;
        }
    } = "user://emotes";

    public string CacheBadge
    {
        get => _data is null
            ? field
            : _data.Get("cache_badge").AsString();
        set
        {
            _data?.Set("cache_badge", value);
            field = value;
        }
    } = "user://badges";

    public string CacheCheermote
    {
        get => _data is null
            ? field
            : _data.Get("cache_cheermote").AsString();
        set
        {
            _data?.Set("cache_cheermote", value);
            field = value;
        }
    } = "user://cheermote";

    public string CacheProfile
    {
        get => _data is null
            ? field
            : _data.Get("cache_profile").AsString();
        set
        {
            _data?.Set("cache_profile", value);
            field = value;
        }
    } = "user://profiles";

    #region Emotes

    public void PreloadEmotes(string channelId = "global")
        => _data.Call("preload_emotes", channelId);

    public Godot.Collections.Dictionary<string, SpriteFrames> GetEmotes(string[] emoteIds)
        => _data.Call("get_emotes", emoteIds).AsGodotDictionary<string, SpriteFrames>();

    public Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames> GetEmotesByDefinition(
        TwitchEmoteDefinition[] emoteDefinitions)
    {
        var param = emoteDefinitions.Select(ed => ed.ToGodotObject()).ToArray();
        return _data.CallDictionaryKey<TwitchEmoteDefinition, SpriteFrames>("get_emotes_by_definition", param);
    }

    public async Task<Dictionary<string, ITwitchEmote>> GetCachedEmotes(string channelId)
    {
        var result = await _data.CallAsync("get_cached_emotes");
        return result.AsGodotDictionary()
            .Select(x =>
            {
                var godotObject = x.Value.AsGodotObject();
                ITwitchEmote emote = godotObject.GetClass() switch
                {
                    "TwitchGlobalEmote" => TwitchGetGlobalEmotesResponse.TwitchGlobalEmote.FromObject(godotObject),
                    "TwitchChannelEmote" => TwitchGetChannelEmotesResponse.TwitchChannelEmote.FromObject(godotObject),
                    _ => null
                };
                return (x.Key.AsString(), emote);
            }).ToDictionary();
    }

    #endregion

    #region Badges

    public async Task PreloadBadges(string channelId = "global") => await _data.CallAsync("preload_badges", channelId);

    public async Task<Godot.Collections.Dictionary<TwitchBadgeDefinition, SpriteFrames>> GetBadges(
        TwitchBadgeDefinition[] badges)
        => await _data.CallDictionaryKeyAsync<TwitchBadgeDefinition, SpriteFrames>("get_badges",
            badges.Select(badge => badge.ToGodotObject()).ToArray());

    #endregion

    #region Cheermotes

    public partial class CheerResult(
        TwitchCheermote cheermote,
        TwitchCheermote.TwitchTiers tier,
        SpriteFrames spriteFrames) : RefCounted, ITwitcherSharp<CheerResult>
    {
        public TwitchCheermote Cheermote { get; set; } = cheermote;
        public TwitchCheermote.TwitchTiers Tier { get; set; } = tier;
        public SpriteFrames SpriteFrames { get; set; } = spriteFrames;

        public static CheerResult FromObject(GodotObject data)
        {
            return new CheerResult(
                TwitchCheermote.FromObject(data.Get("cheermote").AsGodotObject()),
                TwitchCheermote.TwitchTiers.FromObject(data.Get("tier").AsGodotObject()),
                data.Get("sprite_frames").As<SpriteFrames>());
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_media_loader.gd");
            var mainClass = script.Get("CheerResult").AsGodotObject();
            var request = mainClass.Call("new").AsGodotObject();
            request.Set("cheermote", Cheermote);
            request.Set("tier", Tier);
            request.Set("sprite_frames", SpriteFrames);
            return request;
        }
    }

    public List<TwitchCheermote> AllCheermotes() => _data.Call("all_cheermotes")
        .AsGodotObjectArray<GodotObject>()
        .Select(TwitchCheermote.FromObject)
        .ToList();

    /// <summary>
    /// Resolves an info with spriteframes for a specific cheer definition contains also spriteframes for the given tier.
    /// Can be null when not found.
    /// </summary>
    /// <param name="cheermoteDefinition"></param>
    /// <returns></returns>
    public async Task<CheerResult> GetCheerInfo(TwitchCheermoteDefinition cheermoteDefinition) =>
        await _data.CallAsync<CheerResult>("get_cheer_info", cheermoteDefinition);

    /// <summary>
    /// Finds the tier depending on the given number
    /// </summary>
    /// <param name="number"></param>
    /// <param name="cheerData"></param>
    /// <returns></returns>
    public TwitchCheermote.TwitchTiers FindCheerTier(int number, TwitchCheermote cheerData)
        => _data.Call("find_cheer_tier", number, cheerData.ToGodotObject()).As<TwitchCheermote.TwitchTiers>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cheermoteDefinition"></param>
    /// <returns><see cref="SpriteFrames"/> mapped by <see cref="TwitchCheermote.TwitchTiers"/> for a <see cref="TwitchCheermote"/></returns>
    public async Task<Godot.Collections.Dictionary<TwitchCheermote.TwitchTiers, SpriteFrames>> GetCheermotes(
        TwitchCheermoteDefinition cheermoteDefinition)
        => await _data.CallDictionaryKeyAsync<TwitchCheermote.TwitchTiers, SpriteFrames>("get_cheermotes",
            cheermoteDefinition.ToGodotObject());

    #endregion

    #region Utils

    public async Task<Image> LoadImage(string url) => (await _data.CallAsync("load_image", url)).As<Image>();

    /// <summary>
    /// Get the image of a user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<ImageTexture> LoadProfileImage(TwitchUser user) =>
        (await _data.CallAsync("load_profile_image", user.ToGodotObject())).As<ImageTexture>();

    #endregion

    public static TwitchMediaLoader FromObject(GodotObject data)
    {
        var mediaLoader = new TwitchMediaLoader()
        {
            ImageTransformer = TwitchImageTransformer.FromObject(data.Get("image_transformer").AsGodotObject()),
            FallbackTexture = data.Get("fallback_texture").As<Texture2D>(),
            FallbackProfile = data.Get("fallback_profile").As<Texture2D>(),
            ImageCdnHost = data.Get("image_cdn_host").AsString(),
            LoadCacheInEditor = data.Get("load_cache_in_editor").AsBool(),
            CacheEmote = data.Get("cache_emote").AsString(),
            CacheBadge = data.Get("cache_badge").AsString(),
            CacheCheermote = data.Get("cache_cheermote").AsString(),
            CacheProfile = data.Get("cache_profile").AsString(),
            _data = data, //must be last to avoid setting itself (performance boost)
        };
        data.SetMeta("_twitcher_sharp_instance", mediaLoader);
        

        Instance = mediaLoader;

        return mediaLoader;
    }

    public GodotObject ToGodotObject()
    {
        if (_data is not null) return _data;

        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_media_loader.gd");
        _data = script.New().AsGodotObject();
        _data.Set("image_transformer", ImageTransformer?.ToGodotObject());
        _data.Set("fallback_texture", FallbackTexture);
        _data.Set("fallback_profile", FallbackProfile);
        _data.Set("image_cdn_host", ImageCdnHost);
        _data.Set("load_cache_in_editor", LoadCacheInEditor);
        _data.Set("cache_emote", CacheEmote);
        _data.Set("cache_badge", CacheBadge);
        _data.Set("cache_cheermote", CacheCheermote);
        _data.Set("cache_profile", CacheProfile);
        return _data;
    }

    public void FreeInstance()
    {
        if (_data is null) return;
        _data.SetMeta("_twitcher_sharp_instance", Instance);
        _data = null;
    }
    
    public static TwitchMediaLoader GetOrCreateInstance()
    {
        if (Instance != null) return Instance;
        
        var script = GD.Load<GDScript>("res://addons/twitcher/media/twitch_media_loader.gd");
        var twitchMediaLoader = script.New().AsGodotObject();
        var instance = twitchMediaLoader.Get("instance");
    
        if (instance.VariantType != Variant.Type.Object)
        {
            var root = (Engine.GetMainLoop() as SceneTree)!.Root;
            root.AddChild(twitchMediaLoader as Node);
            FromObject(twitchMediaLoader);
            return Instance;
        }
        
        FromObject(instance.AsGodotObject());
        return Instance;
    }
}