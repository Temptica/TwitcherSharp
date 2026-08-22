using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchStreamTag : RefCounted, ITwitcherSharp<TwitchStreamTag>
{
    private GodotObject? _data;
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
            TagId = data.Get("tag_id").AsString(),
            IsAuto = data.Get("is_auto").AsBool(),
            LocalizationNames = data.Get("localization_names").AsGodotDictionary<string, string>(),
            LocalizationDescriptions = data.Get("localization_descriptions").AsGodotDictionary<string, string>(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_tag.gd");
        var request = script.Call("new").AsGodotObject();
        if(TagId != null) request.Set("tag_id", TagId);
        request.Set("is_auto", IsAuto);
        if(LocalizationNames != null) request.Set("localization_names", LocalizationNames);
        if(LocalizationDescriptions != null) request.Set("localization_descriptions", LocalizationDescriptions);
        return request;
    }

}
