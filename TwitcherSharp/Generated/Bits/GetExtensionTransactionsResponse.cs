using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionTransactionsResponse : Resource, ITwitcherSharp<GetExtensionTransactionsResponse>
{
    private GodotObject _data;
	public ExtensionTransaction[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionTransactionsResponse object.
    /// </summary> 
    public static GetExtensionTransactionsResponse FromObject(GodotObject data)
    {
        return new GetExtensionTransactionsResponse
        {

			Data = data.Get("data").As<ExtensionTransaction[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_transactions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
