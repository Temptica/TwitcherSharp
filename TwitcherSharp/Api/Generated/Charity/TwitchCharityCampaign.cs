using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchCharityCampaign : RefCounted, ITwitcherSharp<TwitchCharityCampaign>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string CharityName { get; set; } = null!;
    public string CharityDescription { get; set; } = null!;
    public string CharityLogo { get; set; } = null!;
    public string CharityWebsite { get; set; } = null!;
    public TwitchResponseCurrentAmount CurrentAmount { get => field ??= _data.Get<TwitchResponseCurrentAmount>("current_amount")!; set; } = null!;
    public TwitchResponseTargetAmount TargetAmount { get => field ??= _data.Get<TwitchResponseTargetAmount>("target_amount")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaign object.
    /// </summary> 
    public static TwitchCharityCampaign? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaign
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
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_charity_campaign.gd");
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
    
    /// <summary> 
    /// The current amount of donations that the campaign has received. 
    /// </summary>
    public partial class TwitchResponseCurrentAmount : RefCounted, ITwitcherSharp<TwitchResponseCurrentAmount>
    {
        private Variant _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseCurrentAmount object.
        /// </summary> 
        public static TwitchResponseCurrentAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseCurrentAmount
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_charity_campaign.gd", "CurrentAmount");
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
    
    /// <summary> 
    /// The campaign’s fundraising goal. This field is **null** if the broadcaster has not defined a fundraising goal. 
    /// </summary>
    public partial class TwitchResponseTargetAmount : RefCounted, ITwitcherSharp<TwitchResponseTargetAmount>
    {
        private Variant _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseTargetAmount object.
        /// </summary> 
        public static TwitchResponseTargetAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseTargetAmount
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_charity_campaign.gd", "TargetAmount");
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
