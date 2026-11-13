using System.Runtime.CompilerServices;
using ClassGenerator.Generator.Api;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.Docs;
using ClassGenerator.Parsers;
using ClassGenerator.Parsers.Helix;
using ClassGenerator.Parsers.EventSub;

// Resolved relative to this source file (not the process's current directory) so generation
// always targets the sibling TwitcherSharp/ project of the checkout it was compiled from,
// regardless of where `dotnet run` is invoked from (IDE, CLI, or a git worktree).
string ThisFilePath([CallerFilePath] string file = "") => file;
var projectDir = Path.GetDirectoryName(ThisFilePath())!;
var path = Path.Combine(projectDir, "..", "TwitcherSharp") + Path.DirectorySeparatorChar;
var apiPath = path + "Api/Generated/";
var eventSubPath = path + "EventSub/";
var eventSubGeneratedPath = eventSubPath + "Generated/";
var snapshotPath = Path.Combine(projectDir, "Snapshots");
var offline = args.Contains("--offline");

//remove (sub) directories if they already exist, then create them
if (Directory.Exists(apiPath)) Directory.Delete(apiPath, true);
if (Directory.Exists(eventSubGeneratedPath)) Directory.Delete(eventSubGeneratedPath, true);

Directory.CreateDirectory(apiPath);
Directory.CreateDirectory(eventSubGeneratedPath);

var helixReference = await new TwitchDocsSource(Path.Combine(snapshotPath, "Api"), offline)
    .LoadAsync("https://dev.twitch.tv/docs/api/reference.md");
var helixEndpoints = HelixReferenceParser.Parse(helixReference);
HelixCorrections.Apply(helixEndpoints);
var helixDocument = HelixOpenApiBuilder.Build(helixEndpoints);

var apiParser = new TwitchApiParser();
apiParser.ParseApi(helixDocument);
var apiGenerator = new TwitchApiGenerator();
apiGenerator.GenerateApi(apiPath, apiParser);

var eventSubReference = await new TwitchDocsSource(Path.Combine(snapshotPath, "EventSub"), offline)
    .LoadAsync("https://dev.twitch.tv/docs/eventsub/reference.md");

var eventSubParser = new TwitchEventSubParser();
eventSubParser.Parse(EventSubReferenceParser.Parse(eventSubReference));
TwitchEventSubGenerator.GenerateEventSub(eventSubGeneratedPath, eventSubParser);
EventSubScriptNameResolver.Resolve(eventSubParser.Definitions);

var gdDefinitionScript = Path.Combine(projectDir, "..", "TwitcherSharp.Demo", "addons", "twitcher", "eventsub",
    "twitch_eventsub_definition.gd");
TwitchEventSubDefinitionGenerator.Generate(eventSubPath, eventSubParser.Definitions, gdDefinitionScript);
