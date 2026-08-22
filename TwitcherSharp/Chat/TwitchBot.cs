using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

/// <summary>
/// Helper to send messages with a second bot user and the corresponding bot badge.
/// Take care that setup is needed that it actually works! The right scopes for the target channel 
/// and the sender user has to be set. 
/// See also https://dev.twitch.tv/docs/api/reference/#send-chat-message
/// <p> Note: This node is connected to the godot object. Setting values here will also set those in the godotScript and vice versa</p>
/// </summary>
public partial class TwitchBot : RefCounted, ITwitcherSharpSingleton<TwitchBot>
{
    private GodotObject? _data;
    public bool IsLinked => _data is not null && !_data.IsQueuedForDeletion();

    public static string ScriptPath => "res://addons/twitcher/chat/twitch_bot.gd";

    public static TwitchBot? Instance
    {
        get => ITwitcherSharpSingleton<TwitchBot>.Instance;
        private set => ITwitcherSharpSingleton<TwitchBot>.Instance = value;
    }
    
    // ReSharper disable once UnusedParameter.Global
    public static TwitchBot CreateInstance(Action<TwitchBot>? configure = null) =>
        ITwitcherSharpSingleton<TwitchBot>.CreateInstance(configure);

    public TwitchUser? Sender
    {
        get => _data != null
            ? TwitchUser.FromObject(_data.Get("sender").AsGodotObject())
            : field;
        set
        {
            _data?.Set("sender", value?.ToGodotObject() ?? new Variant()!);
            field = value;
        }
    }

    public TwitchUser? Receiver
    {
        get => _data != null
            ? TwitchUser.FromObject(_data.Get("receiver").AsGodotObject())
            : field;
        set
        {
            _data?.Set("receiver", value?.ToGodotObject() ?? new Variant()!);
            field = value;
        }
    }

    /// <summary>
    /// Sends a message to the chat as bot (with bot badge).
    /// </summary>
    /// <param name="message">Message the bot should send (max 500 characters)</param>
    /// <param name="replyParentMessageId">Optional message id of the message the bot should reply to</param>
    /// <param name="forSourceOnly">When shared chat is in use, will send it to all chat's if true. See https://dev.twitch.tv/docs/api/reference/#send-chat-message</param>
    /// <param name="broadcaster">The stream (as <see cref="TwitchUser"/>) the message will be sent to. By default, uses the Receiver</param>
    /// <exception cref="NullReferenceException">Bot is not initialized. Or Api is not initialized</exception>
    public static async Task SendMessage(string message, string? replyParentMessageId = null, bool forSourceOnly = true,
        TwitchUser? broadcaster = null)
    {
        if (Instance == null)
            throw new NullReferenceException("TwitchBot is not initialized.");

        if (Instance.IsLinked)
        {
            await Instance._data!.CallAsync("send_message", message, replyParentMessageId!, forSourceOnly,
                broadcaster?.ToGodotObject() ?? new Variant()!);
            return;
        }

        if (TwitchApi.Instance == null) throw new NullReferenceException("TwitchApi is not initialized.");
        if (Instance.Receiver == null) throw new NullReferenceException("TwitchBot.Receiver is not set.");
        if (Instance.Sender == null) throw new NullReferenceException("TwitchBot.Sender is not set.");

        var cmb = new TwitchSendChatMessageBody
        {
            BroadcasterId = Instance.Receiver.Id,
            SenderId = Instance.Sender.Id,
            ReplyParentMessageId = replyParentMessageId,
            ForSourceOnly = forSourceOnly,
            Message = message,
        };

        await TwitchApi.Instance.SendChatMessage(cmb);
    }

    /// <summary>
    /// Sends a message to the chat as bot (with bot badge).
    /// </summary>
    /// <param name="message">Message the bot should send. If the message is longer than 500 characters, it will send multiple messages</param>
    /// <param name="replyParentMessageId">Optional message id of the message the bot should reply to</param>
    /// <param name="forSourceOnly">see https://dev.twitch.tv/docs/api/reference/#send-chat-message</param>
    /// <param name="broadcaster">The stream (as <see cref="TwitchUser"/>) the message will be sent to. By default, uses the Receiver</param>
    /// <exception cref="NullReferenceException"></exception>
    public static async Task SendLongMessage(string message, string? replyParentMessageId = null,
        bool forSourceOnly = true,
        TwitchUser? broadcaster = null)
    {
        if(string.IsNullOrWhiteSpace(message)) return;
        
        foreach (var chunk in message.Chunk(500))
        {
            await SendMessage(chunk.ToString()!, replyParentMessageId, forSourceOnly, broadcaster);
        }
    }

    // message: String, color: TwitchAnnouncementColor = TwitchAnnouncementColor.PRIMARY, for_source_only = true, broadcaster: TwitchUser = null
    public static async Task Announcement(string message, TwitchAnnouncementColor? color = null, bool forSourceOnly = true, TwitchUser? broadcaster = null)
    {
        color ??= TwitchAnnouncementColor.Primary;

        if (Instance == null)
            throw new NullReferenceException("TwitchBot is not initialized.");

        if (Instance.IsLinked)
        {
            await Instance._data!.CallAsync("send_announcement", message, color.ToGodotObject()!,
                forSourceOnly,
                broadcaster?.ToGodotObject() ?? new Variant()!);
            return;
        }

        if (TwitchApi.Instance == null) throw new NullReferenceException("TwitchApi is not initialized.");

        var cmb = new TwitchSendChatAnnouncementBody()
        {
            Message = message,
            Color = color.Value
        };

        if (broadcaster?.Id == null)
        {
            throw new NullReferenceException("Broadcaster is not set and is required when this is not added in the scene tree.");
        }
        
        if(Instance.Sender?.Id == null)
        {
            throw new NullReferenceException("Sender is not set and is required when this is not added in the scene tree.");
        }

        await TwitchApi.Instance.SendChatAnnouncement(cmb, broadcaster.Id!, Instance.Sender.Id!);
    }

    public static async Task Shoutout(TwitchUser fromUser, TwitchUser targetUser)
    {
        if (Instance == null)
            throw new NullReferenceException("TwitchBot is not initialized.");

        if (Instance.IsLinked)
        {
            await Instance._data!.CallAsync("send_shoutout", fromUser.ToGodotObject(), targetUser.ToGodotObject());
            return;
        }

        if (TwitchApi.Instance == null) throw new NullReferenceException("TwitchApi is not initialized.");

        if(Instance.Sender?.Id == null)
        {
            throw new NullReferenceException("Sender is not set and is required when this is not added in the scene tree.");
        }
        
        await TwitchApi.Instance.SendAShoutout(fromUser.Id!, targetUser.Id!, Instance.Sender.Id);
    }

    public static TwitchBot? FromObject(GodotObject? data)
    {
        if (data == null)
        {
            return null;
        }

        Instance = new TwitchBot();
        Instance._data = data;
        Instance.SetMeta("_twitcher_sharp_instance", Instance);
        return Instance;
    }

    public GodotObject ToGodotObject()
    {
        if (_data != null)
        {
            return _data;
        }

        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_bot.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("sender", Sender?.ToGodotObject() ?? new Variant());
        instance.Set("receiver", Receiver?.ToGodotObject() ?? new Variant());
        _data = instance;
        instance.SetMeta("_twitcher_sharp_instance", this);
        return instance;
    }

    public void FreeInstance()
    {
        if (_data is not null && !_data.IsQueuedForDeletion()) _data.RemoveMeta("_twitcher_sharp_instance");
        Instance = null;
    }

    public override void _Notification(int what)
    {
        if (what == NotificationPredelete) FreeInstance();
    }
}