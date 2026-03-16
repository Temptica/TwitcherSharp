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
    private GodotObject _data;
    public bool IsLinked => _data is not null && !_data.IsQueuedForDeletion();
    public static TwitchBot Instance { get; private set; }

    public TwitchUser Sender
    {
        get => _data != null
            ? TwitchUser.FromObject(_data.Get("sender").AsGodotObject())
            : field;
        set
        {
            _data?.Set("sender", value.ToGodotObject());
            field = value;
        }
    }

    public TwitchUser Receiver
    {
        get => _data != null
            ? TwitchUser.FromObject(_data.Get("receiver").AsGodotObject())
            : field;
        set
        {
            _data?.Set("receiver", value.ToGodotObject());
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
    public static async Task SendMessage(string message, string replyParentMessageId = null, bool forSourceOnly = true,
        TwitchUser broadcaster = null)
    {
        if (Instance == null)
            throw new NullReferenceException("TwitchBot is not initialized.");

        if (Instance.IsLinked)
        {
            await Instance._data.CallAsync("send_message", message, replyParentMessageId, forSourceOnly, broadcaster?.ToGodotObject());
            return;
        }
            
        if (TwitchApi.Instance == null) throw new NullReferenceException("TwitchApi is not initialized.");
        
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
    public static async Task SendLongMessage(string message, string replyParentMessageId = "", bool forSourceOnly = true,
        TwitchUser broadcaster = null)
    {
        foreach (var chunk in message.Chunk(500))
        {
            await SendMessage(chunk.ToString(), replyParentMessageId, forSourceOnly, broadcaster);
        }
    }

    public static TwitchBot FromObject(GodotObject data)
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

    public static TwitchBot GetOrCreateInstance()
    {
        if (Instance != null) return Instance;
        
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_bot.gd");
        var twitchBot = script.New().AsGodotObject();
        var instance = twitchBot.Get("instance");
    
        if (instance.VariantType != Variant.Type.Object)
        {
            var root = (Engine.GetMainLoop() as SceneTree)!.Root;
            root.AddChild(twitchBot as Node);
            FromObject(twitchBot);
            return Instance;
        }
        
        FromObject(instance.AsGodotObject());
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
        instance.Set("sender", Sender.ToGodotObject());
        instance.Set("receiver", Receiver.ToGodotObject());
        _data = instance;
        instance.SetMeta("_twitcher_sharp_instance", this);
        return instance;
    }
    
    public void FreeInstance()
    {
        if(_data is not null && !_data.IsQueuedForDeletion()) _data.RemoveMeta("_twitcher_sharp_instance");
        Instance = null;
    }

    public override void _Notification(int what)
    {
        if (what == NotificationPredelete) FreeInstance();
    }
}