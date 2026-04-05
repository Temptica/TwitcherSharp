using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchChatBadge : RefCounted, ITwitcherSharp<TwitchChatBadge>
{
    private GodotObject _data;
    public string SetId { get; set; }
    public TwitchVersions[] Versions { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChatBadge object.
    /// </summary> 
    public static TwitchChatBadge FromObject(GodotObject data)
    {
        if(data == null) return null;
        var versionsArray = data.Get("versions").AsGodotArray<GodotObject>();
        return new TwitchChatBadge
        {
            SetId = data.Get("set_id").AsString(),
            Versions = versionsArray.Select(TwitchVersions.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chat_badge.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("set_id", SetId);
        if(Versions != null) request.Set("versions", new Godot.Collections.Array<GodotObject>(Versions.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }
    
    /// <summary> 
    /// The list of chat badges in this set. 
    /// </summary>
    public partial class TwitchVersions : RefCounted, ITwitcherSharp<TwitchVersions>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string ImageUrl1x { get; set; }
        public string ImageUrl2x { get; set; }
        public string ImageUrl4x { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClickAction { get; set; }
        public string ClickUrl { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVersions object.
        /// </summary> 
        public static TwitchVersions FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchVersions
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
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_versions.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("image_url_1x", ImageUrl1x);
            request.Set("image_url_2x", ImageUrl2x);
            request.Set("image_url_4x", ImageUrl4x);
            request.Set("title", Title);
            request.Set("description", Description);
            request.Set("click_action", ClickAction);
            request.Set("click_url", ClickUrl);
            return request;
        }
    
    }

}
