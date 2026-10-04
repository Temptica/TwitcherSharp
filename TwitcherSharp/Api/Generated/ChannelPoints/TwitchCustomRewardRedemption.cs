using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCustomRewardRedemption : RefCounted, ITwitcherSharp<TwitchCustomRewardRedemption>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public TwitchReward Reward { get => field ??= _data.Get<TwitchReward>("reward")!; set; } = null!;
    public string UserInput { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string RedeemedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCustomRewardRedemption object.
    /// </summary> 
    public static TwitchCustomRewardRedemption? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCustomRewardRedemption
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserInput = data.Read("user_input", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
            RedeemedAt = data.Read("redeemed_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_custom_reward_redemption.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(Id != null) request.SetValue("id", Id);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(Reward != null) request.SetObject("reward", Reward);
        if(UserInput != null) request.SetValue("user_input", UserInput);
        if(Status != null) request.SetValue("status", Status);
        if(RedeemedAt != null) request.SetValue("redeemed_at", RedeemedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// An object that describes the reward that the user redeemed. 
    /// </summary>
    public partial class TwitchReward : RefCounted, ITwitcherSharp<TwitchReward>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Prompt { get; set; } = null!;
        public int Cost { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReward
            {
                Id = data.Read("id", static v => v.AsString()),
                Title = data.Read("title", static v => v.AsString()),
                Prompt = data.Read("prompt", static v => v.AsString()),
                Cost = data.Read("cost", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward_redemption.gd", "Reward");
            if(Id != null) request.SetValue("id", Id);
            if(Title != null) request.SetValue("title", Title);
            if(Prompt != null) request.SetValue("prompt", Prompt);
            request.SetValue("cost", Cost);
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
