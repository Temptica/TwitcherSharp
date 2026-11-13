using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Goals;

public partial class TwitchCreatorGoal : RefCounted, ITwitcherSharp<TwitchCreatorGoal>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CurrentAmount { get; set; }
    public int TargetAmount { get; set; }
    public string CreatedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatorGoal object.
    /// </summary> 
    public static TwitchCreatorGoal? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatorGoal
        {
            Id = data.ReadAsString("id"),
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            BroadcasterName = data.ReadAsString("broadcaster_name"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            Type = data.ReadAsString("type"),
            Description = data.ReadAsString("description"),
            CurrentAmount = data.ReadAsInt32("current_amount"),
            TargetAmount = data.ReadAsInt32("target_amount"),
            CreatedAt = data.ReadAsString("created_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_creator_goal.gd");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(Type != null) request.SetValue("type", Type);
        if(Description != null) request.SetValue("description", Description);
        request.SetValue("current_amount", CurrentAmount);
        request.SetValue("target_amount", TargetAmount);
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
