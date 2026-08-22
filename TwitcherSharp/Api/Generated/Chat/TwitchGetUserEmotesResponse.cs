using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetUserEmotesResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }
    public string? Template { get; set; }
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesResponse object.
    /// </summary> 
    public static TwitchGetUserEmotesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserEmotesResponse
        {
            Template = data.Get("template").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Template != null) request.Set("template", Template);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetUserEmotesResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetUserEmotesResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? EmoteType { get; set; }
        public string? EmoteSetId { get; set; }
        public string? OwnerId { get; set; }
        public string[]? Format { get; set; }
        public string[]? Scale { get; set; }
        public string[]? ThemeMode { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
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
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_emotes.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(Name != null) request.Set("name", Name);
            if(EmoteType != null) request.Set("emote_type", EmoteType);
            if(EmoteSetId != null) request.Set("emote_set_id", EmoteSetId);
            if(OwnerId != null) request.Set("owner_id", OwnerId);
            if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
            if(Scale != null) request.Set("scale", new Godot.Collections.Array<string>(Scale));
            if(ThemeMode != null) request.Set("theme_mode", new Godot.Collections.Array<string>(ThemeMode));
            return request;
        }
    
    }

}
