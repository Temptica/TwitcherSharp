using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchGetCharityCampaignResponse : RefCounted, ITwitcherSharp<TwitchGetCharityCampaignResponse>
{
    private GodotObject _data;
    public TwitchCharityCampaign[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetCharityCampaignResponse
        {
            Data = dataArray.Select(TwitchCharityCampaign.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    public partial class TwitchCharityCampaign : RefCounted, ITwitcherSharp<TwitchCharityCampaign>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public string CharityLogo { get; set; }
        public string CharityWebsite { get; set; }
        public TwitchCurrentAmount CurrentAmount { get; set; }
        public TwitchTargetAmount TargetAmount { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCharityCampaign object.
        /// </summary> 
        public static TwitchCharityCampaign FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchCharityCampaign
            {
                Id = data.Get("id").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                CharityName = data.Get("charity_name").AsString(),
                CharityDescription = data.Get("charity_description").AsString(),
                CharityLogo = data.Get("charity_logo").AsString(),
                CharityWebsite = data.Get("charity_website").AsString(),
                CurrentAmount = data.Get("current_amount").As<TwitchCurrentAmount>(),
                TargetAmount = data.Get("target_amount").As<TwitchTargetAmount>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("charity_name", CharityName);
            request.Set("charity_description", CharityDescription);
            request.Set("charity_logo", CharityLogo);
            request.Set("charity_website", CharityWebsite);
            request.Set("current_amount", CurrentAmount);
            request.Set("target_amount", TargetAmount);
            return request;
        }
        
        /// <summary> 
        /// The current amount of donations that the campaign has received. 
        /// </summary>
        public partial class TwitchCurrentAmount : RefCounted, ITwitcherSharp<TwitchCurrentAmount>
        {
            private GodotObject _data;
            public int Value { get; set; }
            public int DecimalPlaces { get; set; }
            public string Currency { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchCurrentAmount object.
            /// </summary> 
            public static TwitchCurrentAmount FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchCurrentAmount
                {
                    Value = data.Get("value").AsInt32(),
                    DecimalPlaces = data.Get("decimal_places").AsInt32(),
                    Currency = data.Get("currency").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_current_amount.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("value", Value);
                request.Set("decimal_places", DecimalPlaces);
                request.Set("currency", Currency);
                return request;
            }
        
        }
        
        /// <summary> 
        /// The campaign’s fundraising goal. This field is **null** if the broadcaster has not defined a fundraising goal. 
        /// </summary>
        public partial class TwitchTargetAmount : RefCounted, ITwitcherSharp<TwitchTargetAmount>
        {
            private GodotObject _data;
            public int Value { get; set; }
            public int DecimalPlaces { get; set; }
            public string Currency { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchTargetAmount object.
            /// </summary> 
            public static TwitchTargetAmount FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchTargetAmount
                {
                    Value = data.Get("value").AsInt32(),
                    DecimalPlaces = data.Get("decimal_places").AsInt32(),
                    Currency = data.Get("currency").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_target_amount.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("value", Value);
                request.Set("decimal_places", DecimalPlaces);
                request.Set("currency", Currency);
                return request;
            }
        
        }
    
    }

}
