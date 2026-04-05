using System.Diagnostics;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Channels;
using TwitcherSharp.GoDotTests.Helper;

namespace TwitcherSharp.GoDotTests.Tests;

public class ApiIntegrationTest(Main testScene) : TestClass(testScene)
{
    private readonly ILog _log = new Log(nameof(ApiIntegrationTest), new TraceWriter());
    private TwitchApi _twitchApi;
    
    [SetupAll]
    public void Setup()
    {
        _twitchApi = TwitchApi.GetOrCreateInstance();
    }

    [Test]
    public async Task TestGetChannelFollows()
    {
        var response = await _twitchApi.GetChannelFollowers(Main.UserId);
        Debug.Assert(response != null);
        Debug.Assert(response.Data != null);
        Debug.Assert(response.Data[0].UserName != null);
        _log.Print(response.Data[0].UserName);
        
    }
    
    [Test]
    public async Task TestApiIntegration()
    {
        var user = await TwitchService.Instance.GetCurrentUser();
        Debug.Assert(user != null);
    }

    [CleanupAll]
    public void Cleanup()
    {
        TwitchMockupHelper.Stop();
    }
}