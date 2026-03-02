using TwitcherSharp.Api.Generated.Shared;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchGetBroadcasterSubscriptionsResponse : Resource, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsResponse>
{
    private GodotObject _data;
    public TwitchBroadcasterSubscription[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }
    public int Points { get; set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBroadcasterSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetBroadcasterSubscriptionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetBroadcasterSubscriptionsResponse
        {
            Data = dataArray.Select(TwitchBroadcasterSubscription.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
            Points = data.Get("points").AsInt32(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("points", Points);
        request.Set("total", Total);
        return request;
    }
    public partial class TwitchBroadcasterSubscription : Resource, ITwitcherSharp<TwitchBroadcasterSubscription>
    {
        private GodotObject _data;
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string GifterId { get; set; }
        public string GifterLogin { get; set; }
        public string GifterName { get; set; }
        public bool IsGift { get; set; }
        public string PlanName { get; set; }
        public string Tier { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBroadcasterSubscription object.
        /// </summary> 
        public static TwitchBroadcasterSubscription FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchBroadcasterSubscription
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                GifterId = data.Get("gifter_id").AsString(),
                GifterLogin = data.Get("gifter_login").AsString(),
                GifterName = data.Get("gifter_name").AsString(),
                IsGift = data.Get("is_gift").AsBool(),
                PlanName = data.Get("plan_name").AsString(),
                Tier = data.Get("tier").AsString(),
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_broadcaster_subscription.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("gifter_id", GifterId);
            request.Set("gifter_login", GifterLogin);
            request.Set("gifter_name", GifterName);
            request.Set("is_gift", IsGift);
            request.Set("plan_name", PlanName);
            request.Set("tier", Tier);
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("user_login", UserLogin);
            return request;
        }
    
    }

}
