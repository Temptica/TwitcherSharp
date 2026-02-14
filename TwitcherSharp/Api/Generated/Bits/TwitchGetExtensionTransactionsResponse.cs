using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionTransactionsResponse : Resource, ITwitcherSharp<TwitchGetExtensionTransactionsResponse>
{
    private GodotObject _data;
	public TwitchExtensionTransaction[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionTransactionsResponse object.
    /// </summary> 
    public static TwitchGetExtensionTransactionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionTransactionsResponse
		{
			Data = dataArray.Select(TwitchExtensionTransaction.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_transactions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
