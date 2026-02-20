using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetModeratorsResponse : Resource, ITwitcherSharp<TwitchGetModeratorsResponse>
{
    private GodotObject _data;
    public TwitchUserModerator[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetModeratorsResponse object.
    /// </summary> 
    public static TwitchGetModeratorsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetModeratorsResponse
        {
            Data = dataArray.Select(TwitchUserModerator.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderators.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public partial class TwitchUserModerator : Resource, ITwitcherSharp<TwitchUserModerator>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUserModerator object.
        /// </summary> 
        public static TwitchUserModerator FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchUserModerator
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_moderator.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    
    }

}
