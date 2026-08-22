using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermBody : RefCounted, ITwitcherSharp<TwitchAddBlockedTermBody>
{
    private GodotObject? _data;
    public string Text { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermBody object.
    /// </summary> 
    public static TwitchAddBlockedTermBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAddBlockedTermBody
        {
            Text = data.Get("text").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(Text != null) request.Set("text", Text);
        return request;
    }

}
