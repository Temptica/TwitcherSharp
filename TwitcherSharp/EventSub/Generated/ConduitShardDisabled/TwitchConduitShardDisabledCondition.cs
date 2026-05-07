using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ConduitShardDisabled;

public partial class TwitchConduitShardDisabledCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchConduitShardDisabledCondition>
{
    public string Name => nameof(TwitchConduitShardDisabledCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client ID in the application access token.
    /// </summary>
    public string ClientId { get; set; } = clientId;

    /// <summary> 
    /// The conduit ID to receive events for. If omitted, events for all of this client’s conduits are sent.
    /// </summary>
    public string ConduitId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchConduitShardDisabledCondition object.
    /// </summary> 
    public static TwitchConduitShardDisabledCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchConduitShardDisabledCondition(data.Get("client_id").AsString())
        {
            ConduitId = data.Get("conduit_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_conduit_shard_disabled.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("client_id", ClientId);
        request.Set("conduit_id", ConduitId);
        return request;
    }

    public static TwitchConduitShardDisabledCondition FromDictionary(Dictionary data)
    {
        return new TwitchConduitShardDisabledCondition(data["client_id"].AsString())
        {
            ConduitId = data["conduit_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"client_id", ClientId},
            {"conduit_id", ConduitId},
        };
    }
}
