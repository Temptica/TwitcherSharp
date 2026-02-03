using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.CCLs;
 
/// <summary> 
///  
/// </summary>
public partial class GetContentClassificationLabelsResponse : Resource, ITwitcherSharp<GetContentClassificationLabelsResponse>
{
    private GodotObject _data;
	public ContentClassificationLabel[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetContentClassificationLabelsResponse object.
    /// </summary> 
    public static GetContentClassificationLabelsResponse FromObject(GodotObject data)
    {
        return new GetContentClassificationLabelsResponse
        {

			Data = data.Get("data").As<ContentClassificationLabel[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_content_classification_labels_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
