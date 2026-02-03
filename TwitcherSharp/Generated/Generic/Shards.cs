using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// List of shards to update. 
/// </summary>
public partial class Shards : Resource, ITwitcherSharp<Shards>
{
    private GodotObject _data;
	public string Id { get; set; }
	public Transport Transport { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Shards object.
    /// </summary> 
    public static Shards FromObject(GodotObject data)
    {
        return new Shards
        {

			Id = data.Get("id").AsString(),
			Transport = data.Get("transport").As<Transport>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_shards.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("transport", Transport);
		return request;
	}
}
