using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Polls;

public partial class TwitchEndPollResponse : RefCounted, ITwitcherSharp<TwitchEndPollResponse>
{
    private Variant _data;
    public TwitchPoll[] Data { get => field ??= _data.GetArray<TwitchPoll>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollResponse object.
    /// </summary> 
    public static TwitchEndPollResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPollResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_end_poll.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
