using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchProduct : RefCounted, ITwitcherSharpEventSub<TwitchProduct>
{
    /// <summary> 
    /// Product name.
    /// </summary>
    public string Name { get; set; }

    /// <summary> 
    /// Bits involved in the transaction.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Unique identifier for the product acquired.
    /// </summary>
    public string Sku { get; set; }

    /// <summary> 
    /// Flag indicating if the product is in development. If in_development is true, bits will be 0.
    /// </summary>
    public bool InDevelopment { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchProduct object.
    /// </summary> 
    public static TwitchProduct FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchProduct
        {
            Name = data.Get("name").AsString(),
            Bits = data.Get("bits").AsInt32(),
            Sku = data.Get("sku").AsString(),
            InDevelopment = data.Get("in_development").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_product.gd");
        var request = script.New().AsGodotObject();
        request.Set("name", Name);
        request.Set("bits", Bits);
        request.Set("sku", Sku);
        request.Set("in_development", InDevelopment);
        return request;
    }
}
