using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public abstract partial class TwitchCommandBase : RefCounted, ITwitcherSharp
{
    private const string BaseScriptPath = "res://addons/twitcher/chat/twitch_command_base.gd";

    protected GodotObject Data = null!;

    /// <summary>
    /// The wrappers <see cref="AllCommands"/> handed out, by node, so each command is wrapped (and its signals are
    /// connected) once.
    /// </summary>
    private static readonly Dictionary<ulong, TwitchCommandBase> CommandWrappers = [];

    /// <summary>
    /// The commands in the tree: twitcher's <c>ALL_COMMANDS</c>, which a <c>TwitchCommand</c> (or a help command)
    /// joins when it enters the tree and leaves when it exits. Contains and regex commands do not register there.
    /// </summary>
    public static IReadOnlyList<TwitchCommandBase> AllCommands
    {
        get
        {
            var commands = new List<TwitchCommandBase>();
            var seen = new HashSet<ulong>();
            using (var script = GD.Load<GDScript>(BaseScriptPath))
            using (var all = script.Get("ALL_COMMANDS"))
            using (var array = all.AsGodotArray())
            {
                foreach (var item in array)
                {
                    using (item)
                    {
                        if (item.AsGodotObject() is not { } node || !IsInstanceValid(node)) continue;
                        var id = node.GetInstanceId();
                        if (!CommandWrappers.TryGetValue(id, out var command))
                        {
                            command = MapCommand(node);
                            if (command is null) continue;
                            CommandWrappers[id] = command;
                        }

                        seen.Add(id);
                        commands.Add(command);
                    }
                }
            }

            // Drop the wrappers of commands that left the tree.
            foreach (var id in CommandWrappers.Keys.Where(id => !seen.Contains(id)).ToList())
            {
                CommandWrappers.Remove(id);
            }

            return commands;
        }
    }

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
    /// Whether this wrapper is linked to a twitcher node (it came from <c>FromObject</c> or <c>ToGodotObject</c>).
    /// A linked wrapper reads its properties from the node and writes them to it; an unlinked one keeps them until
    /// <c>ToGodotObject</c> creates the node.
    /// </summary>
    public bool IsLinked => Data is not null;

    /// <summary>
    /// Command name
    /// </summary>
    public string Command
    {
        get => LinkedRead(field, "command", static v => v.AsString());
        set => LinkedWrite(ref field, value, "command", value);
    } = null!;

    /// <summary>
    /// Description for the user
    /// </summary>
    public string Description
    {
        get => LinkedRead(field, "description", static v => v.AsString());
        set => LinkedWrite(ref field, value, "description", value);
    } = "";

    /// <summary>
    /// Wich role of user is allowed to use it
    /// </summary>
    public PermissionFlag PermissionLevel
    {
        get => LinkedRead(field, "permission_level", static v => (PermissionFlag)v.AsInt32());
        set => LinkedWrite(ref field, value, "permission_level", (int)value);
    }

    /// <summary>
    /// Where the command should be accepted
    /// </summary>
    public WhereFlag Where
    {
        get => LinkedRead(field, "where", static v => (WhereFlag)v.AsInt32());
        set => LinkedWrite(ref field, value, "where", (int)value);
    } = WhereFlag.Chat;

    /// <summary>
    /// All allowed users empty array means everyone. Assign a new list to change it: changing the returned list
    /// does not reach the twitcher node.
    /// </summary>
    public List<string> AllowedUsers
    {
        get => LinkedRead(field, "allowed_users", ReadStrings);
        set => LinkedWrite(ref field, value, "allowed_users", value.ToVariantArray());
    } = [];

    /// <summary>
    /// All chatrooms where the command listens to. Assign a new list to change it: changing the returned list does
    /// not reach the twitcher node.
    /// </summary>
    public List<string> ListenToChatrooms
    {
        get => LinkedRead(field, "listen_to_chatrooms", ReadStrings);
        set => LinkedWrite(ref field, value, "listen_to_chatrooms", value.ToVariantArray());
    } = [];

    /// <summary>
    /// Determines if the aliases and commands should be case-sensitive or not
    /// </summary>
    public bool CaseInsensitive
    {
        get => LinkedRead(field, "case_insensitive", static v => v.AsBool());
        set => LinkedWrite(ref field, value, "case_insensitive", value);
    } = true;

    /// <summary>
    /// Cooldown per user
    /// </summary>
    public double UserCooldown
    {
        get => LinkedRead(field, "user_cooldown", static v => v.AsDouble());
        set => LinkedWrite(ref field, value, "user_cooldown", value);
    }

    /// <summary>
    /// Global cooldown for the command
    /// </summary>
    public double GlobalCooldown
    {
        get => LinkedRead(field, "global_cooldown", static v => v.AsDouble());
        set => LinkedWrite(ref field, value, "global_cooldown", value);
    }

    /// <summary>
    /// The value of a property: read from the twitcher node when linked, else the one kept here.
    /// </summary>
    private protected T LinkedRead<T>(T unlinked, string property, Func<Variant, T> read) =>
        IsLinked ? Data.Read(property, read) : unlinked;

    /// <summary>
    /// Keeps the value of a property and writes it to the twitcher node when linked.
    /// </summary>
    private protected void LinkedWrite<T>(ref T field, T value, string property, Variant godotValue)
    {
        field = value;
        if (IsLinked) Data.SetValue(property, godotValue);
        else godotValue.Dispose();
    }

    private protected static List<string> ReadStrings(Variant value) => value.AsStringArray().ToList();

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

    protected void SetBaseProperties() => ConnectSignals();

    public TwitchCommandBase GetTypedCommand(GodotObject data) =>
        MapCommand(data) ?? throw new ArgumentException("Invalid command type", nameof(data));

    /// <summary>
    /// Wraps a command node in the wrapper of its twitcher class. A script extending a twitcher command (such as a
    /// game's own command) gets the wrapper of the twitcher class it extends. Null for anything else.
    /// </summary>
    private static TwitchCommandBase? MapCommand(GodotObject node)
    {
        // GetClass names the native class (Node); the twitcher class is the script's global name.
        Script? script;
        using (var scriptValue = node.GetScript()) script = scriptValue.AsGodotObject() as Script;
        while (script is not null)
        {
            string name = script.GetGlobalName();
            TwitchCommandBase? command = name switch
            {
                nameof(TwitchCommandHelp) => TwitchCommandHelp.FromObject(node),
                nameof(TwitchCommand) => TwitchCommand.FromObject(node),
                nameof(TwitchCommandContains) => TwitchCommandContains.FromObject(node),
                nameof(TwitchCommandRegex) => TwitchCommandRegex.FromObject(node),
                _ => null,
            };
            var baseScript = command is null ? script.GetBaseScript() : null;
            script.Dispose();
            if (command is not null) return command;
            script = baseScript;
        }

        return null;
    }

    /// <summary>
    /// Writes the base properties to a new twitcher node and links this wrapper to it.
    /// </summary>
    protected void GetBaseProperties(GodotObject data)
    {
        // Read before linking: once linked, the getters read the new node.
        data.SetValue("command", Command);
        data.SetValue("description", Description);
        data.SetValue("permission_level", (int)PermissionLevel);
        data.SetValue("where", (int)Where);
        data.SetValue("allowed_users", AllowedUsers.ToVariantArray());
        data.SetValue("listen_to_chatrooms", ListenToChatrooms.ToVariantArray());
        data.SetValue("case_insensitive", CaseInsensitive);
        data.SetValue("user_cooldown", UserCooldown);
        data.SetValue("global_cooldown", GlobalCooldown);
        Data = data;
    }
}