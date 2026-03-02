using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;


/// <summary> 
/// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
/// </summary>
public partial class TwitchPagination : Resource, ITwitcherSharp<TwitchPagination>
{
    private GodotObject _data;
    public string Cursor { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPagination object.
    /// </summary> 
    public static TwitchPagination FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchPagination
        {
            Cursor = data.Get("cursor").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_pagination.gd");
        var request = script.Call("new").AsGodotObject();
        if(Cursor != null) request.Set("cursor", Cursor);
        return request;
    }

}
