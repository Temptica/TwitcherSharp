#nullable enable
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Parsers;

/// <summary>
/// Mistakes of the EventSub reference tables that the parser cannot see, the same list as SCHEMA_CORRECTIONS of the
/// EventSub swagger generator (https://github.com/kanimaru/twitch-eventsub-swagger, generator.py) that twitcher is
/// generated from. Every correction there is checked against the payloads Twitch sends; keep both lists in sync.
/// </summary>
public static class EventSubCorrections
{
    private const string FragmentTypeDescription =
        "The type of message fragment. Possible values: text, emote, cheermote.";

    private abstract record Correction(string Component, string Path, string Evidence);

    private record Rename(string Component, string Path, string NewName, string Evidence)
        : Correction(Component, Path, Evidence);

    private record SetType(string Component, string Path, string Type, string Evidence)
        : Correction(Component, Path, Evidence);

    private record Add(string Component, string Path, string Type, string Description, string? After, string Evidence)
        : Correction(Component, Path, Evidence);

    private record SameAs(string Component, string Path, string Sibling, string Evidence)
        : Correction(Component, Path, Evidence);

    /// <summary>
    /// Component class names without the Twitch prefix; a path walks fields by their JSON name with ".".
    /// </summary>
    private static readonly Correction[] Corrections =
    [
        new Rename("ChannelUnbanRequestResolveEvent", "moderator_id", "moderator_user_id", "docs example and Twitch CLI"),
        new Rename("ChannelUnbanRequestResolveEvent", "moderator_login", "moderator_user_login",
            "docs example and Twitch CLI"),
        new Rename("ChannelUnbanRequestResolveEvent", "moderator_name", "moderator_user_name",
            "docs example and Twitch CLI"),
        new Add("ChannelChatNotificationEvent", "chatter_user_login", "string", "The chatter's login name.",
            "chatter_user_name", "both docs examples"),
        new SetType("ChannelChatNotificationEvent", "message.text", "string", "both docs examples"),
        new SameAs("ChannelChatNotificationEvent", "shared_chat_unraid", "unraid", "shared chat docs example"),
        new SameAs("ChannelChatNotificationEvent", "shared_chat_bits_badge_tier", "bits_badge_tier",
            "shared chat docs example"),
        new SameAs("ChannelChatNotificationEvent", "shared_chat_charity_donation", "charity_donation",
            "shared chat docs example"),
        new Add("ChannelChatUserMessageHoldEvent", "message.fragments.type", "string", FragmentTypeDescription, null,
            "docs example"),
        new Add("ChannelChatUserMessageUpdateEvent", "message.fragments.type", "string", FragmentTypeDescription, null,
            "docs example"),
        new SetType("ChannelSuspiciousUserMessageEvent", "message.fragments.cheermote.bits", "integer",
            "docs example; the cheermote of every other message fragment"),
        new SetType("ChannelSuspiciousUserMessageEvent", "message.fragments.cheermote.tier", "integer",
            "docs example; the cheermote of every other message fragment"),
        ..new[] { "ChannelGuestStarSessionBeginEvent", "ChannelGuestStarSessionEndEvent" }.SelectMany(component =>
            new Correction[]
            {
                new Add(component, "moderator_user_id", "string",
                    "The user ID of the moderator who started or ended the session.", "broadcaster_user_login",
                    "docs example"),
                new Add(component, "moderator_user_name", "string", "The display name of the moderator.",
                    "moderator_user_id", "docs example"),
                new Add(component, "moderator_user_login", "string", "The login of the moderator.",
                    "moderator_user_name", "docs example"),
            }),
    ];

    /// <summary>
    /// Applies the corrections to the parsed events. A correction the docs no longer need is reported; one whose
    /// field is gone, or that would change a component other events share, throws.
    /// </summary>
    public static void Apply(IEnumerable<TwitchEventSubGenComponent> components)
    {
        var byName = components.ToDictionary(c => c.ClassName);
        foreach (var correction in Corrections)
        {
            var component = byName.GetValueOrDefault("Twitch" + correction.Component)
                            ?? throw new InvalidOperationException($"No event {correction.Component} to correct");
            var names = correction.Path.Split('.');
            foreach (var name in names[..^1])
            {
                component = FindField(component, name)?.TypedComponent
                            ?? throw new InvalidOperationException(
                                $"{correction.Component}.{correction.Path}: {name} is not an object");
                if (component.IsShared)
                {
                    throw new InvalidOperationException(
                        $"{correction.Component}.{correction.Path}: {component.ClassName} is shared by other events");
                }
            }

            var fieldName = names[^1];
            var field = FindField(component, fieldName);
            switch (correction)
            {
                case Rename rename when field == null && FindField(component, rename.NewName) != null:
                case Add or SameAs when field != null:
                    NoLongerNeeded(correction);
                    break;
                case Rename rename:
                    Replace(component, Required(field, correction),
                        new TwitchEventSubGenField(rename.NewName, field!.Description, field.Type, field.IsRequired));
                    break;
                case SetType setType:
                    var typed = new TwitchEventSubGenField(fieldName, Required(field, correction).Description,
                        setType.Type, field!.IsRequired);
                    if (typed.Type == field.Type) NoLongerNeeded(correction);
                    else Replace(component, field, typed);
                    break;
                case Add add:
                    Insert(component, new TwitchEventSubGenField(fieldName, add.Description, add.Type), add.After);
                    break;
                case SameAs sameAs:
                    var sibling = FindField(component, sameAs.Sibling)
                                  ?? throw new InvalidOperationException(
                                      $"{correction.Component}.{correction.Path}: no {sameAs.Sibling} to copy");
                    Rebuild(component, [..component.Fields.Values, new TwitchEventSubGenField(fieldName,
                        $"This field has the same information as the {sameAs.Sibling} field but for a notification " +
                        "that happened in a channel in the shared chat session.", sibling.Type)
                    {
                        IsArray = sibling.IsArray,
                        TypedComponent = sibling.TypedComponent,
                    }]);
                    break;
            }
        }
    }

    private static TwitchEventSubGenField? FindField(TwitchEventSubGenComponent component, string jsonName) =>
        component.Fields.Values.FirstOrDefault(f => f.RawName == jsonName)
        // Fields made from an object row carry the PascalCase class name, not the JSON key.
        ?? component.Fields.GetValueOrDefault(jsonName.ToPascalCase());

    private static TwitchEventSubGenField Required(TwitchEventSubGenField? field, Correction correction) =>
        field ?? throw new InvalidOperationException($"{correction.Component}.{correction.Path} does not exist");

    private static void NoLongerNeeded(Correction correction) =>
        Console.WriteLine($"  correction no longer needed: {correction.Component}.{correction.Path} " +
                          $"({correction.Evidence})");

    /// <summary>Replaces a field in place, keeping the order of the fields.</summary>
    private static void Replace(TwitchEventSubGenComponent component, TwitchEventSubGenField old,
        TwitchEventSubGenField replacement) =>
        Rebuild(component, component.Fields.Values.Select(f => f == old ? replacement : f).ToList());

    /// <summary>
    /// Inserts a field after <paramref name="after"/> (JSON name): first when it is null, last when it is missing.
    /// </summary>
    private static void Insert(TwitchEventSubGenComponent component, TwitchEventSubGenField field, string? after)
    {
        var fields = component.Fields.Values.ToList();
        var index = after == null ? 0 : fields.FindIndex(f => f.RawName == after) + 1;
        fields.Insert(after != null && index == 0 ? fields.Count : index, field);
        Rebuild(component, fields);
    }

    private static void Rebuild(TwitchEventSubGenComponent component, List<TwitchEventSubGenField> fields)
    {
        component.Fields.Clear();
        foreach (var field in fields) component.Fields[field.Name] = field;
    }
}
