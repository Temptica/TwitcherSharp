using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.DropEntitlementGrant;

public partial class TwitchDropEntitlementGrantCondition : RefCounted, ITwitcherSharpCondition<TwitchDropEntitlementGrantCondition>
{
    public string Name => nameof(TwitchDropEntitlementGrantCondition);

    /// <summary> 
    /// The organization ID of the organization that owns the game on the developer portal.
    /// </summary>
    public string OrganizationId { get; set; }

    /// <summary> 
    /// The category (or game) ID of the game for which entitlement notifications will be received.
    /// </summary>
    public string CategoryId { get; set; }

    /// <summary> 
    /// The campaign ID for a specific campaign for which entitlement notifications will be received.
    /// </summary>
    public string CampaignId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropEntitlementGrantCondition object.
    /// </summary> 
    public static TwitchDropEntitlementGrantCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchDropEntitlementGrantCondition
        {
            OrganizationId = data.Get("organization_id").AsString(),
            CategoryId = data.Get("category_id").AsString(),
            CampaignId = data.Get("campaign_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_drop_entitlement_grant.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("organization_id", OrganizationId);
        request.Set("category_id", CategoryId);
        request.Set("campaign_id", CampaignId);
        return request;
    }

    public static TwitchDropEntitlementGrantCondition FromDictionary(Dictionary data)
    {
        return new TwitchDropEntitlementGrantCondition
        {
            OrganizationId = data["organization_id"].AsString(),
            CategoryId = data["category_id"].AsString(),
            CampaignId = data["campaign_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"organization_id", OrganizationId},
            {"category_id", CategoryId},
            {"campaign_id", CampaignId},
        };
    }
}
