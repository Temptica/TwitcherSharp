using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductBody : RefCounted, ITwitcherSharp<TwitchUpdateExtensionBitsProductBody>
{
    private Variant _data;
    public string Sku { get; set; } = null!;
    public TwitchBodyCost Cost { get => field ??= _data.Get<TwitchBodyCost>("cost")!; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public bool? InDevelopment { get; set; }
    public string? Expiration { get; set; }
    public bool? IsBroadcast { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductBody object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateExtensionBitsProductBody
        {
            Sku = data.Read("sku", static v => v.AsString()),
            DisplayName = data.Read("display_name", static v => v.AsString()),
            InDevelopment = data.Read("in_development", static v => v.AsBool()),
            Expiration = data.Read("expiration", static v => v.AsString()),
            IsBroadcast = data.Read("is_broadcast", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd", "Body");
        if(Sku != null) request.SetValue("sku", Sku);
        if(Cost != null) request.SetObject("cost", Cost);
        if(DisplayName != null) request.SetValue("display_name", DisplayName);
        if(InDevelopment.HasValue) request.SetValue("in_development", InDevelopment.Value);
        if(Expiration != null) request.SetValue("expiration", Expiration);
        if(IsBroadcast.HasValue) request.SetValue("is_broadcast", IsBroadcast.Value);
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
    public partial class TwitchBodyCost : RefCounted, ITwitcherSharp<TwitchBodyCost>
    {
        private Variant _data;
        public int Amount { get; set; }
        public string Type { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyCost object.
        /// </summary> 
        public static TwitchBodyCost? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyCost
            {
                Amount = data.Read("amount", static v => v.AsInt32()),
                Type = data.Read("type", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd", "BodyCost");
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
