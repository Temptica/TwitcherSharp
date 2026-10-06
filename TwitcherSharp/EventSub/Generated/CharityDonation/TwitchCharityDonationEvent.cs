using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityDonation;

public partial class TwitchCharityDonationEvent : RefCounted, ITwitcherSharpEventSub<TwitchCharityDonationEvent>
{
    private Variant _data;
    
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
    public TwitchAmount? Amount { get => field ??= _data.Get<TwitchAmount>("amount"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityDonationEvent object.
    /// </summary> 
    public static TwitchCharityDonationEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityDonationEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            CampaignId = data.Read("campaign_id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            CharityName = data.Read("charity_name", static v => v.AsString()),
            CharityDescription = data.Read("charity_description", static v => v.AsString()),
            CharityLogo = data.Read("charity_logo", static v => v.AsString()),
            CharityWebsite = data.Read("charity_website", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_donation.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(CampaignId != null) request.SetValue("campaign_id", CampaignId);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(CharityName != null) request.SetValue("charity_name", CharityName);
        if(CharityDescription != null) request.SetValue("charity_description", CharityDescription);
        if(CharityLogo != null) request.SetValue("charity_logo", CharityLogo);
        if(CharityWebsite != null) request.SetValue("charity_website", CharityWebsite);
        if(Amount != null) request.SetObject("amount", Amount);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchAmount : RefCounted, ITwitcherSharpEventSub<TwitchAmount>
    {
        private Variant _data;
        
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
                Value = data.Read("value", static v => v.AsInt32()),
                DecimalPlaces = data.Read("decimal_places", static v => v.AsInt32()),
                Currency = data.Read("currency", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_donation.gd", "Amount");
            request.SetValue("value", Value);
            request.SetValue("decimal_places", DecimalPlaces);
            if(Currency != null) request.SetValue("currency", Currency);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }
}
