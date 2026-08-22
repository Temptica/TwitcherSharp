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
var eventSubPath = path + "EventSub/Generated/";

//remove (sub) directories of they already exist, then create them
if (Directory.Exists(apiPath)) Directory.Delete(apiPath, true);
if (Directory.Exists(eventSubPath)) Directory.Delete(eventSubPath, true);

Directory.CreateDirectory(apiPath);
Directory.CreateDirectory(eventSubPath);

var apiParser = new TwitchApiParser();
await apiParser.ParseApi();
var apiGenerator = new TwitchApiGenerator();
apiGenerator.GenerateApi(apiPath, apiParser);

var eventSubParser = new TwitchEventSubParser();
await eventSubParser.ParseEventSub();
var eventSubGenerator = new TwitchEventSubGenerator();
eventSubGenerator.GenerateEventSub(eventSubPath, eventSubParser);
