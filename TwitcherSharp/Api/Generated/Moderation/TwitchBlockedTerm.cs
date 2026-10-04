using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBlockedTerm : RefCounted, ITwitcherSharp<TwitchBlockedTerm>
{
    private Variant _data;
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
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            ModeratorId = data.Read("moderator_id", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            Text = data.Read("text", static v => v.AsString()),
            CreatedAt = data.Read("created_at", static v => v.AsString()),
            UpdatedAt = data.Read("updated_at", static v => v.AsString()),
            ExpiresAt = data.Read("expires_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_blocked_term.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
        if(Id != null) request.SetValue("id", Id);
        if(Text != null) request.SetValue("text", Text);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(UpdatedAt != null) request.SetValue("updated_at", UpdatedAt);
        if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
