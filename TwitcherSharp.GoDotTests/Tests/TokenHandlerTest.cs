using System;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Auth;
using TwitcherSharp.GoDotTests.Helper;
using TwitcherSharp.Lib.OOuch;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// What a consumer needs from a token handler to authorize its own requests: the access token, a refresh and the
/// OAuth client id. The fake (Fixtures/coroutine_fakes.gd) holds an expired token whose refresh awaits a frame.
/// </summary>
public class TokenHandlerTest(Node testScene) : TestClass(testScene)
{
    private const string FakesPath = "res://Tests/Fixtures/coroutine_fakes.gd";

    [Test]
    public async Task GetAccessTokenAwaitsTheRefresh()
    {
        await WithFakeHandler(async node =>
        {
            var handler = TwitchTokenHandler.FromObject(node)!;

            (await handler.GetAccessToken()).ShouldBe("refreshed-token");
        });
    }

    [Test]
    public async Task RefreshTokensAwaitsTheRefresh()
    {
        await WithFakeHandler(async node =>
        {
            var handler = TwitchTokenHandler.FromObject(node)!;

            await handler.RefreshTokens();

            node.HasMeta("refreshed").ShouldBeTrue();
            (await handler.GetAccessToken()).ShouldBe("refreshed-token");
        });
    }

    [Test]
    public async Task ClientIdIsTheOAuthSettingsClientId()
    {
        await WithFakeHandler(node =>
        {
            TwitchTokenHandler.FromObject(node)!.ClientId.ShouldBe("fake-client-id");

            node.Set("oauth_setting", default);
            TwitchTokenHandler.FromObject(node)!.ClientId.ShouldBe("");
            return Task.CompletedTask;
        });
    }

    [Test]
    public async Task SceneHandlerHandsOutTheMockToken()
    {
        var node = ((Main)TestScene).TokenHandler;
        var handler = TwitchTokenHandler.FromObject(node)!;

        string stored;
        using (var tokenValue = node.Get("token"))
        using (var token = tokenValue.AsGodotObject())
        using (var accessToken = token.Call("get_access_token"))
        {
            stored = accessToken.AsString();
        }

        stored.ShouldNotBeNullOrEmpty();
        (await handler.GetAccessToken()).ShouldBe(stored);
        handler.ClientId.ShouldBe(TwitchMockupHelper.ClientId);
    }

    [Test]
    public void OAuthTokenHandlerHasTheClientId()
    {
        // BotV3's database autoloads own a plain OAuthTokenHandler, not a TwitchTokenHandler.
        var handler = ((Main)TestScene).OAuthToken;

        handler.ClientId.ShouldBe(TwitchMockupHelper.ClientId);
    }

    private static async Task WithFakeHandler(Func<Node, Task> test)
    {
        Node node;
        using (var fakes = GD.Load<GDScript>(FakesPath))
        using (var fakeClass = fakes.Get("FakeTokenHandler"))
        using (var fakeScript = fakeClass.AsGodotObject())
        using (var instance = fakeScript.Call("new"))
        {
            node = (Node)instance.AsGodotObject();
        }

        try
        {
            await test(node);
        }
        finally
        {
            node.Free();
        }
    }
}
