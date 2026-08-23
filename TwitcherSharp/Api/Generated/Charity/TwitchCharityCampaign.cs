using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchCharityCampaign : RefCounted, ITwitcherSharp<TwitchCharityCampaign>
{
    private GodotObject? _data;
    public string Id { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string CharityName { get; set; } = null!;
    public string CharityDescription { get; set; } = null!;
    public string CharityLogo { get; set; } = null!;
    public string CharityWebsite { get; set; } = null!;
    public TwitchResponseCurrentAmount CurrentAmount { get => field ??= _data?.Get<TwitchResponseCurrentAmount>("current_amount")!; set; } = null!;
    public TwitchResponseTargetAmount TargetAmount { get => field ??= _data?.Get<TwitchResponseTargetAmount>("target_amount")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCharityCampaign object.
    /// </summary> 
    public static TwitchCharityCampaign? FromObject(GodotObject? data)
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
        if(Id != null) request.Set("id", Id);
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(CharityName != null) request.Set("charity_name", CharityName);
        if(CharityDescription != null) request.Set("charity_description", CharityDescription);
        if(CharityLogo != null) request.Set("charity_logo", CharityLogo);
        if(CharityWebsite != null) request.Set("charity_website", CharityWebsite);
        if(CurrentAmount != null) request.Set("current_amount", CurrentAmount.ToGodotObject());
        if(TargetAmount != null) request.Set("target_amount", TargetAmount.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// The current amount of donations that the campaign has received. 
    /// </summary>
    public partial class TwitchResponseCurrentAmount : RefCounted, ITwitcherSharp<TwitchResponseCurrentAmount>
    {
        private GodotObject? _data;
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
            if(Currency != null) request.Set("currency", Currency);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The campaign’s fundraising goal. This field is **null** if the broadcaster has not defined a fundraising goal. 
    /// </summary>
    public partial class TwitchResponseTargetAmount : RefCounted, ITwitcherSharp<TwitchResponseTargetAmount>
    {
        private GodotObject? _data;
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
            if(Currency != null) request.Set("currency", Currency);
            return request;
        }
    
    }

}
