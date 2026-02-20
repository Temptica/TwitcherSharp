using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ExtensionBitsTransactionCreate;

public partial class TwitchExtensionBitsTransactionCreateCondition : Resource, ITwitcherSharpCondition<TwitchExtensionBitsTransactionCreateCondition>
{
    public string Name => nameof(TwitchExtensionBitsTransactionCreateCondition);

    /// <summary> 
    /// The client ID of the extension.
    /// </summary>
    public string ExtensionClientId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsTransactionCreateCondition object.
    /// </summary> 
    public static TwitchExtensionBitsTransactionCreateCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchExtensionBitsTransactionCreateCondition
        {
            ExtensionClientId = data.Get("extension_client_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_extension_bits_transaction_create.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("extension_client_id", ExtensionClientId);
        return request;
    }
}
