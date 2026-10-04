using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.CharityCampaignProgress;

public partial class TwitchCharityCampaignProgressEvent : RefCounted, ITwitcherSharpEventSub<TwitchCharityCampaignProgressEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// An ID that identifies the charity campaign.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// An ID that identifies the broadcaster that’s running the campaign.
    /// </summary>
    public string? BroadcasterId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string? BroadcasterLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? BroadcasterName { get; set; }

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
    /// An object that contains the current amount of donations that the campaign has received.
    /// </summary>
    public TwitchCurrentAmount? CurrentAmount { get => field ??= _data.Get<TwitchCurrentAmount>("current_amount"); set; }

    /// <summary> 
    /// An object that contains the campaign’s target fundraising goal.
    /// </summary>
    public TwitchTargetAmount? TargetAmount { get => field ??= _data.Get<TwitchTargetAmount>("target_amount"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignProgressEvent object.
    /// </summary> 
    public static TwitchCharityCampaignProgressEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignProgressEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(CharityName != null) request.SetValue("charity_name", CharityName);
        if(CharityDescription != null) request.SetValue("charity_description", CharityDescription);
        if(CharityLogo != null) request.SetValue("charity_logo", CharityLogo);
        if(CharityWebsite != null) request.SetValue("charity_website", CharityWebsite);
        if(CurrentAmount != null) request.SetObject("current_amount", CurrentAmount);
        if(TargetAmount != null) request.SetObject("target_amount", TargetAmount);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchCurrentAmount : RefCounted, ITwitcherSharpEventSub<TwitchCurrentAmount>
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
        /// Transforms the godot data into a TwitchCurrentAmount object.
        /// </summary> 
        public static TwitchCurrentAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCurrentAmount
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd", "CurrentAmount");
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

    public partial class TwitchTargetAmount : RefCounted, ITwitcherSharpEventSub<TwitchTargetAmount>
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
        /// Transforms the godot data into a TwitchTargetAmount object.
        /// </summary> 
        public static TwitchTargetAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTargetAmount
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_charity_campaign_progress.gd", "TargetAmount");
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
