using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchExtensionTransaction : RefCounted, ITwitcherSharp<TwitchExtensionTransaction>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string Timestamp { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string ProductType { get; set; } = null!;
    public TwitchResponseProductData ProductData { get => field ??= _data.Get<TwitchResponseProductData>("product_data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionTransaction object.
    /// </summary> 
    public static TwitchExtensionTransaction? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionTransaction
        {
            Id = data.Read("id", static v => v.AsString()),
            Timestamp = data.Read("timestamp", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            ProductType = data.Read("product_type", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_transaction.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Timestamp != null) request.SetValue("timestamp", Timestamp);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(ProductType != null) request.SetValue("product_type", ProductType);
        if(ProductData != null) request.SetObject("product_data", ProductData);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// Contains details about the digital product. 
    /// </summary>
    public partial class TwitchResponseProductData : RefCounted, ITwitcherSharp<TwitchResponseProductData>
    {
        private Variant _data;
        public string Sku { get; set; } = null!;
        public string Domain { get; set; } = null!;
        public TwitchResponseCost Cost { get => field ??= _data.Get<TwitchResponseCost>("cost")!; set; } = null!;
        public bool InDevelopment { get; set; }
        public string DisplayName { get; set; } = null!;
        public string Expiration { get; set; } = null!;
        public bool Broadcast { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseProductData object.
        /// </summary> 
        public static TwitchResponseProductData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseProductData
            {
                Sku = data.Read("sku", static v => v.AsString()),
                Domain = data.Read("domain", static v => v.AsString()),
                InDevelopment = data.Read("inDevelopment", static v => v.AsBool()),
                DisplayName = data.Read("displayName", static v => v.AsString()),
                Expiration = data.Read("expiration", static v => v.AsString()),
                Broadcast = data.Read("broadcast", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension_transaction.gd", "ProductData");
            if(Sku != null) request.SetValue("sku", Sku);
            if(Domain != null) request.SetValue("domain", Domain);
            if(Cost != null) request.SetObject("cost", Cost);
            request.SetValue("inDevelopment", InDevelopment);
            if(DisplayName != null) request.SetValue("displayName", DisplayName);
            if(Expiration != null) request.SetValue("expiration", Expiration);
            request.SetValue("broadcast", Broadcast);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// Contains details about the digital product’s cost. 
        /// </summary>
        public partial class TwitchResponseCost : RefCounted, ITwitcherSharp<TwitchResponseCost>
        {
            private Variant _data;
            public int Amount { get; set; }
            public string Type { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseCost object.
            /// </summary> 
            public static TwitchResponseCost? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseCost
                {
                    Amount = data.Read("amount", static v => v.AsInt32()),
                    Type = data.Read("type", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension_transaction.gd", "Cost");
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

}
