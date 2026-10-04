using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ExtensionBitsTransactionCreate;

public partial class TwitchExtensionBitsTransactionCreateEvent : RefCounted, ITwitcherSharpEventSub<TwitchExtensionBitsTransactionCreateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// Client ID of the extension.
    /// </summary>
    public string? ExtensionClientId { get; set; }

    /// <summary> 
    /// Transaction ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The transaction’s broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The transaction’s user ID.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The transaction’s user login.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The transaction’s user display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// Additional information about a product acquired via a Twitch Extension Bits transaction.
    /// </summary>
    public TwitchProduct? Product { get => field ??= _data.Get<TwitchProduct>("product"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsTransactionCreateEvent object.
    /// </summary> 
    public static TwitchExtensionBitsTransactionCreateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionBitsTransactionCreateEvent
        {
            ExtensionClientId = data.Read("extension_client_id", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_extension_bits_transaction_create.gd", "Event");
        if(ExtensionClientId != null) request.SetValue("extension_client_id", ExtensionClientId);
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Product != null) request.SetObject("product", Product);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
