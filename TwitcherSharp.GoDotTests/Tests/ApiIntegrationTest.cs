using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using Shouldly;
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
        // The TwitchAPI node of the test scene, wired to the mock's token handler.
        _twitchApi = TwitchApi.Required;
    }

    [Test]
    public async Task TestGetChannelFollows()
    {
        var response = await _twitchApi.GetChannelFollowers(Main.UserId);
        response.ShouldNotBeNull();
        response.Data.ShouldNotBeEmpty();
        response.Data[0].UserName.ShouldNotBeNull();
        _log.Print(response.Data[0].UserName);
        
    }
    
    [Test]
    public async Task TestApiIntegration()
    {
        var user = await TwitchService.Required.GetCurrentUser();
        user.ShouldNotBeNull();
    }

    [CleanupAll]
    public void Cleanup()
    {
        TwitchMockupHelper.Stop();
    }
}