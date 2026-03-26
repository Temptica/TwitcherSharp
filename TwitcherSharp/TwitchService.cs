using Godot;
using TwitcherSharp.Api.Generated.Bits;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Chat.Interfaces;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;

namespace TwitcherSharp;

public partial class TwitchService : RefCounted, ITwitcherSharpSingleton<TwitchService>
{
    private GodotObject _data;
    public bool IsLinked { get; }
    public static TwitchService Instance { get; set; }

    /// <summary>
    /// Call this to setup the complete Twitch integration whenever you need.
    /// <br/> It boots everything up this Lib supports
    /// </summary>
    /// <returns></returns>
    public async Task<bool> Setup()
    {
        var result = await _data.CallAsync("setup");
        return result.AsBool();
    }

    public async Task UnSetup() => await _data.CallAsync("unsetup");

    public bool IsConfigured() => _data.Call("is_configured").AsBool();

    /// <summary>
    /// Get data about a user by USER_ID
    /// </summary>
    /// <param name="userId">user's id to get the username for</param>
    /// <param name="forceRefresh">force to refresh the cache</param>
    /// <returns></returns>
    public async Task<TwitchUser> GetUserById(string userId, bool forceRefresh = false)
        => await _data.CallAsync<TwitchUser>("get_user_by_id", userId, forceRefresh);

    /// <summary>
    /// Get data about a user by USERNAME
    /// </summary>
    /// <param name="username">user's username to get</param>
    /// <param name="forceRefresh">force to refresh the cache</param>
    /// <returns></returns>
    public async Task<TwitchUser> GetUser(string username, bool forceRefresh = false)
        => await _data.CallAsync<TwitchUser>("get_user", username, forceRefresh);

    /// <summary>
    /// Get data about a user by USERNAME
    /// </summary>
    /// <param name="forceRefresh"></param>
    /// <returns></returns>
    public async Task<TwitchUser> GetCurrentUser(bool forceRefresh = false)
        => await _data.CallAsync<TwitchUser>("get_current_user", forceRefresh);

    public async Task<ImageTexture> GetProfileImage(TwitchUser user)
        => (await _data.CallAsync("load_profile_image", user.ToGodotObject())).As<ImageTexture>();

    /// <summary>
    /// Refer to https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/ for details on which API versions are available and which conditions are required.
    /// </summary>
    /// <param name="definition">The definition of the event subscription</param>
    /// <param name="condition">The condition (parameters) for the event subscription</param>
    /// <returns></returns>
    public async Task<TwitchEventSubConfig> SubscribeEvent(TwitchEventSubDefinition definition,
        ITwitcherSharpCondition condition)
    {
        return await _data.CallAsync<TwitchEventSubConfig>("subscribe_event", definition.ToGodotObject(),
            condition.ToDictionary());
    }

    /// <summary>
    /// Waits for connection to eventsub. Eventsub is ready to subscribe events.
    /// </summary>
    public async Task WaitForEventSubConnection()
    {
        await _data.CallAsync("wait_for_eventsub_connection");
    }

    /// <summary>
    /// Returns all of the eventsub subscriptions (variable is a copy so you can freely modify it)
    /// </summary>
    /// <returns></returns>
    public async Task<List<TwitchEventSubConfig>> GetSubscriptions()
    {
        return await _data.CallListAsync<TwitchEventSubConfig>("get_subscriptions");
    }

    public void Chat(string message, TwitchUser broadcaster = null, TwitchUser sender = null)
    {
        _data.Call("chat", message, broadcaster?.ToGodotObject(), sender?.ToGodotObject());
    }

    /// <summary>
    /// Sends out a shoutout to a specific user
    /// </summary>
    /// <param name="user">The user to shoutout</param>
    /// <param name="broadcaster">The broadcaster's chat to send it in</param>
    /// <param name="moderator">The moderator that sends it</param>
    public void Shoutout(TwitchUser user, TwitchUser broadcaster = null, TwitchUser moderator = null)
    {
        _data.Call("shoutout", user.ToGodotObject(), broadcaster?.ToGodotObject(), moderator?.ToGodotObject());
    }

    /// <summary>
    /// Sends out an announcement message to the chat
    /// </summary>
    /// <param name="message">The message to announce</param>
    /// <param name="color">The color of the message box</param>
    /// <param name="broadcaster">The broadcaster's chat to send it in</param>
    /// <param name="moderator">The moderator that sends it</param>
    public void Announcement(string message, TwitchAnnouncementColor color = null, TwitchUser broadcaster = null,
        TwitchUser moderator = null)
    {
        color ??= TwitchAnnouncementColor.Primary;
        _data.Call("announcement", message, color.ToGodotObject(), broadcaster?.ToGodotObject(),
            moderator?.ToGodotObject());
    }

    /// <summary>
    /// Add a new command handler and register it for a command.
    /// The callback will receive <c>from_username: String, info: TwitchCommandInfo, args: PackedStringArray</c><br/>
    /// Args are optional depending on the configuration.<br/>
    /// argsMax == -1 => no upper limit for arguments
    /// </summary>
    /// <param name="command"></param>
    /// <param name="callable"></param>
    /// <param name="argsMin"></param>
    /// <param name="argsMax"></param>
    /// <param name="permissionLevel"></param>
    /// <param name="where"></param>
    /// <param name="userCooldown"></param>
    /// <param name="globalCooldown"></param>
    /// <returns></returns>
    public TwitchCommand AddCommand(string command, Callable callable, int argsMin = 0, int argsMax = -1,
        TwitchCommandBase.PermissionFlag permissionLevel = TwitchCommandBase.PermissionFlag.Everyone,
        TwitchCommandBase.WhereFlag where = TwitchCommandBase.WhereFlag.Chat, float userCooldown = 0,
        float globalCooldown = 0)
    {
        var result = _data.Call("add_command", command, callable, argsMin, argsMax, (int)permissionLevel, (int)where,
            userCooldown,
            globalCooldown);
        return TwitchCommand.FromObject(result.AsGodotObject());
    }

    /// <summary>
    /// Easier way to add a command to the scene tree.
    /// </summary>
    /// <param name="command"></param>
    public void AddCommand(TwitchCommand command)
    {
        ((Node)_data).AddChild((Node)command.ToGodotObject());
    }

    public void RemoveCommand(string command)
        => _data.Call("remove_command", command);

    /// <summary>
    /// Whispers to another user.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="username"></param>
    public void Whisper(string message, string username)
    {
        _data.Call("whisper", message, username);
    }


    public async Task<Dictionary<string, ITwitchEmote>> GetEmotesData(string channelId = "global")
    {
        var result = await _data.CallAsync("get_emotes_data");
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

    /// <summary>
    /// Returns the definition of badges for a given channel or for the global bages.
    /// Key: category / versions / badge_id | Value: TwitchChatBadge
    /// </summary>
    /// <param name="channelId"></param>
    /// <returns></returns>
    public async Task<Godot.Collections.Dictionary<string, TwitchChatBadge>>
        GetBadgesData(string channelId = "global") =>
        await _data.CallDictionaryValueAsync<string, TwitchChatBadge>("get_badges_data");

    /// <summary>
    /// Gets the requested emotes.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Key: EmoteID as String | Value: SpriteFrame</returns>
    public async Task<Godot.Collections.Dictionary<string, SpriteFrames>> GetEmotes(string[] ids) =>
        (await _data.CallAsync("get_emotes", ids)).AsGodotDictionary<string, SpriteFrames>();

    /// <summary>
    /// Gets the requested emotes in the specified theme, scale and type.
    /// Loads from cache if possible otherwise downloads and transforms them.
    /// </summary>
    /// <param name="emotes"></param>
    /// <returns>Key: TwitchEmoteDefinition | Value SpriteFrames</returns>
    public async Task<Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames>> GetEmotesByDefinition(
        TwitchEmoteDefinition[] emotes) =>
        await _data.CallDictionaryKeyAsync<TwitchEmoteDefinition, SpriteFrames>("get_emotes_by_definition",
            emotes);

    public async Task<Godot.Collections.Dictionary> Poll(string title, string[] choices, int duration = 60,
        bool channelPointsVotingEnabled = false, int channelPointsPerVote = 1000, string broadcasterId = "")
        => (await _data.CallAsync("poll", title, choices, duration, channelPointsVotingEnabled, channelPointsPerVote, broadcasterId)).AsGodotDictionary();

    public async Task<List<TwitchGetCheermotesResponse.TwitchCheermote>> GetCheermoteData()
        => await _data.CallListAsync<TwitchGetCheermotesResponse.TwitchCheermote>("get_cheermote_data");
    
    public async Task<Godot.Collections.Dictionary<TwitchCheermoteDefinition, SpriteFrames>> GetCheermotes(
        TwitchCheermoteDefinition definition) =>
        await _data.CallDictionaryKeyAsync<TwitchCheermoteDefinition, SpriteFrames>("get_cheermotes", definition);
    
    public static TwitchService FromObject(GodotObject data)
    {
        if (data is null) return null;
        var service = new TwitchService
        {
            _data = data,
        };
        Instance = service;
        data.SetMeta("_twitcher_sharp_instance",Instance);
        return service;
    }

    public GodotObject ToGodotObject()
    {
        if(_data is not null) return _data;
        
        var script = GD.Load<GDScript>("res://addons/twitcher/twitch_service.gd");
        _data = script.New().AsGodotObject();
        _data.SetMeta("_twitcher_sharp_instance",this);
        
        return _data;
    }

    public void FreeInstance()
    {
        if(_data is not null && !_data.IsQueuedForDeletion()) _data.RemoveMeta("_twitcher_sharp_instance");
        Instance = null;   
    }

    public static TwitchService GetOrCreateInstance()
    {
        if (Instance != null) return Instance;
        
        var script = GD.Load<GDScript>("res://addons/twitcher/twitch_service.gd");
        var twitchApi = script.New().AsGodotObject();
        var instance = twitchApi.Get("instance");
    
        if (instance.VariantType != Variant.Type.Object)
        {
            var root = (Engine.GetMainLoop() as SceneTree)!.Root;
            root.AddChild(twitchApi as Node);
            FromObject(twitchApi);
            return Instance;
        }
        
        FromObject(instance.AsGodotObject());
        return Instance;
    }
}
