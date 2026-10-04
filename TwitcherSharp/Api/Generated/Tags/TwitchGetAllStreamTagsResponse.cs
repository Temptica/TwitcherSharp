using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Tags;

public partial class TwitchGetAllStreamTagsResponse : RefCounted, ITwitcherSharp<TwitchGetAllStreamTagsResponse>
{
    private Variant _data;
    public TwitchStreamTag[] Data { get => field ??= _data.GetArray<TwitchStreamTag>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAllStreamTagsResponse object.
    /// </summary> 
    public static TwitchGetAllStreamTagsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAllStreamTagsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public async Task<TwitchGetAllStreamTagsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetAllStreamTagsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private Variant _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Read("cursor", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_all_stream_tags.gd", "ResponsePagination");
            if(Cursor != null) request.SetValue("cursor", Cursor);
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
