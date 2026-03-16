using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchStreamTag : RefCounted, ITwitcherSharp<TwitchStreamTag>
{
    private GodotObject _data;
    public string TagId { get; set; }
    public bool IsAuto { get; set; }
    public Variant LocalizationNames { get; set; }
    public Variant LocalizationDescriptions { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamTag object.
    /// </summary> 
    public static TwitchStreamTag FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchStreamTag
        {
            TagId = data.Get("tag_id").AsString(),
            IsAuto = data.Get("is_auto").AsBool(),
            LocalizationNames = data.Get("localization_names").As<Variant>(),
            LocalizationDescriptions = data.Get("localization_descriptions").As<Variant>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_stream_tag.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("tag_id", TagId);
        request.Set("is_auto", IsAuto);
        request.Set("localization_names", LocalizationNames);
        request.Set("localization_descriptions", LocalizationDescriptions);
        return request;
    }

}
