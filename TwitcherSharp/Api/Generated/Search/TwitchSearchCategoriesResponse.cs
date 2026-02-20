using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Search;

public partial class TwitchSearchCategoriesResponse : Resource, ITwitcherSharp<TwitchSearchCategoriesResponse>
{
    private GodotObject _data;
    public TwitchCategory[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

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
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_search_categories.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public partial class TwitchCategory : Resource, ITwitcherSharp<TwitchCategory>
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
