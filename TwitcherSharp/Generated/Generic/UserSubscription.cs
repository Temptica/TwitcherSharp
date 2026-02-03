using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UserSubscription : Resource, ITwitcherSharp<UserSubscription>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string BroadcasterLogin { get; set; }
	public string BroadcasterName { get; set; }
	public string GifterId { get; set; }
	public string GifterLogin { get; set; }
	public string GifterName { get; set; }
	public bool IsGift { get; set; }
	public string Tier { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UserSubscription object.
    /// </summary> 
    public static UserSubscription FromObject(GodotObject data)
    {
        return new UserSubscription
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			GifterId = data.Get("gifter_id").AsString(),
			GifterLogin = data.Get("gifter_login").AsString(),
			GifterName = data.Get("gifter_name").AsString(),
			IsGift = data.Get("is_gift").AsBool(),
			Tier = data.Get("tier").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_subscription.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("gifter_id", GifterId);
		request.Set("gifter_login", GifterLogin);
		request.Set("gifter_name", GifterName);
		request.Set("is_gift", IsGift);
		request.Set("tier", Tier);
		return request;
	}
}
