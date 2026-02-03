
using ClassGenerator.ApiParser;
using ClassGenerator.Generator;

var path = Environment.CurrentDirectory + "/../../../../TwitcherSharp/Generated/";
Directory.CreateDirectory(path);

var apiParser = new TwitchApiParser();
await apiParser.ParseApi();
var generator = new TwitchApiGenerator();
generator.GenerateApi(path, apiParser);
