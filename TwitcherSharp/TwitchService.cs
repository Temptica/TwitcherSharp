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
using TwitcherSharp.Reward;

namespace TwitcherSharp;

public partial class TwitchService : RefCounted, ITwitcherSharpSingleton<TwitchService>
{
    private GodotObject? _data;
    public bool IsLinked => _data is not null;
    public static string ScriptPath => "res://addons/twitcher/twitch_service.gd";

    public static TwitchService? Instance
    {
        get => ITwitcherSharpSingleton<TwitchService>.Instance;
        private set => ITwitcherSharpSingleton<TwitchService>.Instance = value;
    }

    public static TwitchService CreateInstance(Action<TwitchService>? configure = null) =>
        ITwitcherSharpSingleton<TwitchService>.CreateInstance(configure);
    
    public static TwitchService Required => ITwitcherSharpSingleton<TwitchService>.Required;

    /// <summary>
    /// Call this to setup the complete Twitch integration whenever you need.
    /// <br/> It boots everything up this Lib supports
    /// </summary>
    /// <returns></returns>
    public async Task<bool> Setup()
    {
        using var result = await _data!.CallAsync("setup");
        return result.AsBool();
    }

    public async Task UnSetup() => await _data!.InvokeAsync("unsetup");

    public bool IsConfigured() => _data!.Invoke("is_configured", static v => v.AsBool());

    /// <summary>
    /// Get data about a user by USER_ID
    /// </summary>
    /// <param name="userId">user's id to get the username for</param>
    /// <param name="forceRefresh">force to refresh the cache</param>
    /// <returns></returns>
    public async Task<TwitchUser?> GetUserById(string userId, bool forceRefresh = false)
        => await _data!.CallAsync<TwitchUser>("get_user_by_id", userId, forceRefresh);

    /// <summary>
    /// Get data about a user by USERNAME
    /// </summary>
    /// <param name="username">user's username to get</param>
    /// <param name="forceRefresh">force to refresh the cache</param>
    /// <returns></returns>
    public async Task<TwitchUser?> GetUser(string username, bool forceRefresh = false)
        => await _data!.CallAsync<TwitchUser>("get_user", username, forceRefresh);

    /// <summary>
    /// Get data about a user by USERNAME
    /// </summary>
    /// <param name="forceRefresh"></param>
    /// <returns></returns>
    public async Task<TwitchUser?> GetCurrentUser(bool forceRefresh = false)
        => await _data!.CallAsync<TwitchUser>("get_current_user", forceRefresh);

    public async Task<ImageTexture> GetProfileImage(TwitchUser user)
    {
        using var userArg = GodotObjectExtension.ToVariant(user);
        using var result = await _data!.CallAsync("load_profile_image", userArg);
        return result.As<ImageTexture>();
    }


    /// <summary>
    /// Refer to https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/ for details on which API versions are available and which conditions are required.
    /// </summary>
    /// <param name="definition">The definition of the event subscription</param>
    /// <param name="condition">The condition (parameters) for the event subscription</param>
    /// <returns></returns>
    public async Task<TwitchEventSubConfig?> SubscribeEvent(TwitchEventSubDefinition definition,
        ITwitcherSharpCondition condition)
    {
        // twitcher's own definition object: a plain Object it keeps, so the wrapper is not disposed.
        using var conditions = condition.ToDictionary();
        return await _data!.CallAsync<TwitchEventSubConfig>("subscribe_event", definition.ToGodotObject(), conditions);
    }

    /// <summary>
    /// Waits for connection to eventsub. Eventsub is ready to subscribe events.
    /// </summary>
    public async Task WaitForEventSubConnection()
    {
        using var _ = await _data!.CallAsync("wait_for_eventsub_connection");
    }

    /// <summary>
    /// Returns all of the eventsub subscriptions (variable is a copy so you can freely modify it)
    /// </summary>
    /// <returns></returns>
    public async Task<List<TwitchEventSubConfig>> GetSubscriptions()
    {
        return await _data!.CallListAsync<TwitchEventSubConfig>("get_subscriptions");
    }

    public void Chat(string message, string replyParentMessageId = "", TwitchUser? broadcaster = null,
        TwitchUser? sender = null)
    {
        using var broadcasterArg = GodotObjectExtension.ToVariant(broadcaster);
        using var senderArg = GodotObjectExtension.ToVariant(sender);
        _data!.Invoke("chat", message, replyParentMessageId, broadcasterArg, senderArg);
    }

    /// <summary>
    /// Sends out a shoutout to a specific user
    /// </summary>
    /// <param name="user">The user to shoutout</param>
    /// <param name="broadcaster">The broadcaster's chat to send it in</param>
    /// <param name="moderator">The moderator that sends it</param>
    public async Task Shoutout(TwitchUser user, TwitchUser? broadcaster = null, TwitchUser? moderator = null)
    {
        using var userArg = GodotObjectExtension.ToVariant(user);
        using var broadcasterArg = GodotObjectExtension.ToVariant(broadcaster);
        using var moderatorArg = GodotObjectExtension.ToVariant(moderator);
        using var _ = await _data!.CallAsync("send_shoutout", userArg, broadcasterArg, moderatorArg);
    }

    /// <summary>
    /// Sends out an announcement message to the chat
    /// </summary>
    /// <param name="message">The message to announce</param>
    /// <param name="color">The color of the message box</param>
    /// <param name="broadcaster">The broadcaster's chat to send it in</param>
    /// <param name="moderator">The moderator that sends it</param>
    public async Task Announcement(string message, TwitchAnnouncementColor? color = null, TwitchUser? broadcaster = null,
        TwitchUser? moderator = null)
    {
        color ??= TwitchAnnouncementColor.Primary;
        using var colorArg = GodotObjectExtension.ToVariant(color);
        using var broadcasterArg = GodotObjectExtension.ToVariant(broadcaster);
        using var moderatorArg = GodotObjectExtension.ToVariant(moderator);
        using var _ = await _data!.CallAsync("send_announcement", message, colorArg, broadcasterArg, moderatorArg);
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
        return _data!.Call<TwitchCommand>("add_command", command, callable, argsMin, argsMax, (int)permissionLevel,
            (int)where, userCooldown, globalCooldown);
    }

    /// <summary>
    /// Easier way to add a command to the scene tree.
    /// </summary>
    /// <param name="command"></param>
    public TwitchCommand AddCommand(TwitchCommand command)
    {
        ((Node)_data!).AddChild((Node)command.ToGodotObject());
        return command;
    }

    public void RemoveCommand(string command)
        => _data!.Invoke("remove_command", command);

    /// <summary>
    /// Whispers to another user.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="userId"></param>
    public async Task Whisper(string message, string userId)
    {
        await _data!.InvokeAsync("whisper", message, userId);
    }

    /// <summary>
    /// Tries to create or update an existing reward.
    /// </summary>
    /// <param name="twitchReward"> The reward to save</param>
    /// <returns></returns>
    public async Task<TwitchRewardService.SaveError> SaveReward(TwitchReward twitchReward)
    {
        _data ??= ToGodotObject();

        using var rewardArg = GodotObjectExtension.ToVariant(twitchReward);
        using var result = await _data.CallAsync("save_reward", rewardArg);
        return result.As<TwitchRewardService.SaveError>();
    }

    /// <summary>
    /// Deletes a reward on Twitch side. Will also remove the ID when succesfully.
    /// </summary>
    /// <param name="twitchReward"> The reward to delete</param>
    /// <returns></returns>
    public async Task<TwitchRewardService.DeleteError> DeleteReward(TwitchReward twitchReward)
    {
        _data ??= ToGodotObject();

        using var rewardArg = GodotObjectExtension.ToVariant(twitchReward);
        using var result = await _data.CallAsync("delete_reward", rewardArg);
        return result.As<TwitchRewardService.DeleteError>();
    }

    public async Task<Dictionary<string, ITwitchEmote>> GetEmotesData(string channelId = "global")
    {
        using var result = await _data!.CallAsync("get_emotes_data");
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

    /// <summary>
    /// Returns the definition of badges for a given channel or for the global bages.
    /// Key: category / versions / badge_id | Value: TwitchChatBadge
    /// </summary>
    /// <param name="channelId"></param>
    /// <returns></returns>
    public async Task<Godot.Collections.Dictionary<string, TwitchChatBadge>>
        GetBadgesData(string channelId = "global") =>
        await _data!.CallDictionaryValueAsync<string, TwitchChatBadge>("get_badges_data");

    /// <summary>
    /// Gets the requested emotes.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Key: EmoteID as String | Value: SpriteFrame</returns>
    public async Task<Godot.Collections.Dictionary<string, SpriteFrames>> GetEmotes(string[] ids) =>
        await _data!.InvokeAsync("get_emotes", static v => v.AsGodotDictionary<string, SpriteFrames>(), ids);

    /// <summary>
    /// Gets the requested emotes in the specified theme, scale and type.
    /// Loads from cache if possible otherwise downloads and transforms them.
    /// </summary>
    /// <param name="emotes"></param>
    /// <returns>Key: TwitchEmoteDefinition | Value SpriteFrames</returns>
    public async Task<Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames>> GetEmotesByDefinition(
        TwitchEmoteDefinition[] emotes) =>
        await _data!.CallDictionaryKeyAsync<TwitchEmoteDefinition, SpriteFrames>("get_emotes_by_definition",
            emotes);

    public async Task<Godot.Collections.Dictionary> Poll(string title, string[] choices, int duration = 60,
        bool channelPointsVotingEnabled = false, int channelPointsPerVote = 1000, string broadcasterId = "")
        => await _data!.InvokeAsync("poll", static v => v.AsGodotDictionary(), title, choices, duration, channelPointsVotingEnabled, channelPointsPerVote,
            broadcasterId);

    public async Task<List<TwitchCheermote>> GetCheermoteData()
        => await _data!.CallListAsync<TwitchCheermote>("get_cheermote_data");

    public async Task<Godot.Collections.Dictionary<TwitchCheermoteDefinition, SpriteFrames>> GetCheermotes(
        TwitchCheermoteDefinition definition) =>
        await _data!.CallDictionaryKeyAsync<TwitchCheermoteDefinition, SpriteFrames>("get_cheermotes", definition);

    public static TwitchService? FromObject(GodotObject? data)
    {
        if (data is null) return null;
        var service = new TwitchService
        {
            _data = data,
        };
        Instance = service;
        data.SetMeta("_twitcher_sharp_instance", Instance);
        return service;
    }

    public GodotObject ToGodotObject()
    {
        if (_data is not null) return _data;

        _data = InteropExtension.NewObject("res://addons/twitcher/twitch_service.gd");
        _data.SetMeta("_twitcher_sharp_instance", this);

        return _data;
    }

    public void FreeInstance()
    {
        if (_data is not null && !_data.IsQueuedForDeletion()) _data.RemoveMeta("_twitcher_sharp_instance");
        Instance = null;
    }
}