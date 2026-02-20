using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchReward : Resource, ITwitcherSharpEventSub<TwitchReward>
{
    /// <summary> 
    /// The reward identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The reward name.
    /// </summary>
    public string Title { get; set; }

    /// <summary> 
    /// The reward cost.
    /// </summary>
    public int Cost { get; set; }

    /// <summary> 
    /// The reward description.
    /// </summary>
    public string Prompt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchReward object.
    /// </summary> 
    public static TwitchReward FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchReward
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Cost = data.Get("cost").AsInt32(),
            Prompt = data.Get("prompt").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_reward.gd");
        var twitchRewardClass = script.Get("TwitchReward").AsGodotObject();
        var request = twitchRewardClass.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("title", Title);
        request.Set("cost", Cost);
        request.Set("prompt", Prompt);
        return request;
    }
}
