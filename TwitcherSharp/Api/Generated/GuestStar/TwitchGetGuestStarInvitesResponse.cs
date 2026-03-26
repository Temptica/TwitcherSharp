using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetGuestStarInvitesResponse : RefCounted, ITwitcherSharp<TwitchGetGuestStarInvitesResponse>
{
    private GodotObject _data;
    public TwitchGuestStarInvite[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGuestStarInvitesResponse object.
    /// </summary> 
    public static TwitchGetGuestStarInvitesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGuestStarInvitesResponse
        {
            Data = dataArray.Select(TwitchGuestStarInvite.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_guest_star_invites.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    public partial class TwitchGuestStarInvite : RefCounted, ITwitcherSharp<TwitchGuestStarInvite>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string InvitedAt { get; set; }
        public string Status { get; set; }
        public bool IsVideoEnabled { get; set; }
        public bool IsAudioEnabled { get; set; }
        public bool IsVideoAvailable { get; set; }
        public bool IsAudioAvailable { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGuestStarInvite object.
        /// </summary> 
        public static TwitchGuestStarInvite FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchGuestStarInvite
            {
                UserId = data.Get("user_id").AsString(),
                InvitedAt = data.Get("invited_at").AsString(),
                Status = data.Get("status").AsString(),
                IsVideoEnabled = data.Get("is_video_enabled").AsBool(),
                IsAudioEnabled = data.Get("is_audio_enabled").AsBool(),
                IsVideoAvailable = data.Get("is_video_available").AsBool(),
                IsAudioAvailable = data.Get("is_audio_available").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest_star_invite.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("invited_at", InvitedAt);
            request.Set("status", Status);
            request.Set("is_video_enabled", IsVideoEnabled);
            request.Set("is_audio_enabled", IsAudioEnabled);
            request.Set("is_video_available", IsVideoAvailable);
            request.Set("is_audio_available", IsAudioAvailable);
            return request;
        }
    
    }

}
