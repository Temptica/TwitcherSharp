using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchChannelEditor : RefCounted, ITwitcherSharp<TwitchChannelEditor>
{
    private GodotObject? _data;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelEditor object.
    /// </summary> 
    public static TwitchChannelEditor? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelEditor
        {
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_channel_editor.gd");
        var request = script.Call("new").AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserName != null) request.Set("user_name", UserName);
        if(CreatedAt != null) request.Set("created_at", CreatedAt);
        return request;
    }

}
