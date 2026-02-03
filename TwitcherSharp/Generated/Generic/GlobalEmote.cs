using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GlobalEmote : Resource, ITwitcherSharp<GlobalEmote>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Name { get; set; }
	public Images Images { get; set; }
	public string[] Format { get; set; }
	public string[] Scale { get; set; }
	public string[] ThemeMode { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GlobalEmote object.
    /// </summary> 
    public static GlobalEmote FromObject(GodotObject data)
    {
        return new GlobalEmote
        {

			Id = data.Get("id").AsString(),
			Name = data.Get("name").AsString(),
			Images = data.Get("images").As<Images>(),
			Format = data.Get("format").AsStringArray(),
			Scale = data.Get("scale").AsStringArray(),
			ThemeMode = data.Get("theme_mode").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_global_emote.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("images", Images);
		request.Set("format", Format);
		request.Set("scale", Scale);
		request.Set("theme_mode", ThemeMode);
		return request;
	}
}
