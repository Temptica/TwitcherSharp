using System.Text.RegularExpressions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

/// <summary>
/// Resolves the "response script" name (twitch_es_&lt;name&gt;.gd) each TwitchEventSubDefinition should point to.
/// The Twitcher (GDScript) addon names these payload scripts after the *event* they carry, not the subscription
/// type string, so a handful of them can't be derived mechanically (e.g. channel.charity_campaign.donate ->
/// charity_donation). Those are captured in <see cref="Overrides"/>; everything else follows the "channel." prefix
/// staying as-is, deduped where Twitch's own type name repeats it (channel.channel_points_...).
///
/// This deliberately does not validate against the Twitcher addon's generated_eventsub folder - that addon isn't
/// reliably kept in sync with Twitch, so it isn't a trustworthy source of truth here.
/// </summary>
public static class EventSubScriptNameResolver
{
    private static readonly Dictionary<string, string> Overrides = new()
    {
        ["channel.charity_campaign.donate"] = "charity_donation",
        ["channel.charity_campaign.start"] = "charity_campaign_start",
        ["channel.charity_campaign.progress"] = "charity_campaign_progress",
        ["channel.charity_campaign.stop"] = "charity_campaign_stop",
        ["channel.hype_train.begin"] = "hype_train_begin",
        ["channel.hype_train.progress"] = "hype_train_progress",
        ["channel.hype_train.end"] = "hype_train_end",
        ["channel.shared_chat.begin"] = "channel_shared_chat_session_begin",
        ["channel.shared_chat.update"] = "channel_shared_chat_session_update",
        ["channel.shared_chat.end"] = "channel_shared_chat_session_end",
        ["channel.shield_mode.begin"] = "shield_mode",
        ["channel.shield_mode.end"] = "shield_mode",
        ["channel.goal.begin"] = "goals",
        ["channel.goal.progress"] = "goals",
        ["channel.goal.end"] = "goals",
        ["user.whisper.message"] = "whisper_received",
        ["channel.shoutout.create"] = "shoutout_create",
        ["channel.shoutout.receive"] = "shoutout_received",
    };

    public static void Resolve(List<TwitchEventSubDefinitionInfo> definitions)
    {
        foreach (var definition in definitions)
        {
            if (Overrides.TryGetValue(definition.Value, out var overrideName))
            {
                definition.ScriptName = overrideName;
                continue;
            }

            // Twitch's own type name sometimes repeats "channel_" (e.g. channel.channel_points_custom_reward...),
            // but the addon's script names don't - safe to dedupe unconditionally.
            var defaultCandidate = definition.Value.Replace(".", "_");
            definition.ScriptName = Regex.Replace(defaultCandidate, "^channel_channel_", "channel_");
        }
    }
}
