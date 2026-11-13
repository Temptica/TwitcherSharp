using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.DropEntitlementGrant;

public partial class TwitchDropEntitlementGrantEvent : RefCounted, ITwitcherSharpEventSub<TwitchDropEntitlementGrantEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// Individual event ID, as assigned by EventSub. Use this for de-duplicating messages.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// Entitlement object.
    /// </summary>
    public TwitchData[]? Data { get => field ??= _data.GetArray<TwitchData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropEntitlementGrantEvent object.
    /// </summary> 
    public static TwitchDropEntitlementGrantEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDropEntitlementGrantEvent
        {
            Id = data.ReadAsString("id"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchData : RefCounted, ITwitcherSharpEventSub<TwitchData>
    {
        private Variant _data;
        
        /// <summary> 
        /// The ID of the organization that owns the game that has Drops enabled.
        /// </summary>
        public string? OrganizationId { get; set; }
    
        /// <summary> 
        /// Twitch category ID of the game that was being played when this benefit was entitled.
        /// </summary>
        public string? CategoryId { get; set; }
    
        /// <summary> 
        /// The category name.
        /// </summary>
        public string? CategoryName { get; set; }
    
        /// <summary> 
        /// The campaign this entitlement is associated with.
        /// </summary>
        public string? CampaignId { get; set; }
    
        /// <summary> 
        /// Twitch user ID of the user who was granted the entitlement.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The user display name of the user who was granted the entitlement.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The user login of the user who was granted the entitlement.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// Unique identifier of the entitlement. Use this to de-duplicate entitlements.
        /// </summary>
        public string? EntitlementId { get; set; }
    
        /// <summary> 
        /// Identifier of the Benefit.
        /// </summary>
        public string? BenefitId { get; set; }
    
        /// <summary> 
        /// UTC timestamp in ISO format when this entitlement was granted on Twitch.
        /// </summary>
        public string? CreatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchData
            {
                OrganizationId = data.ReadAsString("organization_id"),
                CategoryId = data.ReadAsString("category_id"),
                CategoryName = data.ReadAsString("category_name"),
                CampaignId = data.ReadAsString("campaign_id"),
                UserId = data.ReadAsString("user_id"),
                UserName = data.ReadAsString("user_name"),
                UserLogin = data.ReadAsString("user_login"),
                EntitlementId = data.ReadAsString("entitlement_id"),
                BenefitId = data.ReadAsString("benefit_id"),
                CreatedAt = data.ReadAsString("created_at"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd", "Data");
            if(OrganizationId != null) request.SetValue("organization_id", OrganizationId);
            if(CategoryId != null) request.SetValue("category_id", CategoryId);
            if(CategoryName != null) request.SetValue("category_name", CategoryName);
            if(CampaignId != null) request.SetValue("campaign_id", CampaignId);
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(EntitlementId != null) request.SetValue("entitlement_id", EntitlementId);
            if(BenefitId != null) request.SetValue("benefit_id", BenefitId);
            if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
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
