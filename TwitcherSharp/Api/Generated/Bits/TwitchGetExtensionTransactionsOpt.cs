using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionTransactions 
/// </summary>
public partial class TwitchGetExtensionTransactionsOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionTransactionsOpt>
{
    private GodotObject? _data;
    public string[]? Id { get; set; }
    public int? First { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionTransactionsOpt object.
    /// </summary> 
    public static TwitchGetExtensionTransactionsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionTransactionsOpt
        {
            Id = data.Get("id").AsStringArray(),
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_transactions.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", new Godot.Collections.Array<string>(Id));
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
