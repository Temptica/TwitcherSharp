using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.CCLs;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetContentClassificationLabels 
/// </summary>
public partial class GetContentClassificationLabelsOpt : Resource, ITwitcherSharp<GetContentClassificationLabelsOpt>
{
    private GodotObject _data;
	public string Locale { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetContentClassificationLabelsOpt object.
    /// </summary> 
    public static GetContentClassificationLabelsOpt FromObject(GodotObject data)
    {
        return new GetContentClassificationLabelsOpt
        {

			Locale = data.Get("locale").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_content_classification_labels_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("locale", Locale);
		return request;
	}
}
