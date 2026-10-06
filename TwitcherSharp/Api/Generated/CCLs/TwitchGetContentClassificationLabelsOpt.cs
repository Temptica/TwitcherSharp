using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;


/// <summary> 
/// All optional parameters for TwitchAPI.GetContentClassificationLabels 
/// </summary>
public partial class TwitchGetContentClassificationLabelsOpt : RefCounted, ITwitcherSharp<TwitchGetContentClassificationLabelsOpt>
{
    private Variant _data;
    public string? Locale { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsOpt object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetContentClassificationLabelsOpt
        {
            Locale = data.Read("locale", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_content_classification_labels.gd", "Opt");
        if(Locale != null) request.SetValue("locale", Locale);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
