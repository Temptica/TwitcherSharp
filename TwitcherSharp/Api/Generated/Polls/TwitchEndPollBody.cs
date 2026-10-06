using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchEndPollBody : RefCounted, ITwitcherSharp<TwitchEndPollBody>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Status { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollBody object.
    /// </summary> 
    public static TwitchEndPollBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPollBody
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_end_poll.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(Id != null) request.SetValue("id", Id);
        if(Status != null) request.SetValue("status", Status);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
