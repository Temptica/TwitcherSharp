using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionBitsProduct : RefCounted, ITwitcherSharp<TwitchExtensionBitsProduct>
{
    private GodotObject? _data;
    public string Sku { get; set; } = null!;
    public TwitchCost Cost { get => field ??= _data?.Get<TwitchCost>("cost")!; set; } = null!;
    public bool InDevelopment { get; set; }
    public string DisplayName { get; set; } = null!;
    public string Expiration { get; set; } = null!;
    public bool IsBroadcast { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsProduct object.
    /// </summary> 
    public static TwitchExtensionBitsProduct? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionBitsProduct
        {
            Sku = data.Get("sku").AsString(),
            InDevelopment = data.Get("in_development").AsBool(),
            DisplayName = data.Get("display_name").AsString(),
            Expiration = data.Get("expiration").AsString(),
            IsBroadcast = data.Get("is_broadcast").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_bits_product.gd");
        var request = script.Call("new").AsGodotObject();
        if(Sku != null) request.Set("sku", Sku);
        if(Cost != null) request.Set("cost", Cost.ToGodotObject());
        request.Set("in_development", InDevelopment);
        if(DisplayName != null) request.Set("display_name", DisplayName);
        if(Expiration != null) request.Set("expiration", Expiration);
        request.Set("is_broadcast", IsBroadcast);
        return request;
    }
    
    /// <summary> 
    /// An object that contains the product's cost information. 
    /// </summary>
    public partial class TwitchCost : RefCounted, ITwitcherSharp<TwitchCost>
    {
        private GodotObject? _data;
        public int Amount { get; set; }
        public string Type { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCost object.
        /// </summary> 
        public static TwitchCost? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCost
            {
                Amount = data.Get("amount").AsInt32(),
                Type = data.Get("type").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_bits_product.gd");
            var twitchCostClass = script.Get("Cost").AsGodotObject();
            var request = twitchCostClass.Call("new").AsGodotObject();
            request.Set("amount", Amount);
            if(Type != null) request.Set("type", Type);
            return request;
        }
    
    }

}
