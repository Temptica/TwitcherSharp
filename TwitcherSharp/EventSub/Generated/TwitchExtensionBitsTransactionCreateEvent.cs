using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchExtensionBitsTransactionCreateEvent : Resource, ITwitcherSharpEventSub<TwitchExtensionBitsTransactionCreateEvent>
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

	public static TwitchExtensionBitsTransactionCreateEvent FromData(Dictionary data)
	{
	    return new TwitchExtensionBitsTransactionCreateEvent
	    {
			ExtensionClientId = data["extension_client_id"].AsString(),
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Product = TwitchProduct.FromData(data["product"].AsGodotDictionary()),
		};
	}

}
