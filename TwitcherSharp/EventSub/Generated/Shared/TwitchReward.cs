using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchReward : RefCounted, ITwitcherSharpEventSub<TwitchReward>
{
    private Variant _data;
    
    /// <summary> 
    /// The reward identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The reward name.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// The reward cost.
    /// </summary>
    public int Cost { get; set; }

    /// <summary> 
    /// The reward description.
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchReward object.
    /// </summary> 
    public static TwitchReward? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchReward
        {
            Id = data.Read("id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Cost = data.Read("cost", static v => v.AsInt32()),
            Prompt = data.Read("prompt", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_reward.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("cost", Cost);
        if(Prompt != null) request.SetValue("prompt", Prompt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
