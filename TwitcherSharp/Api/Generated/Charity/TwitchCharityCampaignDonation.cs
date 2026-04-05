using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchCharityCampaignDonation : RefCounted, ITwitcherSharp<TwitchCharityCampaignDonation>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string CampaignId { get; set; }
    public string UserId { get; set; }
    public string UserLogin { get; set; }
    public string UserName { get; set; }
    public TwitchAmount Amount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignDonation object.
    /// </summary> 
    public static TwitchCharityCampaignDonation FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCharityCampaignDonation
        {
            Id = data.Get("id").AsString(),
            CampaignId = data.Get("campaign_id").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Amount = data.Get("amount").As<TwitchAmount>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign_donation.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("campaign_id", CampaignId);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("amount", Amount?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// An object that contains the amount of money that the user donated. 
    /// </summary>
    public partial class TwitchAmount : RefCounted, ITwitcherSharp<TwitchAmount>
    {
        private GodotObject _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAmount object.
        /// </summary> 
        public static TwitchAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchAmount
            {
                Value = data.Get("value").AsInt32(),
                DecimalPlaces = data.Get("decimal_places").AsInt32(),
                Currency = data.Get("currency").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_amount.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            request.Set("currency", Currency);
            return request;
        }
    
    }

}
