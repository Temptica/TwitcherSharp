using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;


/// <summary> 
/// All optional parameters for TwitchAPI.GetUserBlockList 
/// </summary>
public partial class TwitchGetUserBlockListOpt : RefCounted, ITwitcherSharp<TwitchGetUserBlockListOpt>
{
    private Variant _data;
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserBlockListOpt object.
    /// </summary> 
    public static TwitchGetUserBlockListOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserBlockListOpt
        {
            First = data.Read("first", static v => v.AsInt32()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_block_list.gd", "Opt");
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
