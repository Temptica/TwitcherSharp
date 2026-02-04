using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetContentClassificationLabels 
/// </summary>
public partial class TwitchGetContentClassificationLabelsOpt : Resource, ITwitcherSharp<TwitchGetContentClassificationLabelsOpt>
{
    private GodotObject _data;
	public string Locale { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsOpt object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsOpt FromObject(GodotObject data)
    {
		return new TwitchGetContentClassificationLabelsOpt
		{
			Locale = data.Get("locale").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_content_classification_labels.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("locale", Locale);
		return request;
	}
}
