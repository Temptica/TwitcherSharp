using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;


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
        if(data == null) return null;
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
        if(Locale != null) request.Set("locale", Locale);
        return request;
    }

}
