using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Emote : Resource, ITwitcherSharp<Emote>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Name { get; set; }
	public Images Images { get; set; }
	public string EmoteType { get; set; }
	public string EmoteSetId { get; set; }
	public string OwnerId { get; set; }
	public string[] Format { get; set; }
	public string[] Scale { get; set; }
	public string[] ThemeMode { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Emote object.
    /// </summary> 
    public static Emote FromObject(GodotObject data)
    {
        return new Emote
        {

			Id = data.Get("id").AsString(),
			Name = data.Get("name").AsString(),
			Images = data.Get("images").As<Images>(),
			EmoteType = data.Get("emote_type").AsString(),
			EmoteSetId = data.Get("emote_set_id").AsString(),
			OwnerId = data.Get("owner_id").AsString(),
			Format = data.Get("format").AsStringArray(),
			Scale = data.Get("scale").AsStringArray(),
			ThemeMode = data.Get("theme_mode").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_emote.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("images", Images);
		request.Set("emote_type", EmoteType);
		request.Set("emote_set_id", EmoteSetId);
		request.Set("owner_id", OwnerId);
		request.Set("format", Format);
		request.Set("scale", Scale);
		request.Set("theme_mode", ThemeMode);
		return request;
	}
}
