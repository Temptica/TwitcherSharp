using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchSearchCategoriesResponse : RefCounted, ITwitcherSharp<TwitchSearchCategoriesResponse>
{
    private Variant _data;
    public TwitchCategory[] Data { get => field ??= _data.GetArray<TwitchCategory>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSearchCategoriesResponse object.
    /// </summary> 
    public static TwitchSearchCategoriesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSearchCategoriesResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_search_categories.gd", "Response");
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
    public async Task<TwitchSearchCategoriesResponse> NextPage() =>
        await _data.CallAsync<TwitchSearchCategoriesResponse>("next_page");
    
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_search_categories.gd", "ResponsePagination");
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
