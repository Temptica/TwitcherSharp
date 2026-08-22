using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public abstract partial class TwitchCommandBase : RefCounted, ITwitcherSharp
{
    protected GodotObject Data = null!;
    public static List<TwitchCommandBase> AllCommands = [];

    #region Signals

    /// <summary>
    /// Called when the command got received in the right format
    /// </summary>
    [Signal]
    public delegate void CommandReceivedEventHandler(string fromUsername, TwitchCommandInfo info, string[] args);

    /// <summary>
    /// Called when the command got received in the wrong format
    /// </summary>
    [Signal]
    public delegate void ReceivedInvalidCommandEventHandler(string fromUsername, TwitchCommandInfo info, string[] args);

    /// <summary>
    /// Called when the command got received with not the right permissions
    /// </summary>
    [Signal]
    public delegate void InvalidPermissionEventHandler(string fromUsername, TwitchCommandInfo info, string[] args);

    /// <summary>
    /// Called when the user tries to use the command that is still on cooldown (remaining cooldown in seconds)
    /// </summary>
    [Signal]
    public delegate void CooldownEventHandler(string fromUsername, TwitchCommandInfo info, string[] args,
        float cooldownRemainingInS);

    #endregion

    #region Enums

    /// <summary>
    /// Required permission to execute the command
    /// </summary>
    [Flags]
    public enum PermissionFlag
    {
        Everyone = 0,
        Vip = 1,
        Sub = 2,
        Mod = 4,
        Streamer = 8,
        ModStreamer = Mod | Streamer,
        NonRegular = 15
    }

    /// <summary>
    /// Where the command should be accepted
    /// </summary>
    public enum WhereFlag
    {
        Chat = 1,
        Whisper = 2,
        Anywhere = 3
    }

    #endregion

    /// <summary>
    /// Command name
    /// </summary>
    public string Command { get; set; } = null!;

    /// <summary>
    /// Description for the user
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Wich role of user is allowed to use it
    /// </summary>
    public PermissionFlag PermissionLevel { get; set; }

    /// <summary>
    /// Where the command should be accepted
    /// </summary>
    public WhereFlag Where { get; set; } = WhereFlag.Chat;

    /// <summary>
    /// All allowed users empty array means everyone
    /// </summary>
    public List<string> AllowedUsers { get; set; } = [];

    /// <summary>
    /// All chatrooms where the command listens to
    /// </summary>
    public List<string> ListenToChatrooms { get; set; } = [];

    /// <summary>
    /// Determines if the aliases and commands should be case-sensitive or not
    /// </summary>
    public bool CaseInsensitive { get; set; } = true;

    /// <summary>
    /// Cooldown per user
    /// </summary>
    public double UserCooldown { get; set; } = 0;

    /// <summary>
    /// Global cooldown for the command
    /// </summary>
    public double GlobalCooldown { get; set; } = 0;

    protected void ConnectSignals()
    {
        Data.Connect(GodotObject.CommandReceived,
            Callable.FromTwitcherSharp<TwitchCommandInfo>(EmitSignalCommandReceived));
        Data.Connect(GodotObject.ReceivedInvalidCommand,
            Callable.FromTwitcherSharp<TwitchCommandInfo>(EmitSignalReceivedInvalidCommand));
        Data.Connect(GodotObject.InvalidPermission,
            Callable.FromTwitcherSharp<TwitchCommandInfo>(EmitSignalInvalidPermission));
        Data.Connect(GodotObject.Cooldown, Callable.FromTwitcherSharp<TwitchCommandInfo>(EmitSignalCooldown));
    }

    public float GetUserCooldown(string fromUsername) => Data.Call("get_user_cooldown", fromUsername).AsSingle();
    public bool IsOnCooldown(string fromUsername) => Data.Call("is_on_cooldown", fromUsername).AsBool();
    public double GetGlobalCooldown() => Data.Call("get_globalcooldown").AsDouble();
    public bool IsOnGlobalCooldown() => Data.Call("is_on_globalcooldown").AsBool();

    public abstract GodotObject ToGodotObject();

    protected void SetBaseProperties()
    {
        Command = Data.Get("command").AsString();
        Description = Data.Get("description").AsString();
        PermissionLevel = (PermissionFlag)Data.Get("permission_level").AsInt32();
        Where = (WhereFlag)Data.Get("where").AsInt32();
        AllowedUsers = Data.Get("allowed_users").AsStringArray().ToList();
        ListenToChatrooms = Data.Get("listen_to_chatrooms").AsStringArray().ToList();
        CaseInsensitive = Data.Get("case_insensitive").AsBool();
        UserCooldown = Data.Get("user_cooldown").AsInt32();
        GlobalCooldown = Data.Get("global_cooldown").AsInt32();
        AllCommands = Data.Get("all_commands").AsGodotArray<GodotObject>().Select(GetTypedCommand).ToList();

        ConnectSignals();
    }

    public TwitchCommandBase GetTypedCommand(GodotObject data)
    {
        return data.GetClass() switch
        {
            nameof(TwitchCommand) => (TwitchCommandBase?)TwitchCommand.FromObject(data),
            nameof(TwitchCommandContains) => TwitchCommandContains.FromObject(data),
            nameof(TwitchCommandHelp) => TwitchCommandHelp.FromObject(data),
            _ => throw new ArgumentException("Invalid command type", nameof(data)),
        } ?? throw new ArgumentException("Invalid command data", nameof(data));
    }

    protected void GetBaseProperties(GodotObject data)
    {
        Data = data;
        data.Set("command", Command);
        data.Set("description", Description);
        data.Set("permission_level", (int)PermissionLevel);
        data.Set("where", (int)Where);
        data.Set("allowed_users", AllowedUsers.ToVariantArray());
        data.Set("listen_to_chatrooms", ListenToChatrooms.ToVariantArray());
        data.Set("case_insensitive", CaseInsensitive);
        data.Set("user_cooldown", UserCooldown);
        data.Set("global_cooldown", GlobalCooldown);
        data.Set("all_commands", new Godot.Collections.Array(AllCommands.Select(c => c?.ToGodotObject() ?? new Variant()).ToArray()));
    }
}