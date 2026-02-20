using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermBody : Resource, ITwitcherSharp<TwitchAddBlockedTermBody>
{
    private GodotObject _data;
    public string Text { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermBody object.
    /// </summary> 
    public static TwitchAddBlockedTermBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAddBlockedTermBody
        {
            Text = data.Get("text").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("text", Text);
        return request;
    }

}
