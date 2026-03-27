using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetExtensionTransactionsResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionTransactionsResponse>
{
    private GodotObject _data;
    public TwitchExtensionTransaction[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionTransactionsResponse object.
    /// </summary> 
    public static TwitchGetExtensionTransactionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetExtensionTransactionsResponse
        {
            Data = dataArray.Select(TwitchExtensionTransaction.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_transactions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetExtensionTransactionsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetExtensionTransactionsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject _data;
        public string Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/response_pagination.gd");
            var paginationClass = script.Get("Pagination").AsGodotObject();
            var request = paginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    public partial class TwitchExtensionTransaction : RefCounted, ITwitcherSharp<TwitchExtensionTransaction>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Timestamp { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string ProductType { get; set; }
        public TwitchProductData ProductData { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchExtensionTransaction object.
        /// </summary> 
        public static TwitchExtensionTransaction FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchExtensionTransaction
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
                ProductData = data.Get("product_data").As<TwitchProductData>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_transaction.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("timestamp", Timestamp);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("product_type", ProductType);
            request.Set("product_data", ProductData);
            return request;
        }
        
        /// <summary> 
        /// Contains details about the digital product. 
        /// </summary>
        public partial class TwitchProductData : RefCounted, ITwitcherSharp<TwitchProductData>
        {
            private GodotObject _data;
            public string Sku { get; set; }
            public string Domain { get; set; }
            public TwitchCost Cost { get; set; }
            public bool InDevelopment { get; set; }
            public string DisplayName { get; set; }
            public string Expiration { get; set; }
            public bool Broadcast { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchProductData object.
            /// </summary> 
            public static TwitchProductData FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchProductData
                {
                    Sku = data.Get("sku").AsString(),
                    Domain = data.Get("domain").AsString(),
                    Cost = data.Get("cost").As<TwitchCost>(),
                    InDevelopment = data.Get("in_development").AsBool(),
                    DisplayName = data.Get("display_name").AsString(),
                    Expiration = data.Get("expiration").AsString(),
                    Broadcast = data.Get("broadcast").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_product_data.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("sku", Sku);
                request.Set("domain", Domain);
                request.Set("cost", Cost);
                request.Set("in_development", InDevelopment);
                request.Set("display_name", DisplayName);
                request.Set("expiration", Expiration);
                request.Set("broadcast", Broadcast);
                return request;
            }
            
            /// <summary> 
            /// Contains details about the digital product’s cost. 
            /// </summary>
            public partial class TwitchCost : RefCounted, ITwitcherSharp<TwitchCost>
            {
                private GodotObject _data;
                public int Amount { get; set; }
                public string Type { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchCost object.
                /// </summary> 
                public static TwitchCost FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    return new TwitchCost
                    {
                        Amount = data.Get("amount").AsInt32(),
                        Type = data.Get("type").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cost.gd");
                    var request = script.Call("new").AsGodotObject();
                    request.Set("amount", Amount);
                    request.Set("type", Type);
                    return request;
                }
            
            }
        
        }
    
    }

}
