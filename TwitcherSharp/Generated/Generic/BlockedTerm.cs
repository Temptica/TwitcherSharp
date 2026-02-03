using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class BlockedTerm : Resource, ITwitcherSharp<BlockedTerm>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string ModeratorId { get; set; }
	public string Id { get; set; }
	public string Text { get; set; }
	public string CreatedAt { get; set; }
	public string UpdatedAt { get; set; }
	public string ExpiresAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a BlockedTerm object.
    /// </summary> 
    public static BlockedTerm FromObject(GodotObject data)
    {
        return new BlockedTerm
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			ModeratorId = data.Get("moderator_id").AsString(),
			Id = data.Get("id").AsString(),
			Text = data.Get("text").AsString(),
			CreatedAt = data.Get("created_at").AsString(),
			UpdatedAt = data.Get("updated_at").AsString(),
			ExpiresAt = data.Get("expires_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_blocked_term.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("moderator_id", ModeratorId);
		request.Set("id", Id);
		request.Set("text", Text);
		request.Set("created_at", CreatedAt);
		request.Set("updated_at", UpdatedAt);
		request.Set("expires_at", ExpiresAt);
		return request;
	}
}
