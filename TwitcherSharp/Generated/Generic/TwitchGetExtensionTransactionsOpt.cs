using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionTransactions 
/// </summary>
public partial class TwitchGetExtensionTransactionsOpt : Resource, ITwitcherSharp<TwitchGetExtensionTransactionsOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionTransactionsOpt object.
    /// </summary> 
    public static TwitchGetExtensionTransactionsOpt FromObject(GodotObject data)
    {
		return new TwitchGetExtensionTransactionsOpt
		{
			Id = data.Get("id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_transactions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
