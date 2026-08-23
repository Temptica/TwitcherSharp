using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityDonation;

public partial class TwitchCharityDonationEvent : RefCounted, ITwitcherSharpEventSub<TwitchCharityDonationEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// An ID that identifies the donation. The ID is unique across campaigns.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// An ID that identifies the charity campaign.
    /// </summary>
    public string? CampaignId { get; set; }

    /// <summary> 
    /// An ID that identifies the broadcaster that’s running the campaign.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// An ID that identifies the user that donated to the campaign.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The charity’s name.
    /// </summary>
    public string? CharityName { get; set; }

    /// <summary> 
    /// A description of the charity.
    /// </summary>
    public string? CharityDescription { get; set; }

    /// <summary> 
    /// A URL to an image of the charity’s logo. The image’s type is PNG and its size is 100px X 100px.
    /// </summary>
    public string? CharityLogo { get; set; }

    /// <summary> 
    /// A URL to the charity’s website.
    /// </summary>
    public string? CharityWebsite { get; set; }

    /// <summary> 
    /// An object that contains the amount of money that the user donated.
    /// </summary>
    public TwitchAmount? Amount { get => field ??= _data?.Get<TwitchAmount>("amount"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityDonationEvent object.
    /// </summary> 
    public static TwitchCharityDonationEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityDonationEvent
        {
            Id = data.Get("id").AsString(),
            CampaignId = data.Get("campaign_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_donation.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(CampaignId != null) request.Set("campaign_id", CampaignId);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(CharityName != null) request.Set("charity_name", CharityName);
        if(CharityDescription != null) request.Set("charity_description", CharityDescription);
        if(CharityLogo != null) request.Set("charity_logo", CharityLogo);
        if(CharityWebsite != null) request.Set("charity_website", CharityWebsite);
        if(Amount != null) request.Set("amount", Amount.ToGodotObject());
        return request;
    }


    public partial class TwitchAmount : RefCounted, ITwitcherSharpEventSub<TwitchAmount>
    {
        private GodotObject? _data;
        
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
        public string? Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAmount object.
        /// </summary> 
        public static TwitchAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAmount
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_charity_donation.gd");
            var amountClass = script.Get("Amount").As<GDScript>();
            var request = amountClass.New().AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_places", DecimalPlaces);
            if(Currency != null) request.Set("currency", Currency);
            return request;
        }
    }
}
