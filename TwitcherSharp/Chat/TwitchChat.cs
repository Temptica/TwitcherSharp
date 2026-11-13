using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Chat;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;

namespace TwitcherSharp.Chat;

public partial class TwitchChat : RefCounted, ITwitcherSharpSingleton<TwitchChat>
{
    private GodotObject? _data;
    public bool IsLinked => _data is not null;

    public static string ScriptPath => "res://addons/twitcher/chat/twitch_chat.gd";

    public static TwitchChat? Instance
    {
        get => ITwitcherSharpSingleton<TwitchChat>.Instance;
        private set => ITwitcherSharpSingleton<TwitchChat>.Instance = value;
    }
    public static TwitchChat CreateInstance(Action<TwitchChat>? configure = null) =>
        ITwitcherSharpSingleton<TwitchChat>.CreateInstance(configure);
    
    public static TwitchChat Required => ITwitcherSharpSingleton<TwitchChat>.Required;

    /// <summary>
    /// Twitch API used to send messages. Defaults to <see cref="TwitchApi.Instance"/>, the TwitchAPI node in the tree;
    /// no node is created for it.
    /// </summary>
    public static TwitchApi? Api { get => field ?? TwitchApi.Instance; set; }

    public TwitchUser? BroadcasterUser
    {
        get => _data != null ? _data.Get<TwitchUser>("broadcaster_user") : field;
        set
        {
            _data?.SetObject("broadcaster_user", value);
            field = value;
        }
    }

    public TwitchUser? SenderUser
    {
        get => _data != null ? _data.Get<TwitchUser>("sender_user") : field;
        set
        {
            _data?.SetObject("sender_user", value);
            field = value;
        }
    }

    /// <summary>
    /// Media loader it uses for emotes and badges. (Will automatically look for first TwitchMediaLoader (twitcher) in the scene tree)
    /// </summary>
    public TwitchMediaLoader? MediaLoader { get => field ?? TwitchMediaLoader.Instance; set; }

    /// <summary>
    /// Should it subscribe on ready
    /// </summary>
    public bool SubscibeOnReady { get; set; } = true;

    [Signal]
    public delegate void MessageReceivedEventHandler(TwitchChatMessage message);

    public async Task Subscribe() => await _data!.InvokeAsync("subscribe");

    /// <summary>
    /// Sends a message to the chat. If twitchApi is connected and linked, it will use the c# code.
    /// If twitchApi is not connected or linked, it will use the Godot API if this class is linked.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="replyParentMessageId"></param>
    /// <returns></returns>
    /// <exception cref="Exception">throws if neither TwitchApi or TwitchChat is linked</exception>
    public async Task<TwitchSendChatMessageResponse.TwitchResponseData[]> SendMessage(string message,
        string? replyParentMessageId = null)
    {
        var api = Api;
        if (api is not { IsLinked: true })
        {
            if (!IsLinked) throw new Exception("TwitchChat is not linked to TwitchApi");

            return (await _data!.CallAsync("send_message", message, replyParentMessageId ?? ""))
                .AsGodotArray<GodotObject>()
                .Select(TwitchSendChatMessageResponse.TwitchResponseData.FromObject)
                .OfType<TwitchSendChatMessageResponse.TwitchResponseData>()
                .ToArray();
        }

        if (BroadcasterUser == null) throw new Exception("TwitchChat.BroadcasterUser is not set.");
        if (SenderUser == null) throw new Exception("TwitchChat.SenderUser is not set.");

        var request = new TwitchSendChatMessageBody()
        {
            BroadcasterId = BroadcasterUser.Id,
            SenderId = SenderUser.Id,
            Message = message,
            ReplyParentMessageId = replyParentMessageId
        };

        var response = await api.SendChatMessage(request);
        return response.Data ?? [];
    }

    private void ConnectSignals()
    {
        _data!.Connect("message_received",
            Callable.From<GodotObject>(d => EmitSignalMessageReceived(TwitchChatMessage.FromObject(d)!)));
    }

    public static TwitchChat? FromObject(GodotObject? data)
    {
        if (data == null) return null;

        var chat = new TwitchChat { _data = data };
        chat.SetMeta("_twitcher_sharp_instance", chat);
        chat.ConnectSignals();
        Instance = chat;
        return chat;
    }

    public GodotObject ToGodotObject()
    {
        if (_data != null)
        {
            return _data;
        }

        var instance = InteropExtension.NewObject(ScriptPath);
        instance.SetObject("broadcaster_user", BroadcasterUser);
        instance.SetObject("sender_user", SenderUser);
        instance.SetMeta("_twitcher_sharp_instance", this);
        _data = instance;
        ConnectSignals();
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