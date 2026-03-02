using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

/// <summary>
/// Helper to send messages with a second bot user and the corrosponding bot badge.
/// Take care that setup is needed that it actually works! The right scopes for the target channel 
/// and the sender user has to be set. 
/// See also https://dev.twitch.tv/docs/api/reference/#send-chat-message
/// <p> Note: This node is connected to the godot object. Setting values here will also set those in the godotScript and vice versa</p>
/// </summary>
public partial class TwitchBot : Resource, ITwitcherSharpSingleton<TwitchBot>
{
    private GodotObject _data;
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

    public TwitchUser Receiver {
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
    /// Sends a message as the bot user the targeted broadcaster
    /// </summary>
    /// <param name="message">Message the bot should send (max 500 characters)</param>
    /// <param name="replyParentMessageId">Optional message id of the message the bot should reply to</param>
    /// <param name="forSourceOnly">When shared chat is in use, will send it to all chat's if true. See https://dev.twitch.tv/docs/api/reference/#send-chat-message</param>
    /// <param name="broadcaster">The stream (as <see cref="TwitchUser"/>) the message will be sent to. By default, uses the Receiver</param>
    /// <exception cref="NullReferenceException"></exception>
    public static void SendMessage(string message, string replyParentMessageId = "", bool forSourceOnly = true,
        TwitchUser broadcaster = null)
    {
        if(Instance?._data == null) throw new NullReferenceException("Bot is not initialized. Call FromObject and add the resulting node to the scene tree.");
        Instance._data.Call("send_message", message, replyParentMessageId, forSourceOnly, broadcaster?.ToGodotObject());
    }

    /// <summary>
    /// Sends a message as the bot user the targeted broadcaster
    /// </summary>
    /// <param name="message">Message the bot should send. If the message is longer than 500 characters, it will send multiple messages</param>
    /// <param name="replyParentMessageId">Optional message id of the message the bot should reply to</param>
    /// <param name="forSourceOnly">see https://dev.twitch.tv/docs/api/reference/#send-chat-message</param>
    /// <param name="broadcaster">The stream (as <see cref="TwitchUser"/>) the message will be sent to. By default, uses the Receiver</param>
    /// <exception cref="NullReferenceException"></exception>
    public static void SendLongMessage(string message, string replyParentMessageId = "", bool forSourceOnly = true,
        TwitchUser broadcaster = null)
    {
        foreach (var chunk in message.Chunk(500))
        {
            SendMessage(chunk.ToString(), replyParentMessageId, forSourceOnly, broadcaster);
        }
    }
    

    /// <summary>
    /// Transforms the godot data into a TwitchBot object.
    /// Note: This node is connected to the godot object. Setting values here will also set those in the godotScript and vice versa
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static TwitchBot FromObject(GodotObject data)
    {
        if(data == null)
        {
            return null;
        }
        var instance = new TwitchBot();
        instance._data = data;
        return instance;
    }

    /// <summary>
    /// Creates a new instance. It will try to find an existing gdScript TwitchBot instance and bind to this one.
    /// <p>If none can be found, it will instead not connect and be it's own instance. </p>
    /// </summary>
    /// <returns>The created instance</returns>
    public static TwitchBot Create()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_bot.gd");
        var gdBot = script.New().AsGodotObject();
        var result = gdBot.Get("instance");
        
        if(result.VariantType == Variant.Type.Object)
        {
            Instance = FromObject(result.AsGodotObject());
            return Instance;
        }
        
        Instance = new TwitchBot();
        return Instance;
    }

    /// <summary>
    /// Returns the linked GodotObject. If there is no linked object, it will create a new one based on this instance and link it.
    /// </summary>
    /// <returns></returns>
    public GodotObject ToGodotObject()
    {
        if(_data != null)
        {
            return _data;
        }
        
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_bot.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("sender", Sender.ToGodotObject());
        instance.Set("receiver", Receiver.ToGodotObject());
        _data = instance;
        return instance;
    }
}