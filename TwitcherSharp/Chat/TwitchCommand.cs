using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Array = System.Array;

namespace TwitcherSharp.Chat;

public partial class TwitchCommand : Resource, ITwitcherSharp<TwitchCommand>
{
    private GodotObject _data;

    #region Signals

    [Signal]
    public delegate void CommandReceivedEventHandler(string fromUsername, TwitchCommandInfo info, string[] args);

    [Signal]
    public delegate void ReceivedInvalidCommandEventHandler(string fromUsername, TwitchCommandInfo info, string[] args);

    [Signal]
    public delegate void CooldownEventHandler(string fromUsername, TwitchCommandInfo info, string[] args,
        float cooldownRemainingInS);

    #endregion

    #region Enums

    [Flags]
    public enum PermissionFlags
    {
        Everyone = 0,
        Vip = 1,
        Sub = 2,
        Mod = 4,
        Streamer = 8,
        ModStreamer = Mod | Streamer,
        NonRegular = 15
    }

    public enum WhereFlag
    {
        Chat = 1,
        Whisper = 2,
        Anywhere = 3
    }

    #endregion

    public string[] CommandPrefixes { get; set; } = { "!" };
    public string Command { get; set; }
    public string[] Aliases { get; set; } = [];
    public string Description { get; set; }
    public int ArgsMin { get; set; } = 0;
    public int ArgsMax { get; set; } = -1;
    public PermissionFlags PermissionLevel { get; set; } = PermissionFlags.Everyone;
    public WhereFlag Where { get; set; } = WhereFlag.Chat;
    public string[] AllowedUsers { get; set; } = Array.Empty<string>();
    public string[] ListenToChatrooms { get; set; } = Array.Empty<string>();
    public bool CaseInsensitive { get; set; } = true;
    public float UserCooldown { get; set; } = 0;
    public float GlobalCooldown { get; set; } = 0;
    public GodotObject Eventsub { get; set; }

    private void ConnectToSignals()
    {
        _data.ConnectCommandReceived(EmitSignalCommandReceived);
        _data.ConnectReceivedInvalidCommand(EmitSignalReceivedInvalidCommand);
        _data.ConnectCooldown(EmitSignalCooldown);
    }

    public static TwitchCommand FromObject(GodotObject data)
    {
        var command = new TwitchCommand
        {
            _data = data,
            CommandPrefixes = data.Get("command_prefixes").AsStringArray(),
            Command = data.Get("command").AsString(),
            Description = data.Get("description").AsString(),
            ArgsMin = data.Get("args_min").AsInt32(),
            ArgsMax = data.Get("args_max").AsInt32(),
            PermissionLevel = data.Get("permission_level").As<PermissionFlags>(),
            Where = data.Get("where").As<WhereFlag>(),
            AllowedUsers = data.Get("allowed_users").AsStringArray(),
            ListenToChatrooms = data.Get("listen_to_chatrooms").AsStringArray(),
            CaseInsensitive = data.Get("case_insensitive").AsBool(),
            UserCooldown = data.Get("user_cooldown").AsInt32(),
            GlobalCooldown = data.Get("global_cooldown").AsInt32(),
            Eventsub = data.Get("eventsub").AsGodotObject(),
        };

        command.ConnectToSignals();
        return command;
    }
}