using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

public partial class TwitchGetAuthorizationByUserResponse : RefCounted, ITwitcherSharp<TwitchGetAuthorizationByUserResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetAuthorizationByUserResponse object.
    /// </summary> 
    public static TwitchGetAuthorizationByUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetAuthorizationByUserResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_authorization_by_user.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// List of users and their authorized scopes. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public string[] Scopes { get; set; } = null!;
        public bool HasAuthorized { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                UserId = data.Read("user_id", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                Scopes = data.Read("scopes", static v => v.AsStringArray()),
                HasAuthorized = data.Read("has_authorized", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_authorization_by_user.gd", "ResponseData");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(Scopes != null) request.SetValue("scopes", new Godot.Collections.Array<string>(Scopes));
            request.SetValue("has_authorized", HasAuthorized);
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
