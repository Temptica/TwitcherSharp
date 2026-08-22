using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatBadge : RefCounted, ITwitcherSharp<TwitchChatBadge>
{
    private GodotObject? _data;
    public string SetId { get; set; } = null!;
    public TwitchVersions[] Versions { get => field ??= _data?.GetArray<TwitchVersions>("versions")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChatBadge object.
    /// </summary> 
    public static TwitchChatBadge? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChatBadge
        {
            SetId = data.Get("set_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chat_badge.gd");
        var request = script.Call("new").AsGodotObject();
        if(SetId != null) request.Set("set_id", SetId);
        if(Versions != null) request.Set("versions", Versions.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// The list of chat badges in this set. 
    /// </summary>
    public partial class TwitchVersions : RefCounted, ITwitcherSharp<TwitchVersions>
    {
        private GodotObject? _data;
        public string Id { get; set; } = null!;
        public string ImageUrl1x { get; set; } = null!;
        public string ImageUrl2x { get; set; } = null!;
        public string ImageUrl4x { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ClickAction { get; set; } = null!;
        public string ClickUrl { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVersions object.
        /// </summary> 
        public static TwitchVersions? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchVersions
            {
                Id = data.Get("id").AsString(),
                ImageUrl1x = data.Get("image_url_1x").AsString(),
                ImageUrl2x = data.Get("image_url_2x").AsString(),
                ImageUrl4x = data.Get("image_url_4x").AsString(),
                Title = data.Get("title").AsString(),
                Description = data.Get("description").AsString(),
                ClickAction = data.Get("click_action").AsString(),
                ClickUrl = data.Get("click_url").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chat_badge.gd");
            var twitchVersionsClass = script.Get("Versions").AsGodotObject();
            var request = twitchVersionsClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(ImageUrl1x != null) request.Set("image_url_1x", ImageUrl1x);
            if(ImageUrl2x != null) request.Set("image_url_2x", ImageUrl2x);
            if(ImageUrl4x != null) request.Set("image_url_4x", ImageUrl4x);
            if(Title != null) request.Set("title", Title);
            if(Description != null) request.Set("description", Description);
            if(ClickAction != null) request.Set("click_action", ClickAction);
            if(ClickUrl != null) request.Set("click_url", ClickUrl);
            return request;
        }
    
    }

}
