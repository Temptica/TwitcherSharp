using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

/// <summary> 
///  
/// </summary>
public partial class TwitchCheckUserSubscriptionResponse : Resource, ITwitcherSharp<TwitchCheckUserSubscriptionResponse>
{
    private GodotObject _data;
	public TwitchUserSubscription[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckUserSubscriptionResponse object.
    /// </summary> 
    public static TwitchCheckUserSubscriptionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCheckUserSubscriptionResponse
		{
			Data = dataArray.Select(TwitchUserSubscription.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_user_subscription.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
	
	/// <summary> 
	///  
	/// </summary>
	public partial class TwitchUserSubscription : Resource, ITwitcherSharp<TwitchUserSubscription>
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
	    /// Transforms the godot data into a TwitchUserSubscription object.
	    /// </summary> 
	    public static TwitchUserSubscription FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchUserSubscription
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
			if(GifterId != null) request.Set("gifter_id", GifterId);
			if(GifterLogin != null) request.Set("gifter_login", GifterLogin);
			if(GifterName != null) request.Set("gifter_name", GifterName);
			request.Set("is_gift", IsGift);
			request.Set("tier", Tier);
			return request;
		}
	
	}

}
