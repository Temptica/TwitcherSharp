using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchProduct : RefCounted, ITwitcherSharpEventSub<TwitchProduct>
{
    private Variant _data;
    
    /// <summary> 
    /// Product name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary> 
    /// Bits involved in the transaction.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Unique identifier for the product acquired.
    /// </summary>
    public string? Sku { get; set; }

    /// <summary> 
    /// Flag indicating if the product is in development. If in_development is true, bits will be 0.
    /// </summary>
    public bool InDevelopment { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchProduct object.
    /// </summary> 
    public static TwitchProduct? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchProduct
        {
            Name = data.Read("name", static v => v.AsString()),
            Bits = data.Read("bits", static v => v.AsInt32()),
            Sku = data.Read("sku", static v => v.AsString()),
            InDevelopment = data.Read("in_development", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_product.gd");
        if(Name != null) request.SetValue("name", Name);
        request.SetValue("bits", Bits);
        if(Sku != null) request.SetValue("sku", Sku);
        request.SetValue("in_development", InDevelopment);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
