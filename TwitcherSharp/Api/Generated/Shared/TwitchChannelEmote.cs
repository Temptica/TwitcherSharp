using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchChannelEmote : Resource, ITwitcherSharp<TwitchChannelEmote>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Name { get; set; }
	public TwitchImages Images { get; set; }
	public string Tier { get; set; }
	public string EmoteType { get; set; }
	public string EmoteSetId { get; set; }
	public string[] Format { get; set; }
	public string[] Scale { get; set; }
	public string[] ThemeMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelEmote object.
    /// </summary> 
    public static TwitchChannelEmote FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelEmote
		{
			Id = data.Get("id").AsString(),
			Name = data.Get("name").AsString(),
			Images = data.Get("images").As<TwitchImages>(),
			Tier = data.Get("tier").AsString(),
			EmoteType = data.Get("emote_type").AsString(),
			EmoteSetId = data.Get("emote_set_id").AsString(),
			Format = data.Get("format").AsStringArray(),
			Scale = data.Get("scale").AsStringArray(),
			ThemeMode = data.Get("theme_mode").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_emote.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("images", Images);
		request.Set("tier", Tier);
		request.Set("emote_type", EmoteType);
		request.Set("emote_set_id", EmoteSetId);
		request.Set("format", Format);
		request.Set("scale", Scale);
		request.Set("theme_mode", ThemeMode);
		return request;
	}
}
