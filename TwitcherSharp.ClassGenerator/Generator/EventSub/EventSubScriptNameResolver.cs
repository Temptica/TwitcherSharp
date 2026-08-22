using System.Text.RegularExpressions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

/// <summary>
/// Resolves the "response script" name (twitch_es_&lt;name&gt;.gd) each TwitchEventSubDefinition should point to.
/// The Twitcher (GDScript) addon names these payload scripts after the *event* they carry, not the subscription
/// type string, so a handful of them can't be derived mechanically (e.g. channel.charity_campaign.donate ->
/// charity_donation). Those are captured in <see cref="Overrides"/>; everything else is resolved against the
/// actual files in the Twitcher addon's generated_eventsub folder, which is the ground truth.
/// </summary>
public static class EventSubScriptNameResolver
{
    private static readonly Dictionary<string, string> Overrides = new()
    {
        ["channel.charity_campaign.donate"] = "charity_donation",
        ["channel.shared_chat.begin"] = "channel_shared_chat_session_begin",
        ["channel.shared_chat.update"] = "channel_shared_chat_session_update",
        ["channel.shared_chat.end"] = "channel_shared_chat_session_end",
        ["channel.shield_mode.begin"] = "shield_mode",
        ["channel.shield_mode.end"] = "shield_mode",
        ["channel.goal.begin"] = "goals",
        ["channel.goal.progress"] = "goals",
        ["channel.goal.end"] = "goals",
        ["user.whisper.message"] = "whisper_received",
        ["channel.shoutout.receive"] = "shoutout_received",
    };

    public static void Resolve(List<TwitchEventSubDefinitionInfo> definitions, string generatedEventSubDir)
    {
        foreach (var definition in definitions)
        {
            if (Overrides.TryGetValue(definition.Value, out var overrideName))
            {
                definition.ScriptName = overrideName;
                continue;
            }

            var defaultCandidate = definition.Value.Replace(".", "_");
            var dedupedCandidate = Regex.Replace(defaultCandidate, "^channel_channel_", "channel_");
            var strippedCandidate = defaultCandidate.StartsWith("channel_")
                ? defaultCandidate["channel_".Length..]
                : null;

            var resolved = new[] { defaultCandidate, dedupedCandidate, strippedCandidate }
                .Where(c => c != null)
                .Distinct()
                .FirstOrDefault(candidate => File.Exists(Path.Combine(generatedEventSubDir, $"twitch_es_{candidate}.gd")));

            if (resolved == null)
            {
                Console.WriteLine(
                    $"Warning: could not resolve a generated_eventsub script for '{definition.Value}' (tried: {defaultCandidate}, {dedupedCandidate}, {strippedCandidate}). Add an override in {nameof(EventSubScriptNameResolver)}.");
                resolved = defaultCandidate;
            }

            definition.ScriptName = resolved;
        }
    }
}
