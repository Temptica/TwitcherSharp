using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBlockedTerm : RefCounted, ITwitcherSharp<TwitchBlockedTerm>
{
    private GodotObject? _data;
    public string BroadcasterId { get; set; } = null!;
    public string ModeratorId { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string UpdatedAt { get; set; } = null!;
    public string ExpiresAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchBlockedTerm object.
    /// </summary> 
    public static TwitchBlockedTerm? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBlockedTerm
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            ModeratorId = data.Get("moderator_id").AsString(),
            Id = data.Get("id").AsString(),
            Text = data.Get("text").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            UpdatedAt = data.Get("updated_at").AsString(),
            ExpiresAt = data.Get("expires_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_blocked_term.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
        if(Id != null) request.Set("id", Id);
        if(Text != null) request.Set("text", Text);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        if(UpdatedAt != null) request.Set("updated_at", UpdatedAt);
        if(ExpiresAt != null) request.Set("expires_at", ExpiresAt);
        return request;
    }

}
