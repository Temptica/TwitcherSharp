using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The list of secrets. 
/// </summary>
public partial class TwitchSecrets : Resource, ITwitcherSharp<TwitchSecrets>
{
    private GodotObject _data;
	public string Content { get; set; }
	public string ActiveAt { get; set; }
	public string ExpiresAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSecrets object.
    /// </summary> 
    public static TwitchSecrets FromObject(GodotObject data)
    {
		return new TwitchSecrets
		{
			Content = data.Get("content").AsString(),
			ActiveAt = data.Get("active_at").AsString(),
			ExpiresAt = data.Get("expires_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_secrets.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("content", Content);
		request.Set("active_at", ActiveAt);
		request.Set("expires_at", ExpiresAt);
		return request;
	}
}
