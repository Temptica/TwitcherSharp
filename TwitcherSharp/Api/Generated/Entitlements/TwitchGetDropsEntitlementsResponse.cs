using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;

public partial class TwitchGetDropsEntitlementsResponse : RefCounted, ITwitcherSharp<TwitchGetDropsEntitlementsResponse>
{
    private GodotObject _data;
    public TwitchDropsEntitlement[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetDropsEntitlementsResponse object.
    /// </summary> 
    public static TwitchGetDropsEntitlementsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetDropsEntitlementsResponse
        {
            Data = dataArray.Select(TwitchDropsEntitlement.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_drops_entitlements.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetDropsEntitlementsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetDropsEntitlementsResponse>("next_page");
    
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
    public partial class TwitchDropsEntitlement : RefCounted, ITwitcherSharp<TwitchDropsEntitlement>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string BenefitId { get; set; }
        public string Timestamp { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string FulfillmentStatus { get; set; }
        public string LastUpdated { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDropsEntitlement object.
        /// </summary> 
        public static TwitchDropsEntitlement FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchDropsEntitlement
            {
                Id = data.Get("id").AsString(),
                BenefitId = data.Get("benefit_id").AsString(),
                Timestamp = data.Get("timestamp").AsString(),
                UserId = data.Get("user_id").AsString(),
                GameId = data.Get("game_id").AsString(),
                FulfillmentStatus = data.Get("fulfillment_status").AsString(),
                LastUpdated = data.Get("last_updated").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drops_entitlement.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("benefit_id", BenefitId);
            request.Set("timestamp", Timestamp);
            request.Set("user_id", UserId);
            request.Set("game_id", GameId);
            request.Set("fulfillment_status", FulfillmentStatus);
            request.Set("last_updated", LastUpdated);
            return request;
        }
    
    }

}
