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

    public float GetUserCooldown(string fromUsername) => Data.Invoke("get_user_cooldown", static v => v.AsSingle(), fromUsername);
    public bool IsOnCooldown(string fromUsername) => Data.Invoke("is_on_cooldown", static v => v.AsBool(), fromUsername);
    public double GetGlobalCooldown() => Data.Invoke("get_globalcooldown", static v => v.AsDouble());
    public bool IsOnGlobalCooldown() => Data.Invoke("is_on_globalcooldown", static v => v.AsBool());

    public abstract GodotObject ToGodotObject();

    protected void SetBaseProperties()
    {
        Command = Data.Read("command", static v => v.AsString());
        Description = Data.Read("description", static v => v.AsString());
        PermissionLevel = (PermissionFlag)Data.Read("permission_level", static v => v.AsInt32());
        Where = (WhereFlag)Data.Read("where", static v => v.AsInt32());
        AllowedUsers = Data.Read("allowed_users", static v => v.AsStringArray()).ToList();
        ListenToChatrooms = Data.Read("listen_to_chatrooms", static v => v.AsStringArray()).ToList();
        CaseInsensitive = Data.Read("case_insensitive", static v => v.AsBool());
        UserCooldown = Data.Read("user_cooldown", static v => v.AsInt32());
        GlobalCooldown = Data.Read("global_cooldown", static v => v.AsInt32());
        AllCommands = Data.Read("all_commands", static v => v.AsGodotArray<GodotObject>()).Select(GetTypedCommand).ToList();

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
        data.SetValue("command", Command);
        data.SetValue("description", Description);
        data.SetValue("permission_level", (int)PermissionLevel);
        data.SetValue("where", (int)Where);
        data.SetValue("allowed_users", AllowedUsers.ToVariantArray());
        data.SetValue("listen_to_chatrooms", ListenToChatrooms.ToVariantArray());
        data.SetValue("case_insensitive", CaseInsensitive);
        data.SetValue("user_cooldown", UserCooldown);
        data.SetValue("global_cooldown", GlobalCooldown);
        data.SetValue("all_commands", new Godot.Collections.Array(AllCommands.Select(c => c?.ToGodotObject() ?? new Variant()).ToArray()));
    }
}