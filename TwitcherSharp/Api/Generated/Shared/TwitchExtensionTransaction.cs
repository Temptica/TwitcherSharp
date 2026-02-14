using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchExtensionTransaction : Resource, ITwitcherSharp<TwitchExtensionTransaction>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Timestamp { get; set; }
	public string BroadcasterId { get; set; }
	public string BroadcasterLogin { get; set; }
	public string BroadcasterName { get; set; }
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public string ProductType { get; set; }
	public TwitchProductData ProductData { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionTransaction object.
    /// </summary> 
    public static TwitchExtensionTransaction FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchExtensionTransaction
		{
			Id = data.Get("id").AsString(),
			Timestamp = data.Get("timestamp").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			ProductType = data.Get("product_type").AsString(),
			ProductData = data.Get("product_data").As<TwitchProductData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_transaction.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("timestamp", Timestamp);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("product_type", ProductType);
		request.Set("product_data", ProductData);
		return request;
	}
}
