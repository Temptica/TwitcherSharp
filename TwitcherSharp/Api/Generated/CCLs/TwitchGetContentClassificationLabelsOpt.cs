using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;


/// <summary> 
/// All optional parameters for TwitchAPI.GetContentClassificationLabels 
/// </summary>
public partial class TwitchGetContentClassificationLabelsOpt : RefCounted, ITwitcherSharp<TwitchGetContentClassificationLabelsOpt>
{
    private GodotObject _data;
    public string Locale { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsOpt object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetContentClassificationLabelsOpt
        {
            Locale = data.Get("locale").AsString(),
        };
        
        instance._data = data;
        return instance;
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
