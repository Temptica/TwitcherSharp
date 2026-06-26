using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;

namespace TwitcherSharp.Reward;

/// <summary>
/// Service for managing Twitch rewards.
/// This object does not require to be created from a GodotObject. It will instead make one itself when required
/// </summary>
/// <param name="api"></param>
/// <param name="twitchMediaLoader"></param>
public partial class TwitchRewardService(TwitchApi api, TwitchMediaLoader twitchMediaLoader)
    : RefCounted, ITwitcherSharp<TwitchRewardService>
{
    private GodotObject _data;
    public TwitchApi TwitchApi { get; set; } = api;
    public TwitchMediaLoader TwitchMediaLoader { get; set; } = twitchMediaLoader;

    public enum LoadError
    {
        /// <summary>
        /// All fine
        /// </summary>
        Ok,

        /// <summary>
        /// When the reward has no id to load
        /// </summary>
        NoIdAvailable,

        /// <summary>
        /// When there is no reward on Twitch side
        /// </summary>
        NoRewardFound,
    }

    public enum SaveError
    {
        /// <summary>
        /// All fine
        /// </summary>
        Ok,

        /// <summary>
        /// When the reward was created by another application
        /// </summary>
        RewardNotOwned,

        /// <summary>
        /// Something unexpected happend during save
        /// </summary>
        Unknown,
    }

    public enum DeleteError
    {
        /// <summary>
        /// All fine
        /// </summary>
        Ok,

        /// <summary>
        /// When the reward to delete does not have an ID. Maybe was new reward?
        /// </summary>
        NoId,

        /// <summary>
        /// When the reward to delete does not have a broadcaster user saved to it.
        /// </summary>
        NoBroadcasterUser,
    }

    /// <summary>
    /// Loads the reward data inplace from Twitch.
    /// </summary>
    /// <param name="twitchReward"></param>
    /// <returns></returns>
    public LoadError LoadReward(TwitchReward twitchReward)
    {
        _data ??= ToGodotObject();

        return _data.Call("load_reward", twitchReward).As<LoadError>();
    }

    /// <summary>
    /// Tries to create or update an existing reward.
    /// </summary>
    /// <param name="twitchReward"> The reward to save</param>
    /// <returns></returns>
    public SaveError SaveReward(TwitchReward twitchReward)
    {
        _data ??= ToGodotObject();

        return _data.Call("save_reward", twitchReward).As<SaveError>();
    }

    /// <summary>
    /// Deletes a reward on Twitch side. Will also remove the ID when succesfully.
    /// </summary>
    /// <param name="twitchReward"> The reward to delete</param>
    /// <returns></returns>
    public DeleteError DeleteReward(TwitchReward twitchReward)
    {
        _data ??= ToGodotObject();

        return _data.Call("delete_reward", twitchReward).As<DeleteError>();
    }
    
    /// <summary>
    /// Creates a new instance of the class from a GodotObject instance.
    /// <br/>
    /// <br/>
    /// This object does not require to be created from an GodotObject. It will instead make one itself if required and dispose it accordingly.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static TwitchRewardService FromObject(GodotObject data)
    {
        var rewardService = new TwitchRewardService(TwitchApi.FromObject(data.Get("twitch_api").AsGodotObject())
            , TwitchMediaLoader.FromObject(data.Get("twitch_media_loader").AsGodotObject()));
        
        rewardService._data = data;
        return rewardService;
    }
    
    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/reward/twitch_reward_service.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("twitch_api", TwitchApi?.ToGodotObject());
        instance.Set("twitch_media_loader", TwitchMediaLoader?.ToGodotObject());
        return instance;
    }
}