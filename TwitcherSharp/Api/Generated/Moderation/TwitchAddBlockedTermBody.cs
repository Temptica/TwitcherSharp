using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddBlockedTermBody : RefCounted, ITwitcherSharp<TwitchAddBlockedTermBody>
{
    private Variant _data;
    public string Text { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchAddBlockedTermBody object.
    /// </summary> 
    public static TwitchAddBlockedTermBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAddBlockedTermBody
        {
            Text = data.Read("text", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_add_blocked_term.gd", "Body");
        if(Text != null) request.SetValue("text", Text);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
