using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchCharityCampaignDonation : RefCounted, ITwitcherSharp<TwitchCharityCampaignDonation>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string CampaignId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public TwitchResponseAmount Amount { get => field ??= _data.Get<TwitchResponseAmount>("amount")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaignDonation object.
    /// </summary> 
    public static TwitchCharityCampaignDonation? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCharityCampaignDonation
        {
            Id = data.ReadAsString("id"),
            CampaignId = data.ReadAsString("campaign_id"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_charity_campaign_donation.gd");
        if(Id != null) request.SetValue("id", Id);
        if(CampaignId != null) request.SetValue("campaign_id", CampaignId);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Amount != null) request.SetObject("amount", Amount);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// An object that contains the amount of money that the user donated. 
    /// </summary>
    public partial class TwitchResponseAmount : RefCounted, ITwitcherSharp<TwitchResponseAmount>
    {
        private Variant _data;
        public int Value { get; set; }
        public int DecimalPlaces { get; set; }
        public string Currency { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseAmount object.
        /// </summary> 
        public static TwitchResponseAmount? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseAmount
            {
                Value = data.ReadAsInt32("value"),
                DecimalPlaces = data.ReadAsInt32("decimal_places"),
                Currency = data.ReadAsString("currency"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_charity_campaign_donation.gd", "Amount");
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
