using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.DropEntitlementGrant;

public partial class TwitchDropEntitlementGrantCondition(string organizationId) : RefCounted, ITwitcherSharpCondition<TwitchDropEntitlementGrantCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchDropEntitlementGrantCondition);

    /// <summary> 
    /// The organization ID of the organization that owns the game on the developer portal.
    /// </summary>
    public string OrganizationId { get; set; } = organizationId;

    /// <summary> 
    /// The category (or game) ID of the game for which entitlement notifications will be received.
    /// </summary>
    public string? CategoryId { get; set; }

    /// <summary> 
    /// The campaign ID for a specific campaign for which entitlement notifications will be received.
    /// </summary>
    public string? CampaignId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropEntitlementGrantCondition object.
    /// </summary> 
    public static TwitchDropEntitlementGrantCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchDropEntitlementGrantCondition(data.Read("organization_id", static v => v.AsString()))
        {
            CategoryId = data.Read("category_id", static v => v.AsString()),
            CampaignId = data.Read("campaign_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd", "Condition");
        request.SetValue("organization_id", OrganizationId);
        if(CategoryId != null) request.SetValue("category_id", CategoryId);
        if(CampaignId != null) request.SetValue("campaign_id", CampaignId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchDropEntitlementGrantCondition FromDictionary(Dictionary data)
    {
        return new TwitchDropEntitlementGrantCondition(data["organization_id"].AsString())
        {
            CategoryId = data["category_id"].AsString(),
            CampaignId = data["campaign_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"organization_id", OrganizationId},
            {"category_id", CategoryId!},
            {"campaign_id", CampaignId!},
        };
    }
}
