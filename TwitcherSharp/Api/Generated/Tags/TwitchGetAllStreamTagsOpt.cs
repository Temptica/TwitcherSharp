using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;


/// <summary> 
/// All optional parameters for TwitchAPI.GetAllStreamTags 
/// </summary>
public partial class TwitchGetAllStreamTagsOpt : RefCounted, ITwitcherSharp<TwitchGetAllStreamTagsOpt>
{
    private GodotObject _data;
    public string[] TagId { get; set; }
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsOpt object.
    /// </summary> 
    public static TwitchGetAllStreamTagsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAllStreamTagsOpt
        {
            TagId = data.Get("tag_id").AsStringArray(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(TagId != null) request.Set("tag_id", new Godot.Collections.Array<string>(TagId));
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
