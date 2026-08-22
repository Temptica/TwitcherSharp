# TwitcherSharp

A .NET wrapper for [Twitcher](https://github.com/kanimaru/twitcher), the Twitch integration addon for Godot.

> **Still under development.** About 95% of the mapping is done, but the wrapper needs more testing. Feel free to try it out and [report any issues](https://github.com/Temptica/TwitcherSharp/issues).

## What is it?

TwitcherSharp is a C# wrapper around the Godot Twitcher addon made by kanimaru. It makes it easier to use Twitcher from C# projects. It does not replace Twitcher — you can keep using GDScript and C# side by side in the same project.

## Requirements

- [Godot 4.7+](https://godotengine.org/) with C# support (.NET build)
- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- The [Twitcher](https://github.com/kanimaru/twitcher) addon, installed and configured (see below)

## Installation

1. **Install Twitcher first.** Add the addon from the [Godot Asset Library](https://godotengine.org/asset-library/) or download it directly from [GitHub](https://github.com/kanimaru/twitcher).
   - Twitcher must be located at `res://addons/twitcher/`. This is its default install location, so you shouldn't need to move anything.
   - Follow Twitcher's own [Getting Started](https://twitcher.kani.dev/introduction/getting-started.html) guide to set up your Twitch application, tokens, etc. TwitcherSharp assumes this step is already done.

2. **Add the TwitcherSharp NuGet package** to your Godot C# project:

   ```bash
   dotnet add package Temptica.TwitcherSharp
   ```

   Or add it directly in your `.csproj`:

   ```xml
   <ItemGroup>
     <PackageReference Include="Temptica.TwitcherSharp" Version="2.5.2" />
   </ItemGroup>
   ```

   **Match the major/minor version to your installed Twitcher version.** TwitcherSharp's mapping is generated against a specific Twitcher release, and mismatched versions may not line up correctly.

3. Build the project once (`dotnet build`, or build from the Godot editor) so the C# bindings are picked up.

## Usage

### 1. Set up the TwitcherService node

You need a `TwitcherService` node in your scene, created one of two ways:

- **Manual:** add a `TwitcherService` node into your scene at whatever location you'd like.
- **Automatic:** let TwitcherSharp create it for you at the root of the scene at runtime, via `CreateInstance()` (see below).

### 2. Initialize it from a script

Add a script to a node that runs its `_Ready()` (or equivalent) *after* the other Twitcher nodes have initialized — typically a parent node higher up the scene tree. In that script, call:

```csharp
await TwitchService.Instance.Setup();
```

- `Instance` is a static property available on TwitcherSharp's singleton classes. It returns the existing instance if one exists; otherwise it looks for a matching GDScript node in the scene and wraps it, caching the C# instance on that node's metadata so it's cleaned up automatically when the scene is unloaded.
- If you'd rather create the node yourself, call `CreateInstance()`. This creates the GDScript `TwitcherService` node, adds it to the scene root, and returns a connected C# `TwitcherSharp` instance.

That's it — once `Setup()` completes, you can use the wrapped Twitcher API from C#.

### 3. Calling the Twitch API

Raw REST calls go through `TwitchApi`, which mirrors the [Twitch API reference](https://dev.twitch.tv/docs/api/reference/) one method per endpoint. Get the singleton the same way as `TwitchService`:

```csharp
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Streams;

var api = TwitchApi.Instance ?? TwitchApi.CreateInstance();

var result = await api.GetStreams(new TwitchGetStreamsOpt { UserLogin = ["some_channel"] });
var stream = result.Data.FirstOrDefault();
```

Most calls take an `Opt`/`Body` request object and return a typed `...Response` with a `Data` array — e.g. `GetUsers(TwitchGetUsersOpt)` → `TwitchGetUsersResponse`, `GetAdSchedule(broadcasterId)` → `TwitchGetAdScheduleResponse`. You'll usually already have an instance available through `TwitchService`/`TwitchChat`/`TwitchBot` rather than creating your own.

### 4. Subscribing to EventSub events

There are three ways to subscribe to a Twitch EventSub event (e.g. follows, subs, chat messages, ad breaks), from most to least convenient.

**A. `TwitchEventListener<T>` (recommended)** — a typed wrapper that gives you a strongly-typed `Received` event per subscription. You can either:

- Place a `TwitchEventListener` node in the scene (in the Godot editor) with its `Subscription Definition` set in the inspector, then bind it in code:

  ```csharp
  using TwitcherSharp.EventSub;
  using TwitcherSharp.EventSub.Generated.ChannelAdBreakBegin;

  var listener = TwitchEventListener<TwitchChannelAdBreakBeginEvent>.FromObject(GetNode("AdsStartedEventListener"));
  listener.Received += e => GD.Print($"Ad break starting, duration {e.DurationSeconds}s");
  ```

- Or create and configure it entirely from code:

  ```csharp
  using TwitcherSharp.EventSub;
  using TwitcherSharp.EventSub.Generated.ChannelSubscribe;

  var listener = new TwitchEventListener<TwitchChannelSubscribeEvent>
  {
      SubscriptionDefinition = TwitchEventSubDefinition.ChannelSubscribe
  };
  AddChild(listener.ToGodotObject() as Node);
  listener.Received += e => GD.Print($"{e.UserName} subscribed!");
  ```

**B. Via `TwitchService`** — lower-level, useful when you need to build the condition dictionary yourself (e.g. dynamic broadcaster/moderator IDs):

```csharp
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelFollow;

var condition = new TwitchChannelFollowCondition(broadcasterId, moderatorId);
TwitchEventSubConfig config = TwitchService.Instance.SubscribeEvent(TwitchEventSubDefinition.ChannelFollow, condition);
```

**C. Via `TwitchEventSub` directly** — the lowest level; build the `TwitchEventSubConfig` yourself and hand it to the EventSub singleton:

```csharp
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelFollow;

var config = new TwitchEventSubConfig(TwitchEventSubDefinition.ChannelFollow,
    [new TwitchChannelFollowCondition(broadcasterId, moderatorId)]);

TwitchEventSub.Instance.Subscribe(config);
```

Each subscription type (`ChannelFollow`, `ChannelSubscribe`, `ChannelChatMessage`, `ChannelAdBreakBegin`, ...) has a matching `Twitch*Condition` and `Twitch*Event` class generated under `EventSub/Generated/`. `TwitchEventSubDefinition` lists every available type — check `Definition.Conditions` / `Definition.Scopes` to see what a subscription needs.

### 5. Chat and bot messages

For simple chat interaction you don't need `TwitchChat` directly — `TwitchService` exposes chat helpers once `Setup()` has run:

```csharp
TwitchService.Instance.Chat("Hello chat!");
TwitchService.Instance.Shoutout(someUser);
TwitchService.Instance.Announcement("Announcement text");
```

**Sending as a bot account** (a second Twitch account with its own OAuth token) goes through `TwitchBot`, which needs a `TwitchBot` node set up per Twitcher's docs with a `Sender`/`Receiver` configured:

```csharp
using TwitcherSharp.Chat;

await TwitchBot.SendMessage("Hi from the bot!");
await TwitchBot.SendLongMessage(longText); // auto-splits into 500-char chunks
await TwitchBot.Announcement("Announcement", TwitchAnnouncementColor.Primary);
await TwitchBot.Shoutout(fromUser, targetUser);
```

**Chat commands** are registered through `TwitchService.AddCommand`, either inline or by constructing a `TwitchCommand`:

```csharp
using TwitcherSharp.Chat;

var command = new TwitchCommand
{
    Command = "so",
    ArgsMin = 1,
    ArgsMax = 1,
    PermissionLevel = TwitchCommandBase.PermissionFlag.ModStreamer,
};

TwitchService.Instance.AddCommand(command).CommandReceived += (fromUsername, info, args) =>
{
    // args[0] is the first argument after !so
    _ = TwitchBot.SendMessage($"Shoutout to {args[0]}!", info.ChatMessage.MessageId);
};
```

`TwitchCommandBase.PermissionFlag` (`Everyone`, `Vip`, `Sub`, `Mod`, `Streamer`, `ModStreamer`, ...) controls who can run it; `CommandReceived`/`ReceivedInvalidCommand`/`InvalidPermission`/`Cooldown` are the events you can subscribe to on the returned `TwitchCommand`.

## Best practices

### Getting and binding nodes

All TwitcherSharp classes implement `RefCounted`, so they can be bound to a `Node`'s metadata:

```csharp
node.SetTwitcherSharp(myTwitcherSharpObject);       // bind
var obj = node.GetTwitcherSharp<T>();               // retrieve (T : ITwitcherSharp)
node.RemoveTwitcherSharp();                          // unbind
```

## Example project

A working example lives in [`TwitcherSharp.Demo`](TwitcherSharp.Demo) — a Godot project that references TwitcherSharp directly via `ProjectReference`. Open it in Godot to see the wrapper wired up end to end.

## License

[MIT](LICENSE)
