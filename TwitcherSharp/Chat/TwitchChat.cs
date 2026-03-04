using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;

namespace TwitcherSharp.Chat;

public partial class TwitchChat : Node, ITwitcherSharpSingleton<TwitchChat>
{
    protected TwitchChat()
    {
    }

    private GodotObject _data;
    public bool IsLinked => _data is not null;

    public static TwitchChat Instance { get; set; }

    /// <summary>
    /// Twitch API (Will automatically look for first TwitchApi (twitcher) in the scene tree
    /// </summary>
    public static TwitchApi Api { get; set; } = TwitchApi.CreateFromInstance();

    public TwitchUser BroadcasterUser
    {
        get => _data != null ? TwitchUser.FromObject(_data.Get("broadcaster_user").AsGodotObject()) : field;
        set
        {
            _data?.Set("broadcaster_user", value.ToGodotObject());
            field = value;
        }
    }

    public TwitchUser SenderUser
    {
        get => _data != null ? TwitchUser.FromObject(_data.Get("sender_user").AsGodotObject()) : field;
        set
        {
            _data?.Set("sender_user", value?.ToGodotObject());
            field = value;
        }
    }

    /// <summary>
    /// Media loader it uses for emotes and badges. (Will automatically look for first TwitchMediaLoader (twitcher) in the scene tree)
    /// </summary>
    public TwitchMediaLoader MediaLoader { get; set; } = TwitchMediaLoader.CreateFromInstance();

    /// <summary>
    /// Should it subscribe on ready
    /// </summary>
    public bool SubscibeOnReady { get; set; } = true;

    [Signal]
    public delegate void MessageReceivedEventHandler(TwitchChatMessage message);

    public void Subscribe() => _data.Call("subscribe");

    /// <summary>
    /// Sends a message to the chat. If twitchApi is connected and linked, it will use the c# code.
    /// If twitchApi is not connected or linked, it will use the Godot API if this class is linked.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="replyParentMessageId"></param>
    /// <returns></returns>
    /// <exception cref="Exception">throws if neither TwitchApi or TwitchChat is linked</exception>
    public async Task<TwitchSendChatMessageResponse.TwitchData[]> SendMessage(string message,
        string replyParentMessageId = null)
    {
        if (!Api.IsLinked)
        {
            if (!IsLinked) throw new Exception("TwitchChat is not linked to TwitchApi");

            return (await _data.CallAsync("send_message", message, replyParentMessageId))
                .AsGodotArray<GodotObject>()
                .Select(TwitchSendChatMessageResponse.TwitchData.FromObject)
                .ToArray();
        }

        var request = new TwitchSendChatMessageBody()
        {
            BroadcasterId = BroadcasterUser.Id,
            SenderId = SenderUser.Id,
            Message = message,
            ReplyParentMessageId = replyParentMessageId
        };

        var response = await Api.SendChatMessage(request);
        return response.Data;
    }

    private void ConnectSignals()
    {
        _data.Connect("message_received",
            Callable.From<GodotObject>(d => EmitSignalMessageReceived(TwitchChatMessage.FromObject(d))));
    }

    public static TwitchChat CreateFromInstance()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat.gd");
        var gdChat = script.New().AsGodotObject();
        var result = gdChat.Get("instance");
        if (result.VariantType != Variant.Type.Object) return Create();
        Instance = FromObject(result.AsGodotObject());
        return Instance;
    }

    public static TwitchChat Create()
    {
        Instance = new TwitchChat();
        return Instance;
    }

    public static TwitchChat FromObject(GodotObject data)
    {
        throw new NotImplementedException();
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}