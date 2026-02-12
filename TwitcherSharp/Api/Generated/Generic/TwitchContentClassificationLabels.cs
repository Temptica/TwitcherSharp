using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// List of labels that should be set as the Channel’s CCLs. 
/// </summary>
public partial class TwitchContentClassificationLabels : Resource, ITwitcherSharp<TwitchContentClassificationLabels>
{
    private GodotObject _data;
	public string Id { get; set; }
	public bool IsEnabled { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchContentClassificationLabels object.
    /// </summary> 
    public static TwitchContentClassificationLabels FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchContentClassificationLabels
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
