using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchGetCustomRewardRedemptionResponse : RefCounted, ITwitcherSharp<TwitchGetCustomRewardRedemptionResponse>
{
    private GodotObject? _data;
    public TwitchCustomRewardRedemption[] Data { get => field ??= _data?.GetArray<TwitchCustomRewardRedemption>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardRedemptionResponse object.
    /// </summary> 
    public static TwitchGetCustomRewardRedemptionResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomRewardRedemptionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetCustomRewardRedemptionResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetCustomRewardRedemptionResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject? _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }

}
