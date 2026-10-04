using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionBitsProduct : RefCounted, ITwitcherSharp<TwitchExtensionBitsProduct>
{
    private Variant _data;
    public string Sku { get; set; } = null!;
    public TwitchCost Cost { get => field ??= _data.Get<TwitchCost>("cost")!; set; } = null!;
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
            Sku = data.Read("sku", static v => v.AsString()),
            InDevelopment = data.Read("in_development", static v => v.AsBool()),
            DisplayName = data.Read("display_name", static v => v.AsString()),
            Expiration = data.Read("expiration", static v => v.AsString()),
            IsBroadcast = data.Read("is_broadcast", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_bits_product.gd");
        if(Sku != null) request.SetValue("sku", Sku);
        if(Cost != null) request.SetObject("cost", Cost);
        request.SetValue("in_development", InDevelopment);
        if(DisplayName != null) request.SetValue("display_name", DisplayName);
        if(Expiration != null) request.SetValue("expiration", Expiration);
        request.SetValue("is_broadcast", IsBroadcast);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// An object that contains the product's cost information. 
    /// </summary>
    public partial class TwitchCost : RefCounted, ITwitcherSharp<TwitchCost>
    {
        private Variant _data;
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
                Amount = data.Read("amount", static v => v.AsInt32()),
                Type = data.Read("type", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension_bits_product.gd", "Cost");
            request.SetValue("amount", Amount);
            if(Type != null) request.SetValue("type", Type);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
