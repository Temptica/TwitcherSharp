using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// List of shards to update. 
/// </summary>
public partial class TwitchShards : Resource, ITwitcherSharp<TwitchShards>
{
    private GodotObject _data;
	public string Id { get; set; }
	public TwitchTransport Transport { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchShards object.
    /// </summary> 
    public static TwitchShards FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchShards
		{
			Id = data.Get("id").AsString(),
			Transport = data.Get("transport").As<TwitchTransport>(),
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
