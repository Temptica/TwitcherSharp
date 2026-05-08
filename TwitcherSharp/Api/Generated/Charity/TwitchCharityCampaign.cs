using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

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
    public TwitchResponseCurrentAmount CurrentAmount { get => field ??= _data?.Get<TwitchResponseCurrentAmount>("current_amount"); set; }
    public TwitchResponseTargetAmount TargetAmount { get => field ??= _data?.Get<TwitchResponseTargetAmount>("target_amount"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaign object.
    /// </summary> 
    public static TwitchCharityCampaign FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaign
        {
            Id = data.Get("id").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            CharityName = data.Get("charity_name").AsString(),
            CharityDescription = data.Get("charity_description").AsString(),
            CharityLogo = data.Get("charity_logo").AsString(),
            CharityWebsite = data.Get("charity_website").AsString(),
        };
        
        instance._data = data;
        return instance;
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
        request.Set("current_amount", CurrentAmount?.ToGodotObject());
        request.Set("target_amount", TargetAmount?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The current amount of donations that the campaign has received. 
    /// </summary>
    public partial class TwitchResponseCurrentAmount : RefCounted, ITwitcherSharp<TwitchResponseCurrentAmount>
    {
        private GodotObject _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseCurrentAmount object.
        /// </summary> 
        public static TwitchResponseCurrentAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseCurrentAmount
            {
                Value = data.Get("value").AsInt32(),
                DecimalPlaces = data.Get("decimal_places").AsInt32(),
                Currency = data.Get("currency").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign.gd");
            var twitchResponseCurrentAmountClass = script.Get("CurrentAmount").AsGodotObject();
            var request = twitchResponseCurrentAmountClass.Call("new").AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            request.Set("currency", Currency);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The campaign’s fundraising goal. This field is **null** if the broadcaster has not defined a fundraising goal. 
    /// </summary>
    public partial class TwitchResponseTargetAmount : RefCounted, ITwitcherSharp<TwitchResponseTargetAmount>
    {
        private GodotObject _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseTargetAmount object.
        /// </summary> 
        public static TwitchResponseTargetAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseTargetAmount
            {
                Value = data.Get("value").AsInt32(),
                DecimalPlaces = data.Get("decimal_places").AsInt32(),
                Currency = data.Get("currency").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_charity_campaign.gd");
            var twitchResponseTargetAmountClass = script.Get("TargetAmount").AsGodotObject();
            var request = twitchResponseTargetAmountClass.Call("new").AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            request.Set("currency", Currency);
            return request;
        }
    
    }

}
