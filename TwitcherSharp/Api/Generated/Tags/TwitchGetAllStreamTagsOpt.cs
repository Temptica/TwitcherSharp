using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;


/// <summary> 
/// All optional parameters for TwitchAPI.GetAllStreamTags 
/// </summary>
public partial class TwitchGetAllStreamTagsOpt : RefCounted, ITwitcherSharp<TwitchGetAllStreamTagsOpt>
{
    private Variant _data;
    public string[]? TagId { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsOpt object.
    /// </summary> 
    public static TwitchGetAllStreamTagsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAllStreamTagsOpt
        {
            TagId = data.Read("tag_id", static v => v.AsStringArray()),
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd", "Opt");
        if(TagId != null) request.SetValue("tag_id", new Godot.Collections.Array<string>(TagId));
        if(First.HasValue) request.SetValue("first", First.Value);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
