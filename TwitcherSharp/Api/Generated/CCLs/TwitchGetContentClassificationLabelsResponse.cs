using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.CCLs;

public partial class TwitchGetContentClassificationLabelsResponse : RefCounted, ITwitcherSharp<TwitchGetContentClassificationLabelsResponse>
{
    private Variant _data;
    public TwitchContentClassificationLabel[] Data { get => field ??= _data.GetArray<TwitchContentClassificationLabel>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetContentClassificationLabelsResponse object.
    /// </summary> 
    public static TwitchGetContentClassificationLabelsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetContentClassificationLabelsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_content_classification_labels.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
