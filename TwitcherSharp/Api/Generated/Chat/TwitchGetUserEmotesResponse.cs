using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetUserEmotesResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }
    public string Template { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesResponse object.
    /// </summary> 
    public static TwitchGetUserEmotesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetUserEmotesResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
            Template = data.Get("template").AsString(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        request.Set("template", Template);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetUserEmotesResponse> NextPage() =>
        await _data.CallAsync<TwitchGetUserEmotesResponse>("next_page");
    
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
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmoteType { get; set; }
        public string EmoteSetId { get; set; }
        public string OwnerId { get; set; }
        public string[] Format { get; set; }
        public string[] Scale { get; set; }
        public string[] ThemeMode { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                Id = data.Get("id").AsString(),
                Name = data.Get("name").AsString(),
                EmoteType = data.Get("emote_type").AsString(),
                EmoteSetId = data.Get("emote_set_id").AsString(),
                OwnerId = data.Get("owner_id").AsString(),
                Format = data.Get("format").AsStringArray(),
                Scale = data.Get("scale").AsStringArray(),
                ThemeMode = data.Get("theme_mode").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("name", Name);
            request.Set("emote_type", EmoteType);
            request.Set("emote_set_id", EmoteSetId);
            request.Set("owner_id", OwnerId);
            request.Set("format", Format);
            request.Set("scale", Scale);
            request.Set("theme_mode", ThemeMode);
            return request;
        }
    
    }

}
