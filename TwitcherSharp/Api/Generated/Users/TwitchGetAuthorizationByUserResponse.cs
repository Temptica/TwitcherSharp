using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetAuthorizationByUserResponse : RefCounted, ITwitcherSharp<TwitchGetAuthorizationByUserResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAuthorizationByUserResponse object.
    /// </summary> 
    public static TwitchGetAuthorizationByUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetAuthorizationByUserResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_authorization_by_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }
    
    /// <summary> 
    /// List of users and their authorized scopes. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string[] Scopes { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                Scopes = data.Get("scopes").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("user_login", UserLogin);
            request.Set("scopes", new Godot.Collections.Array<string>(Scopes));
            return request;
        }
    
    }

}
