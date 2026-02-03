using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// An object that describes the reward that the user redeemed. 
/// </summary>
public partial class Reward : Resource, ITwitcherSharp<Reward>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Title { get; set; }
	public string Prompt { get; set; }
	public int Cost { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Reward object.
    /// </summary> 
    public static Reward FromObject(GodotObject data)
    {
        return new Reward
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
