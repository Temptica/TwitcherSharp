using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ExtensionBitsTransactionCreate;

public partial class TwitchExtensionBitsTransactionCreateEvent : RefCounted, ITwitcherSharpEventSub<TwitchExtensionBitsTransactionCreateEvent>
{
    /// <summary> 
    /// Client ID of the extension.
    /// </summary>
    public string ExtensionClientId { get; set; }

    /// <summary> 
    /// Transaction ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The transaction’s user ID.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The transaction’s user login.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The transaction’s user display name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// Additional information about a product acquired via a Twitch Extension Bits transaction.
    /// </summary>
    public TwitchProduct Product { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsTransactionCreateEvent object.
    /// </summary> 
    public static TwitchExtensionBitsTransactionCreateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchExtensionBitsTransactionCreateEvent
        {
            ExtensionClientId = data.Get("extension_client_id").AsString(),
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Product = data.Get("product").As<TwitchProduct>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_extension_bits_transaction_create.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("extension_client_id", ExtensionClientId);
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("product", Product);
        return request;
    }
}
