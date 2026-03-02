using TwitcherSharp.Api.Generated.Shared;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchGetCharityCampaignDonationsResponse : Resource, ITwitcherSharp<TwitchGetCharityCampaignDonationsResponse>
{
    private GodotObject _data;
    public TwitchCharityCampaignDonation[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignDonationsResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignDonationsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetCharityCampaignDonationsResponse
        {
            Data = dataArray.Select(TwitchCharityCampaignDonation.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign_donations.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public partial class TwitchCharityCampaignDonation : Resource, ITwitcherSharp<TwitchCharityCampaignDonation>
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
            request.Set("amount", Amount);
            return request;
        }
        
        /// <summary> 
        /// An object that contains the amount of money that the user donated. 
        /// </summary>
        public partial class TwitchAmount : Resource, ITwitcherSharp<TwitchAmount>
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

}
