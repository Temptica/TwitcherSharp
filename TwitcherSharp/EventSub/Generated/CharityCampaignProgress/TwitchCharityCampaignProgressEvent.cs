using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignProgress;

public partial class TwitchCharityCampaignProgressEvent : RefCounted, ITwitcherSharpEventSub<TwitchCharityCampaignProgressEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// An ID that identifies the charity campaign.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// An ID that identifies the broadcaster that’s running the campaign.
    /// </summary>
    public string BroadcasterId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string BroadcasterLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string BroadcasterName { get; set; }

    /// <summary> 
    /// The charity’s name.
    /// </summary>
    public string CharityName { get; set; }

    /// <summary> 
    /// A description of the charity.
    /// </summary>
    public string CharityDescription { get; set; }

    /// <summary> 
    /// A URL to an image of the charity’s logo. The image’s type is PNG and its size is 100px X 100px.
    /// </summary>
    public string CharityLogo { get; set; }

    /// <summary> 
    /// A URL to the charity’s website.
    /// </summary>
    public string CharityWebsite { get; set; }

    /// <summary> 
    /// An object that contains the current amount of donations that the campaign has received.
    /// </summary>
    public TwitchCurrentAmount CurrentAmount { get => field ??= _data?.Get<TwitchCurrentAmount>("current_amount"); set; }

    /// <summary> 
    /// An object that contains the campaign’s target fundraising goal.
    /// </summary>
    public TwitchTargetAmount TargetAmount { get => field ??= _data?.Get<TwitchTargetAmount>("target_amount"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignProgressEvent object.
    /// </summary> 
    public static TwitchCharityCampaignProgressEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignProgressEvent
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
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


    public partial class TwitchCurrentAmount : RefCounted, ITwitcherSharpEventSub<TwitchCurrentAmount>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
        /// </summary>
        public int Value { get; set; }
    
        /// <summary> 
        /// The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate value from minor units to major units by using the formula:value / 10^decimal_places
        /// </summary>
        public int DecimalPlaces { get; set; }
    
        /// <summary> 
        /// The ISO-4217 three-letter currency code that identifies the type of currency in value.
        /// </summary>
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCurrentAmount object.
        /// </summary> 
        public static TwitchCurrentAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchCurrentAmount
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd");
            var currentAmountClass = script.Get("CurrentAmount").As<GDScript>();
            var request = currentAmountClass.New().AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            request.Set("currency", Currency);
            return request;
        }
    }

    public partial class TwitchTargetAmount : RefCounted, ITwitcherSharpEventSub<TwitchTargetAmount>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
        /// </summary>
        public int Value { get; set; }
    
        /// <summary> 
        /// The number of decimal places used by the currency. For example, USD uses two decimal places. Use this number to translate value from minor units to major units by using the formula:value / 10^decimal_places
        /// </summary>
        public int DecimalPlaces { get; set; }
    
        /// <summary> 
        /// The ISO-4217 three-letter currency code that identifies the type of currency in value.
        /// </summary>
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTargetAmount object.
        /// </summary> 
        public static TwitchTargetAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchTargetAmount
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd");
            var targetAmountClass = script.Get("TargetAmount").As<GDScript>();
            var request = targetAmountClass.New().AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            request.Set("currency", Currency);
            return request;
        }
    }
}
