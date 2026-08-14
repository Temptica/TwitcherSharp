using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchExtensionTransaction : RefCounted, ITwitcherSharp<TwitchExtensionTransaction>
{
    private GodotObject? _data;
    public string? Id { get; set; }
    public string? Timestamp { get; set; }
    public string? BroadcasterId { get; set; }
    public string? BroadcasterLogin { get; set; }
    public string? BroadcasterName { get; set; }
    public string? UserId { get; set; }
    public string? UserLogin { get; set; }
    public string? UserName { get; set; }
    public string? ProductType { get; set; }
    public TwitchResponseProductData? ProductData { get => field ??= _data?.Get<TwitchResponseProductData>("product_data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionTransaction object.
    /// </summary> 
    public static TwitchExtensionTransaction? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionTransaction
        {
            Id = data.Get("id").AsString(),
            Timestamp = data.Get("timestamp").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            ProductType = data.Get("product_type").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_transaction.gd");
        var request = script.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Timestamp != null) request.Set("timestamp", Timestamp);
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(ProductType != null) request.Set("product_type", ProductType);
        if(ProductData != null) request.Set("product_data", ProductData.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// Contains details about the digital product. 
    /// </summary>
    public partial class TwitchResponseProductData : RefCounted, ITwitcherSharp<TwitchResponseProductData>
    {
        private GodotObject? _data;
        public string? Sku { get; set; }
        public string? Domain { get; set; }
        public TwitchResponseCost? Cost { get => field ??= _data?.Get<TwitchResponseCost>("cost"); set; }
        public bool InDevelopment { get; set; }
        public string? DisplayName { get; set; }
        public string? Expiration { get; set; }
        public bool Broadcast { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseProductData object.
        /// </summary> 
        public static TwitchResponseProductData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseProductData
            {
                Sku = data.Get("sku").AsString(),
                Domain = data.Get("domain").AsString(),
                InDevelopment = data.Get("in_development").AsBool(),
                DisplayName = data.Get("display_name").AsString(),
                Expiration = data.Get("expiration").AsString(),
                Broadcast = data.Get("broadcast").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_transaction.gd");
            var twitchResponseProductDataClass = script.Get("ProductData").AsGodotObject();
            var request = twitchResponseProductDataClass.Call("new").AsGodotObject();
            if(Sku != null) request.Set("sku", Sku);
            if(Domain != null) request.Set("domain", Domain);
            if(Cost != null) request.Set("cost", Cost.ToGodotObject());
            request.Set("in_development", InDevelopment);
            if(DisplayName != null) request.Set("display_name", DisplayName);
            if(Expiration != null) request.Set("expiration", Expiration);
            request.Set("broadcast", Broadcast);
            return request;
        }
        
        /// <summary> 
        /// Contains details about the digital product’s cost. 
        /// </summary>
        public partial class TwitchResponseCost : RefCounted, ITwitcherSharp<TwitchResponseCost>
        {
            private GodotObject? _data;
            public int Amount { get; set; }
            public string? Type { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseCost object.
            /// </summary> 
            public static TwitchResponseCost? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseCost
                {
                    Amount = data.Get("amount").AsInt32(),
                    Type = data.Get("type").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_transaction.gd");
                var twitchResponseCostClass = script.Get("Cost").AsGodotObject();
                var request = twitchResponseCostClass.Call("new").AsGodotObject();
                request.Set("amount", Amount);
                if(Type != null) request.Set("type", Type);
                return request;
            }
        
        }
    
    }

}
