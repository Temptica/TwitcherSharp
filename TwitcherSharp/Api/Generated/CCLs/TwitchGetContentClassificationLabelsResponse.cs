using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchGetContentClassificationLabelsResponse : RefCounted, ITwitcherSharp<TwitchGetContentClassificationLabelsResponse>
{
    private GodotObject _data;
    public TwitchContentClassificationLabel[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsResponse object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetContentClassificationLabelsResponse
        {
            Data = dataArray.Select(TwitchContentClassificationLabel.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_content_classification_labels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
