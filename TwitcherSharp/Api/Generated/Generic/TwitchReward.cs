using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// An object that describes the reward that the user redeemed. 
/// </summary>
public partial class TwitchReward : Resource, ITwitcherSharp<TwitchReward>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Title { get; set; }
	public string Prompt { get; set; }
	public int Cost { get; set; }

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
			Prompt = data.Get("prompt").AsString(),
			Cost = data.Get("cost").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_reward.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("title", Title);
		request.Set("prompt", Prompt);
		request.Set("cost", Cost);
		return request;
	}
}
