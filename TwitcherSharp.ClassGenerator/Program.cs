using ClassGenerator.Generator.Api;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.Parsers;

var path = Environment.CurrentDirectory + "/../../../../TwitcherSharp/";
var apiPath = path + "Api/Generated/";
var eventSubPath = path + "EventSub/";
var eventSubGeneratedPath = eventSubPath + "Generated/";

// The Twitcher (GDScript) addon is expected to live as a sibling checkout of this repo, e.g.
// ~/Projects/TwitcherSharp and ~/Projects/twitcher.
var twitcherPath = Environment.CurrentDirectory + "/../../../../../twitcher/";
var generatedEventSubDir = twitcherPath + "addons/twitcher/generated_eventsub/";
var eventSubDefinitionGdPath = twitcherPath + "addons/twitcher/eventsub/twitch_eventsub_definition.gd";

//remove (sub) directories of they already exist, then create them
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
var eventSubGenerator = new TwitchEventSubGenerator();
eventSubGenerator.GenerateEventSub(eventSubGeneratedPath, eventSubParser);

var subscriptionTypeParser = new TwitchEventSubSubscriptionTypeParser();
await subscriptionTypeParser.ParseSubscriptionTypes(eventSubParser.ConditionComponents);
EventSubScriptNameResolver.Resolve(subscriptionTypeParser.Definitions, generatedEventSubDir);

var definitionGenerator = new TwitchEventSubDefinitionGenerator();
definitionGenerator.Generate(eventSubPath, subscriptionTypeParser.Definitions);

if (Directory.Exists(twitcherPath))
{
    var definitionGdGenerator = new TwitchEventSubDefinitionGdGenerator();
    definitionGdGenerator.Generate(eventSubDefinitionGdPath, subscriptionTypeParser.Definitions);
}
else
{
    Console.WriteLine(
        $"Warning: sibling Twitcher project not found at '{twitcherPath}', skipping GDScript definition generation.");
}
