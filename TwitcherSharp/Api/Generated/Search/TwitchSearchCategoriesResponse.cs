using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchSearchCategoriesResponse : RefCounted, ITwitcherSharp<TwitchSearchCategoriesResponse>
{
    private GodotObject _data;
    public TwitchCategory[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSearchCategoriesResponse object.
    /// </summary> 
    public static TwitchSearchCategoriesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchSearchCategoriesResponse
        {
            Data = dataArray.Select(TwitchCategory.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchSearchCategoriesResponse> NextPage() =>
        await _data.CallAsync<TwitchSearchCategoriesResponse>("next_page");
    
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
    public partial class TwitchCategory : RefCounted, ITwitcherSharp<TwitchCategory>
    {
        private GodotObject _data;
        public string BoxArtUrl { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCategory object.
        /// </summary> 
        public static TwitchCategory FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchCategory
            {
                BoxArtUrl = data.Get("box_art_url").AsString(),
                Name = data.Get("name").AsString(),
                Id = data.Get("id").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_category.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("box_art_url", BoxArtUrl);
            request.Set("name", Name);
            request.Set("id", Id);
            return request;
        }
    
    }

}
