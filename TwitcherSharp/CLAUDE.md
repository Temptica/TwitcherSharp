# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository layout

This directory (`TwitcherSharp/`) is one project inside a larger solution rooted one level up
(`../TwitcherSharp.sln`). The solution has four projects:

- `TwitcherSharp/` (this directory) — the library itself, published to NuGet as `Temptica.TwitcherSharp`.
- `TwitcherSharp.ClassGenerator/` — a standalone console tool that scrapes the Twitch API/EventSub docs and
  regenerates the code under `Api/Generated/` and `EventSub/Generated/` in this project.
- `TwitcherSharp.GoDotTests/` — the test suite. It runs *inside* the Godot engine (not `dotnet test`), using
  Chickensoft GoDotTest, and requires a live Twitch OAuth device-code flow against a real/mock Twitch account.
- `TwitcherSharp.Demo/` — a Godot demo project (with the actual `twitcher` GDScript addon installed under
  `addons/twitcher/`) used to exercise the library manually in-engine.

TwitcherSharp is a C# wrapper around **Twitcher**, a GDScript Twitch-integration addon for Godot
(`res://addons/twitcher/`). It does not talk to Twitch directly for most calls — it forwards calls into the
GDScript addon's `GodotObject`s and translates results back into typed C# objects. A consuming project must have
the `twitcher` addon installed for this library to function at runtime.

## Build

From the solution root (one directory up):

```bash
dotnet build TwitcherSharp.sln
```

Or just this project:

```bash
dotnet build TwitcherSharp/TwitcherSharp.csproj
```

Building requires the Godot 4.6 C# SDK/source generators (`GodotSharp`, `GodotSharpEditor`,
`Godot.SourceGenerators`), pulled in via NuGet — no local Godot install is needed just to build the library.

## Tests

There is no `dotnet test` entry point. Tests live in `TwitcherSharp.GoDotTests` and only run inside the Godot
editor/runtime (`Main.cs` boots `TwitchService`, drives a Twitch OAuth device-code mock flow via
`TwitchMockupHelper`, then runs `GoTest.RunTests`). To run them you need Godot 4.6 with the .NET/Mono build,
open `TwitcherSharp.GoDotTests` (or the solution) in the editor, and run the `Main` scene.

## Regenerating the Twitch API surface

`Api/Generated/` and `EventSub/Generated/` are entirely generator output — never hand-edit files under these
directories; edit `TwitcherSharp.ClassGenerator` and re-run it instead:

```bash
dotnet run --project ../TwitcherSharp.ClassGenerator
```

This parses the current Twitch API/EventSub docs, then deletes and regenerates both `Api/Generated/` and
`EventSub/Generated/` in place under this project.

## Architecture

### The GodotObject-wrapping pattern

Almost every public type wraps an underlying GDScript `GodotObject` (`_data`) rather than reimplementing logic
in C#. The core contract lives in `Interfaces/`:

- `ITwitcherSharp` / `ITwitcherSharp<TSelf>` — base contract: `ToGodotObject()` converts a C# instance to its
  backing GDScript object, and the static abstract `FromObject(GodotObject)` reconstructs a C# instance from one.
- `ITwitcherSharpSingleton<TSelf>` — for singleton services (e.g. `TwitchService`): exposes a static `Instance`
  that lazily discovers or creates the GDScript node, and `CreateInstance()` which instantiates the GDScript
  node and adds it to the scene root.
- `ITwitcherSharpCondition<TSelf>` — for EventSub subscription conditions, convertible to/from a
  `Godot.Collections.Dictionary`.
- `ITwitcherSharpEventSub<TSelf>` — marker interface for EventSub payload types.

Method calls are proxied to the GDScript side via extension methods on `GodotObject`
(`Extensions/GodotObjectExtension.cs`): `Call<T>`, `CallAsync`, `CallAsync<T>`, `CallList[Async]`,
`CallDictionaryKey[Async]`, `CallDictionaryValue[Async]`. These call the GDScript method by its **snake_case**
name and convert the `Variant` result back into a typed `ITwitcherSharp<T>` instance (or a Godot collection of
them). Async variants detect whether the GDScript call returned an object with a `"completed"` signal (a
GDScript `Signal`-based awaitable) and `await` it via `ToSignal` before returning.

Godot signals from the addon are bridged to strongly-typed C# events/callbacks via
`Extensions/CallableExtension.cs` (`Callable.FromTwitcherSharp<T>`) and the `Connect*` helpers in
`GodotObjectExtension` (e.g. `ConnectRedeemed`, `ConnectCommandReceived`, `ConnectCooldown`).

When adding a new wrapper type, follow the existing pattern in a sibling class: back it with a private
`GodotObject _data`, implement `FromObject`/`ToGodotObject`, and expose behavior through the `Call*` extension
helpers rather than reimplementing logic.

### Directory breakdown

- `TwitchService.cs` — the main singleton entry point (`TwitchService.Instance` /
  `TwitchService.CreateInstance()`). Setup/auth bootstrapping, user lookup, chat/announcements/whispers, reward
  save/delete, emotes/badges/cheermotes, polls, and EventSub subscription registration all funnel through here.
- `Api/Generated/` — generated request/response/model types for the Twitch Helix API, organized into
  subfolders by API category (Ads, Analytics, Bits, ChannelPoints, Chat, Users, etc.). Do not hand-edit.
- `EventSub/` — EventSub subscription plumbing (`TwitchEventSub`, `TwitchEventSubConfig`,
  `TwitchEventListener<T>`, subscription definitions/types); `EventSub/Generated/` holds generated per-event
  payload types. Do not hand-edit the `Generated` subfolder.
- `Auth/` — OAuth scopes and token handling on the TwitcherSharp side (`TwitchAuth`, `TwitchTokenHandler`,
  `TwitchScopes`).
- `Chat/` — chat commands (`TwitchCommand` and permission/cooldown/where-flag configuration), bots, auto
  messages, chat message types, announcement colors.
- `Reward/` — channel-points custom reward CRUD and redemption listening (`TwitchRewardService`,
  `TwitchRedeemListener`).
- `Poll/` — poll listener wrapper.
- `Media/` — emote/badge/cheermote definitions and `TwitchMediaLoader`/`TwitchImageTransformer` for turning
  Twitch media into Godot `SpriteFrames`/textures.
- `Interfaces/` — the `ITwitcherSharp*` contracts described above; read this first when adding a new wrapper type.
- `Extensions/` — the `GodotObject`/`Callable`/`Variant`/`Node`/`IEnumerable` extension methods that make the
  wrapper pattern ergonomic; this is where most of the "glue" logic lives.
- `Lib/Http/` — plain request/response DTOs used for HTTP calls made from C# (outside the GDScript bridge).
- `Lib/OOuch/` — OAuth device-code flow types (`OAuthToken`, `OAuthDeviceCodeResponse`, `OAuthTokenHandler`)
  used by the test harness and by consumers implementing their own auth UI.

### Naming convention note

GDScript-side method/signal names are snake_case strings passed as literals to `Call`/`CallAsync`/`Connect`
(e.g. `"get_user_by_id"`, `"redeemed"`). When wrapping a new GDScript method, match the exact snake_case name
used in the `twitcher` addon.
