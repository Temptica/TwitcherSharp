using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// List of labels that should be set as the Channel’s CCLs. 
/// </summary>
public partial class ContentClassificationLabels : Resource, ITwitcherSharp<ContentClassificationLabels>
{
    private GodotObject _data;
	public string Id { get; set; }
	public bool IsEnabled { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ContentClassificationLabels object.
    /// </summary> 
    public static ContentClassificationLabels FromObject(GodotObject data)
    {
        return new ContentClassificationLabels
        {

			Id = data.Get("id").AsString(),
			IsEnabled = data.Get("is_enabled").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_content_classification_labels.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("is_enabled", IsEnabled);
		return request;
	}
}
