using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ConduitShardDisabled;

public partial class TwitchConduitShardDisabledCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchConduitShardDisabledCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchConduitShardDisabledCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client ID in the application access token.
    /// </summary>
    public string ClientId { get; set; } = clientId;

    /// <summary> 
    /// The conduit ID to receive events for. If omitted, events for all of this client’s conduits are sent.
    /// </summary>
    public string? ConduitId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchConduitShardDisabledCondition object.
    /// </summary> 
    public static TwitchConduitShardDisabledCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchConduitShardDisabledCondition(data.Read("client_id", static v => v.AsString()))
        {
            ConduitId = data.Read("conduit_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_conduit_shard_disabled.gd", "Condition");
        request.SetValue("client_id", ClientId);
        if(ConduitId != null) request.SetValue("conduit_id", ConduitId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
            {"conduit_id", ConduitId!},
        };
    }
}
