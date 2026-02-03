using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ContentClassificationLabel : Resource, ITwitcherSharp<ContentClassificationLabel>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Description { get; set; }
	public string Name { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ContentClassificationLabel object.
    /// </summary> 
    public static ContentClassificationLabel FromObject(GodotObject data)
    {
        return new ContentClassificationLabel
        {

			Id = data.Get("id").AsString(),
			Description = data.Get("description").AsString(),
			Name = data.Get("name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_content_classification_label.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("description", Description);
		request.Set("name", Name);
		return request;
	}
}
