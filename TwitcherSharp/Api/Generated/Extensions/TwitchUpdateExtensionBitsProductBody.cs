using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductBody : RefCounted, ITwitcherSharp<TwitchUpdateExtensionBitsProductBody>
{
    private GodotObject _data;
    public string Sku { get; set; }
    public TwitchBodyCost Cost { get => field ??= _data?.Get<TwitchBodyCost>("cost"); set; }
    public string DisplayName { get; set; }
    public bool? InDevelopment { get; set; }
    public string Expiration { get; set; }
    public bool? IsBroadcast { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductBody object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateExtensionBitsProductBody
        {
            Sku = data.Get("sku").AsString(),
            DisplayName = data.Get("display_name").AsString(),
            InDevelopment = data.Get("in_development").AsBool(),
            Expiration = data.Get("expiration").AsString(),
            IsBroadcast = data.Get("is_broadcast").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("sku", Sku);
        request.Set("cost", Cost?.ToGodotObject());
        request.Set("display_name", DisplayName);
        if(InDevelopment.HasValue) request.Set("in_development", InDevelopment.Value);
        if(Expiration != null) request.Set("expiration", Expiration);
        if(IsBroadcast.HasValue) request.Set("is_broadcast", IsBroadcast.Value);
        return request;
    }
    
    /// <summary> 
    /// An object that contains the product's cost information. 
    /// </summary>
    public partial class TwitchBodyCost : RefCounted, ITwitcherSharp<TwitchBodyCost>
    {
        private GodotObject _data;
        public int Amount { get; set; }
        public string Type { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyCost object.
        /// </summary> 
        public static TwitchBodyCost FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyCost
            {
                Amount = data.Get("amount").AsInt32(),
                Type = data.Get("type").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd");
            var twitchBodyCostClass = script.Get("BodyCost").AsGodotObject();
            var request = twitchBodyCostClass.Call("new").AsGodotObject();
            request.Set("amount", Amount);
            request.Set("type", Type);
            return request;
        }
    
    }

}
