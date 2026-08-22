using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChattersResponse : RefCounted, ITwitcherSharp<TwitchGetChattersResponse>
{
    private GodotObject? _data;
    public TwitchChatter[] Data { get => field ??= _data?.GetArray<TwitchChatter>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChattersResponse object.
    /// </summary> 
    public static TwitchGetChattersResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChattersResponse
        {
            Total = data.Get("total").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetChattersResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetChattersResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }

}
