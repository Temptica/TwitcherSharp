using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchStreamTag : RefCounted, ITwitcherSharp<TwitchStreamTag>
{
    private Variant _data;
    public string TagId { get; set; } = null!;
    public bool IsAuto { get; set; }
    public Godot.Collections.Dictionary<string, string> LocalizationNames { get; set; } = null!;
    public Godot.Collections.Dictionary<string, string> LocalizationDescriptions { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamTag object.
    /// </summary> 
    public static TwitchStreamTag? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamTag
        {
            TagId = data.Read("tag_id", static v => v.AsString()),
            IsAuto = data.Read("is_auto", static v => v.AsBool()),
            LocalizationNames = data.Read("localization_names", static v => v.AsGodotDictionary<string, string>()),
            LocalizationDescriptions = data.Read("localization_descriptions", static v => v.AsGodotDictionary<string, string>()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_stream_tag.gd");
        if(TagId != null) request.SetValue("tag_id", TagId);
        request.SetValue("is_auto", IsAuto);
        if(LocalizationNames != null) request.SetValue("localization_names", LocalizationNames);
        if(LocalizationDescriptions != null) request.SetValue("localization_descriptions", LocalizationDescriptions);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
