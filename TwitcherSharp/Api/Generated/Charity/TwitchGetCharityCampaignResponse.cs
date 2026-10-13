using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchGetCharityCampaignResponse : RefCounted, ITwitcherSharp<TwitchGetCharityCampaignResponse>
{
    private Variant _data;
    public TwitchCharityCampaign[] Data { get => field ??= _data.GetArray<TwitchCharityCampaign>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCharityCampaignResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_charity_campaign.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
