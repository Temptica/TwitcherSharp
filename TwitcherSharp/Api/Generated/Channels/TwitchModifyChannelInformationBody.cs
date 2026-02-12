using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchModifyChannelInformationBody : Resource, ITwitcherSharp<TwitchModifyChannelInformationBody>
{
    private GodotObject _data;
	public string GameId { get; set; }
	public string BroadcasterLanguage { get; set; }
	public string Title { get; set; }
	public int? Delay { get; set; }
	public string[] Tags { get; set; }
	public TwitchContentClassificationLabels[] ContentClassificationLabels { get; set; }
	public bool? IsBrandedContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchModifyChannelInformationBody object.
    /// </summary> 
    public static TwitchModifyChannelInformationBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		var contentClassificationLabelsArray = data.Get("content_classification_labels").AsGodotArray<GodotObject>();
		return new TwitchModifyChannelInformationBody
		{
			GameId = data.Get("game_id").AsString(),
			BroadcasterLanguage = data.Get("broadcaster_language").AsString(),
			Title = data.Get("title").AsString(),
			Delay = data.Get("delay").AsInt32(),
			Tags = data.Get("tags").AsStringArray(),
			ContentClassificationLabels = contentClassificationLabelsArray.Select(TwitchContentClassificationLabels.FromObject).ToArray(),
			IsBrandedContent = data.Get("is_branded_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_modify_channel_information.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		if(GameId != null) request.Set("game_id", GameId);
		if(BroadcasterLanguage != null) request.Set("broadcaster_language", BroadcasterLanguage);
		if(Title != null) request.Set("title", Title);
		if(Delay.HasValue) request.Set("delay", Delay.Value);
		if(Tags != null) request.Set("tags", Tags);
		if(ContentClassificationLabels != null) request.Set("content_classification_labels", ContentClassificationLabels);
		if(IsBrandedContent.HasValue) request.Set("is_branded_content", IsBrandedContent.Value);
		return request;
	}
}
