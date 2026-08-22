using ClassGenerator.Generator.Api;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.Parsers;

var path = Environment.CurrentDirectory + "/../../../../TwitcherSharp/";
var apiPath = path + "Api/Generated/";
var eventSubPath = path + "EventSub/";
var eventSubGeneratedPath = eventSubPath + "Generated/";

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
TwitchEventSubGenerator.GenerateEventSub(eventSubGeneratedPath, eventSubParser);

var subscriptionTypeParser = new TwitchEventSubSubscriptionTypeParser();
await subscriptionTypeParser.ParseSubscriptionTypes(eventSubParser.ConditionComponents);
EventSubScriptNameResolver.Resolve(subscriptionTypeParser.Definitions);

TwitchEventSubDefinitionGenerator.Generate(eventSubPath, subscriptionTypeParser.Definitions);
