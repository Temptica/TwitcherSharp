using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class ModifyChannelInformationBody : Resource, ITwitcherSharp<ModifyChannelInformationBody>
{
    private GodotObject _data;
	public string GameId { get; set; }
	public string BroadcasterLanguage { get; set; }
	public string Title { get; set; }
	public int Delay { get; set; }
	public string[] Tags { get; set; }
	public ContentClassificationLabels[] ContentClassificationLabels { get; set; }
	public bool IsBrandedContent { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ModifyChannelInformationBody object.
    /// </summary> 
    public static ModifyChannelInformationBody FromObject(GodotObject data)
    {
        return new ModifyChannelInformationBody
        {

			GameId = data.Get("game_id").AsString(),
			BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
			Title = data.Get("title").AsString(),
			Delay = data.Get("delay").AsInt32(),
			Tags = data.Get("tags").AsStringArray(),
			ContentClassificationLabels = data.Get("content_classification_labels").As<ContentClassificationLabels[]>(),
			IsBrandedContent = data.Get("is_branded_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_modify_channel_information_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("game_id", GameId);
		request.Set("broadcaster_language", BroadcasterLanguage);
		request.Set("title", Title);
		request.Set("delay", Delay);
		request.Set("tags", Tags);
		request.Set("content_classification_labels", ContentClassificationLabels);
		request.Set("is_branded_content", IsBrandedContent);
		return request;
	}
}
