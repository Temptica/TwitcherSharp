using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetUserEmotesResponse : RefCounted, ITwitcherSharp<TwitchGetUserEmotesResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public string Template { get; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserEmotesResponse object.
    /// </summary> 
    public static TwitchGetUserEmotesResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUserEmotesResponse
        {
            Template = data.Read("template", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_emotes.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Template != null) request.SetValue("template", Template);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public async Task<TwitchGetUserEmotesResponse> NextPage() =>
        await _data.CallAsync<TwitchGetUserEmotesResponse>("next_page");
    
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_emotes.gd", "ResponsePagination");
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
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string EmoteType { get; set; } = null!;
        public string EmoteSetId { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public string[] Format { get; set; } = null!;
        public string[] Scale { get; set; } = null!;
        public string[] ThemeMode { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Read("id", static v => v.AsString()),
                Name = data.Read("name", static v => v.AsString()),
                EmoteType = data.Read("emote_type", static v => v.AsString()),
                EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
                OwnerId = data.Read("owner_id", static v => v.AsString()),
                Format = data.Read("format", static v => v.AsStringArray()),
                Scale = data.Read("scale", static v => v.AsStringArray()),
                ThemeMode = data.Read("theme_mode", static v => v.AsStringArray()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_user_emotes.gd", "ResponseData");
            if(Id != null) request.SetValue("id", Id);
            if(Name != null) request.SetValue("name", Name);
            if(EmoteType != null) request.SetValue("emote_type", EmoteType);
            if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
            if(OwnerId != null) request.SetValue("owner_id", OwnerId);
            if(Format != null) request.SetValue("format", new Godot.Collections.Array<string>(Format));
            if(Scale != null) request.SetValue("scale", new Godot.Collections.Array<string>(Scale));
            if(ThemeMode != null) request.SetValue("theme_mode", new Godot.Collections.Array<string>(ThemeMode));
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
