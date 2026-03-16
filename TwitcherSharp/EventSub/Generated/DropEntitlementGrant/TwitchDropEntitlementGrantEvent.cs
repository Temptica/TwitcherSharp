using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.DropEntitlementGrant;

public partial class TwitchDropEntitlementGrantEvent : RefCounted, ITwitcherSharpEventSub<TwitchDropEntitlementGrantEvent>
{
    /// <summary> 
    /// Individual event ID, as assigned by EventSub. Use this for de-duplicating messages.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// Entitlement object.
    /// </summary>
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropEntitlementGrantEvent object.
    /// </summary> 
    public static TwitchDropEntitlementGrantEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchDropEntitlementGrantEvent
        {
            Id = data.Get("id").AsString(),
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("data", Data);
        return request;
    }

    public partial class TwitchData : RefCounted, ITwitcherSharpEventSub<TwitchData>
    {
        /// <summary> 
        /// The ID of the organization that owns the game that has Drops enabled.
        /// </summary>
        public string OrganizationId { get; set; }
    
        /// <summary> 
        /// Twitch category ID of the game that was being played when this benefit was entitled.
        /// </summary>
        public string CategoryId { get; set; }
    
        /// <summary> 
        /// The category name.
        /// </summary>
        public string CategoryName { get; set; }
    
        /// <summary> 
        /// The campaign this entitlement is associated with.
        /// </summary>
        public string CampaignId { get; set; }
    
        /// <summary> 
        /// Twitch user ID of the user who was granted the entitlement.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The user display name of the user who was granted the entitlement.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The user login of the user who was granted the entitlement.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// Unique identifier of the entitlement. Use this to de-duplicate entitlements.
        /// </summary>
        public string EntitlementId { get; set; }
    
        /// <summary> 
        /// Identifier of the Benefit.
        /// </summary>
        public string BenefitId { get; set; }
    
        /// <summary> 
        /// UTC timestamp in ISO format when this entitlement was granted on Twitch.
        /// </summary>
        public string CreatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                OrganizationId = data.Get("organization_id").AsString(),
                CategoryId = data.Get("category_id").AsString(),
                CategoryName = data.Get("category_name").AsString(),
                CampaignId = data.Get("campaign_id").AsString(),
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                EntitlementId = data.Get("entitlement_id").AsString(),
                BenefitId = data.Get("benefit_id").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd");
            var dataClass = script.Get("Data").AsGodotObject();
            var request = dataClass.Call("new").AsGodotObject();
            request.Set("organization_id", OrganizationId);
            request.Set("category_id", CategoryId);
            request.Set("category_name", CategoryName);
            request.Set("campaign_id", CampaignId);
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("user_login", UserLogin);
            request.Set("entitlement_id", EntitlementId);
            request.Set("benefit_id", BenefitId);
            request.Set("created_at", CreatedAt);
            return request;
        }
    }
}
