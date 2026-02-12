
using ClassGenerator.ApiParser;
using ClassGenerator.Generator;
using ClassGenerator.Generator.Api;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.Parsers;

var path = Environment.CurrentDirectory + "/../../../../TwitcherSharp/";
var apiPath = path + "Api/Generated/";
var eventSubPath = path + "EventSub/Generated/";
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
