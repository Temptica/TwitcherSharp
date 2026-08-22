using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Charity;

public partial class TwitchGetCharityCampaignResponse : RefCounted, ITwitcherSharp<TwitchGetCharityCampaignResponse>
{
    private GodotObject? _data;
    public TwitchCharityCampaign[] Data { get => field ??= _data?.GetArray<TwitchCharityCampaign>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCharityCampaignResponse object.
    /// </summary> 
    public static TwitchGetCharityCampaignResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCharityCampaignResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_charity_campaign.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
