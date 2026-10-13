using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Extensions;
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
    private Variant _data;
    public TwitchApi TwitchApi
    {
        get;
        set
        {
            _data.With(obj => WriteNode(obj, "api", value));
            field = value;
        }
    } = api;

    public TwitchMediaLoader TwitchMediaLoader
    {
        get;
        set
        {
            _data.With(obj => WriteNode(obj, "media_loader", value));
            field = value;
        }
    } = twitchMediaLoader;

    private static bool WriteNode(GodotObject obj, string property, ITwitcherSharp? node)
    {
        obj.SetObject(property, node);
        return true;
    }

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
    public async Task<LoadError> LoadReward(TwitchReward twitchReward)
        => (LoadError)await CallWithReward("load_reward", twitchReward);

    /// <summary>
    /// Tries to create or update an existing reward.
    /// </summary>
    /// <param name="twitchReward"> The reward to save</param>
    /// <returns></returns>
    public async Task<SaveError> SaveReward(TwitchReward twitchReward)
        => (SaveError)await CallWithReward("save_reward", twitchReward);

    /// <summary>
    /// Deletes a reward on Twitch side. Will also remove the ID when succesfully.
    /// </summary>
    /// <param name="twitchReward"> The reward to delete</param>
    /// <returns></returns>
    public async Task<DeleteError> DeleteReward(TwitchReward twitchReward)
        => (DeleteError)await CallWithReward("delete_reward", twitchReward);

    /// <summary>
    /// Calls a reward function of twitcher, which awaits Twitch and changes the reward in place, and copies the
    /// changed reward back into <paramref name="twitchReward"/>.
    /// </summary>
    private async Task<int> CallWithReward(string method, TwitchReward twitchReward)
    {
        if (_data.IsNil) _data = GodotObjectExtension.ToVariant(this);
        using var reward = twitchReward.ToGodotObject();
        using var rewardArg = Variant.CreateFrom(reward);
        using var result = await _data.CallAsync(method, rewardArg);
        twitchReward.ReadFrom(reward);
        return result.AsInt32();
    }
    
    /// <summary>
    /// Creates a new instance of the class from a GodotObject instance.
    /// <br/>
    /// <br/>
    /// This object does not require to be created from an GodotObject. It will instead make one itself if required and dispose it accordingly.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static TwitchRewardService? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var rewardService = new TwitchRewardService(data.Get<TwitchApi>("api")!
            , data.Get<TwitchMediaLoader>("media_loader")!);

        rewardService._data = Variant.CreateFrom(data);
        return rewardService;
    }
    
    public GodotObject ToGodotObject()
    {
        // The API and the media loader are nodes of the scene: passed as they are, not disposed.
        return InteropExtension.NewObject("res://addons/twitcher/reward/twitch_reward_service.gd",
            TwitchApi?.ToGodotObject() ?? new Variant(), TwitchMediaLoader?.ToGodotObject() ?? new Variant());
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own.
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}