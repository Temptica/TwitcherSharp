# Audit: non-null property initializers that short-circuit `field ??=` lazy getters

## Context

`TwitchChatMessage.Message.Fragments` always came back empty. The cause is the interaction
between two features added in separate commits:

- `551c51e` "Feat: implement lazy getters" converted DTO properties from eager population in
  `FromObject` to lazy `{ get => field ??= _data?.Get...(...); set; }` getters that read out of
  the stored `_data` Godot object on first access.
- The nullable-reference-types work kept/added a `= []` property initializer on that property.

`field ??= X` only evaluates `X` when the backing field is `null`. A non-null initializer such as
`= []` runs before any getter call, so `field` is never null, `??=` never fires, `_data` is never
consulted, and the property permanently returns the empty array it was initialized with. The
setter still works, which is why the mapping test passes.

The codebase already knows about this hazard — it is documented in
`TwitcherSharp.ClassGenerator/GenObjects/Api/TwitchGenField.cs:44-51`:

> `null!` tells the compiler to trust the factory method instead of forcing a real default
> (which would also break `field ??=` lazy-loading getters, since a non-null default like `[]`
> would short-circuit the `??=`).

That is exactly the rule that was violated. `= null!;` is the correct initializer: it silences
CS8618 for non-nullable properties populated by `FromObject` while leaving the backing field
`null` so `??=` still fires.

**Intended outcome:** every lazy getter in the repo actually reads `_data`, and the generator
cannot emit a new instance of this bug.

## Audit result

Swept all 425 `field ??=` lazy getters under `TwitcherSharp/`. Classification of property
initializers on lazy-getter properties:

| Initializer | Count | Status |
|---|---|---|
| `= null!;` | 185 | Safe — field stays null, `??=` fires |
| *(none)* | 239 | Safe — nullable properties, field starts null |
| `= [];` | **1** | **Broken** |

**There is exactly one occurrence of the runtime bug**, plus one latent generator defect that
would reintroduce it.

### 1. Confirmed bug — `TwitcherSharp/Chat/TwitchChatMessage.cs:154`

```csharp
public Fragment[] Fragments { get => field ??= _data?.GetArray<Fragment>("fragments") ?? []; set; } = [];
//                                                                                                  ^^^^^^ short-circuits the ??=
```

Hand-written file (not generated). `Fragments` is always `[]` unless explicitly assigned.

**Fix:** change the initializer `= [];` to `= null!;`. Keep the `?? []` fallback — it is a
different guard, covering `_data == null`, and `GodotObjectExtension.GetArray<T>`
(`TwitcherSharp/Extensions/GodotObjectExtension.cs:88`) already returns a non-null `T[]`, so the
fallback only fires when `_data` itself is null.

```csharp
public Fragment[] Fragments { get => field ??= _data?.GetArray<Fragment>("fragments") ?? []; set; } = null!;
```

This matches the convention used by the sibling non-nullable lazy properties in the same file
(`TwitchChatMessage.cs:19-23` `Content`, `:27-31` `Badges`), which use `= null!;`.

### 2. Latent generator defect — `TwitcherSharp.ClassGenerator/Generator/EventSub/EventSubCodeHelper.cs:76`

```csharp
$"public {fieldType}{(field.IsRequired ? "" : "?")} {field.Name} {{ get => field ??= _data?.Get{...}(\"{...}\"); set; }}{(field.IsRequired ? $"= {field.Name.ToCamelCase()};" : "")}",
//                                                                                                                      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ non-null primary-ctor arg on a lazy getter
```

For a field that is **both required and typed/array**, this emits a lazy getter initialized to a
primary-constructor parameter — the same short-circuit. Unlike the API generator, this branch does
not use the `DefaultInitializer` helper.

**Currently produces no broken output.** All 95 required-with-initializer properties in
`TwitcherSharp/EventSub/Generated/` are plain `string` condition fields (e.g.
`TwitchChannelChatMessageCondition.cs:18`) that take the non-lazy `else if (field.IsRequired)`
branch at line 80-81. No generated EventSub file currently combines `field ??=` with an
initializer. The defect only manifests when a required typed/array field first appears in the
Twitch EventSub schema — i.e. it is a regeneration time bomb, not a live bug.

**Fix:** in the typed/array branch, emit `= null!;` for required fields instead of the
constructor parameter, mirroring `TwitchGenField.DefaultInitializer`
(`TwitcherSharp.ClassGenerator/GenObjects/Api/TwitchGenField.cs:51`) and the API generator's usage
at `TwitcherSharp.ClassGenerator/Generator/Api/ApiCodeHelper.cs:237,256,262,271`. Consider adding
a `DefaultInitializer`-equivalent to the EventSub gen-field type so the rule lives in one place.

### 3. Test-coverage gap — `TwitcherSharp.GoDotTests/Tests/ManualMappingTest.cs:28`

```csharp
Content = new TwitchChatMessage.Message
{
    Fragments = [],   // assigns the property, so the lazy getter is never exercised
    Text = "Test Message"
},
```

The existing mapping test constructs `Message` via object initializer and sets `Fragments`
explicitly, so it exercises the setter and never the `_data` read path. This is why the bug
shipped undetected. A regression test should build the object through
`TwitchChatMessage.Message.FromObject(godotObject)` and assert `Fragments` is non-empty.

## Non-issues checked and cleared

- `= null!;` on 185 lazy getters — correct by design, `null` does not short-circuit `??=`.
- `TwitcherSharp/Chat/TwitchChatMessage.cs:278` `EmoteFormat[] Format { get; set; } = [];` —
  plain auto-property, no lazy getter, eagerly populated in `Emote.FromObject`. Fine.
- `TwitcherSharp/Chat/TwitchAutoMessage.cs:16` `AnnouncementColor` — has a `?? Primary` fallback
  but **no** property initializer, so `??=` fires. `TwitchAnnouncementColor` is a class
  (`TwitcherSharp/Chat/TwitchAnnouncementColor.cs:6`), not an enum. Fine.
- Other hand-written lazy getters (`TwitcherSharp/EventSub/TwitchEventListener.cs:13`,
  `TwitcherSharp/Chat/TwitchCommandInfo.cs:14,37,41`,
  `TwitcherSharp/Chat/TwitchAutoMessage.cs:24-25`) — no initializers. Fine.
- All `TwitcherSharp/Api/Generated/` and `TwitcherSharp/EventSub/Generated/` lazy getters — clean.
- Non-lazy `= [];` / `= "";` initializers elsewhere in the repo — plain collections and
  non-lazy DTO properties, unrelated to this bug class.

## Files to change

1. `TwitcherSharp/Chat/TwitchChatMessage.cs:154` — `= [];` → `= null!;`
2. `TwitcherSharp.ClassGenerator/Generator/EventSub/EventSubCodeHelper.cs:76` — emit `= null!;`
   instead of the camel-cased ctor parameter for required typed/array fields
3. `TwitcherSharp.GoDotTests/Tests/ManualMappingTest.cs` (or a new test) — add a `FromObject`
   round-trip test asserting `Fragments` populates from `_data`

## Verification

- `dotnet build TwitcherSharp/TwitcherSharp.csproj` — confirm no CS8618 reappears on `Fragments`
  after swapping the initializer (this is the warning `= null!` exists to suppress).
- Re-run the sweep; it must return zero rows:
  ```bash
  grep -rn "field ??=" --include=*.cs . | grep -E "\}\s*=" | grep -v "=\s*null!;\s*$"
  ```
- Run the ClassGenerator and confirm `git diff` on `TwitcherSharp/EventSub/Generated/` is empty
  (the generator fix must not alter today's output, since the broken branch is unreached).
- Run the GoDotTests mapping tests; the new `FromObject` test must fail before the
  `TwitchChatMessage.cs` fix and pass after.
- End-to-end: with a live chat connection, confirm `message.Content.Fragments` is non-empty —
  `TwitcherSharp.Demo/Scenes/WordGames/WordTemptation.cs:60` and
  `TwitcherSharp.Demo/Scenes/NumbersGame/Numbers404.cs:53` both gate on
  `Fragments.Length != 1` and are currently dead code because of this bug.
