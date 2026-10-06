using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatBadge : RefCounted, ITwitcherSharp<TwitchChatBadge>
{
    private Variant _data;
    public string SetId { get; set; } = null!;
    public TwitchVersions[] Versions { get => field ??= _data.GetArray<TwitchVersions>("versions")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchChatBadge object.
    /// </summary> 
    public static TwitchChatBadge? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChatBadge
        {
            SetId = data.Read("set_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_chat_badge.gd");
        if(SetId != null) request.SetValue("set_id", SetId);
        if(Versions != null) request.SetArray("versions", Versions);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The list of chat badges in this set. 
    /// </summary>
    public partial class TwitchVersions : RefCounted, ITwitcherSharp<TwitchVersions>
    {
        private Variant _data;
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
                Id = data.Read("id", static v => v.AsString()),
                ImageUrl1x = data.Read("image_url_1x", static v => v.AsString()),
                ImageUrl2x = data.Read("image_url_2x", static v => v.AsString()),
                ImageUrl4x = data.Read("image_url_4x", static v => v.AsString()),
                Title = data.Read("title", static v => v.AsString()),
                Description = data.Read("description", static v => v.AsString()),
                ClickAction = data.Read("click_action", static v => v.AsString()),
                ClickUrl = data.Read("click_url", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_chat_badge.gd", "Versions");
            if(Id != null) request.SetValue("id", Id);
            if(ImageUrl1x != null) request.SetValue("image_url_1x", ImageUrl1x);
            if(ImageUrl2x != null) request.SetValue("image_url_2x", ImageUrl2x);
            if(ImageUrl4x != null) request.SetValue("image_url_4x", ImageUrl4x);
            if(Title != null) request.SetValue("title", Title);
            if(Description != null) request.SetValue("description", Description);
            if(ClickAction != null) request.SetValue("click_action", ClickAction);
            if(ClickUrl != null) request.SetValue("click_url", ClickUrl);
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
