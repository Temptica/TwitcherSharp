using System.Runtime.CompilerServices;
using ClassGenerator.Generator.Api;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.Parsers;

// Resolved relative to this source file (not the process's current directory) so generation
// always targets the sibling TwitcherSharp/ project of the checkout it was compiled from,
// regardless of where `dotnet run` is invoked from (IDE, CLI, or a git worktree).
string ThisFilePath([CallerFilePath] string file = "") => file;
var projectDir = Path.GetDirectoryName(ThisFilePath())!;
var path = Path.Combine(projectDir, "..", "TwitcherSharp") + Path.DirectorySeparatorChar;
var apiPath = path + "Api/Generated/";
var eventSubPath = path + "EventSub/";
var eventSubGeneratedPath = eventSubPath + "Generated/";

//remove (sub) directories if they already exist, then create them
if (Directory.Exists(apiPath)) Directory.Delete(apiPath, true);
if (Directory.Exists(eventSubGeneratedPath)) Directory.Delete(eventSubGeneratedPath, true);

Directory.CreateDirectory(apiPath);
Directory.CreateDirectory(eventSubGeneratedPath);

var apiParser = new TwitchApiParser();
await apiParser.ParseApi();
var apiGenerator = new TwitchApiGenerator();
apiGenerator.GenerateApi(apiPath, apiParser);

var eventSubParser = new TwitchEventSubParser();
await eventSubParser.ParseEventSub();
TwitchEventSubGenerator.GenerateEventSub(eventSubGeneratedPath, eventSubParser);

var subscriptionTypeParser = new TwitchEventSubSubscriptionTypeParser();
await subscriptionTypeParser.ParseSubscriptionTypes(eventSubParser.ConditionComponents);
EventSubScriptNameResolver.Resolve(subscriptionTypeParser.Definitions);

TwitchEventSubDefinitionGenerator.Generate(eventSubPath, subscriptionTypeParser.Definitions);
