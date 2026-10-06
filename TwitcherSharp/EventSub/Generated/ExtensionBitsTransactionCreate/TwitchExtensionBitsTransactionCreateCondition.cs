using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ExtensionBitsTransactionCreate;

public partial class TwitchExtensionBitsTransactionCreateCondition(string extensionClientId) : RefCounted, ITwitcherSharpCondition<TwitchExtensionBitsTransactionCreateCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchExtensionBitsTransactionCreateCondition);

    /// <summary> 
    /// The client ID of the extension.
    /// </summary>
    public string ExtensionClientId { get; set; } = extensionClientId;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsTransactionCreateCondition object.
    /// </summary> 
    public static TwitchExtensionBitsTransactionCreateCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionBitsTransactionCreateCondition(data.Read("extension_client_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_extension_bits_transaction_create.gd", "Condition");
        request.SetValue("extension_client_id", ExtensionClientId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchExtensionBitsTransactionCreateCondition FromDictionary(Dictionary data)
    {
        return new TwitchExtensionBitsTransactionCreateCondition(data["extension_client_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"extension_client_id", ExtensionClientId},
        };
    }
}
