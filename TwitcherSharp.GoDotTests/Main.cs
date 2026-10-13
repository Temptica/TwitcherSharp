using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Godot;
using TwitcherSharp.GoDotTests.Helper;
using TwitcherSharp.Lib.OOuch;

namespace TwitcherSharp.GoDotTests;

public partial class Main : Node3D
{
    [Export]
    public Node TokenHandler
    {
        get;
        set
        {
            OAuthToken = OAuthTokenHandler.FromObject(value);
            field = value;
        }
    }

    public OAuthTokenHandler OAuthToken { get; set; }

    [Export] private Resource TwitchOAuthScopes { get; set; }

    public static string UserId => TwitchMockupHelper.UserId;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TokenHandler ??= GetChild(0).GetChild(0).GetChild(2).GetChild(1);
        GoTest.TimeoutMilliseconds = -1;
       _ = StartTest();
    }

    private async Task StartTest()
    {
        // Without command line flags (e.g. started from the editor) every test runs, as before.
        var environment = TestEnvironment.From(OS.GetCmdlineArgs());
        if (!environment.ShouldRunTests) environment = TestEnvironment.From(["--run-tests"]);

        // GoDotTest only reports what ran; print what exists so a run that ends early is visible.
        GD.Print($"Discovered tests: {CountTests(environment.TestPatternToRun)}");

        var response = await TwitchMockupHelper.AwaitForStart();
        using (var oauthSetting = GetNode("Twitcher/TwitchService/TwitchAPI").Get("oauth_setting"))
        {
            oauthSetting.AsGodotObject().Set("client_id", TwitchMockupHelper.ClientId);
        }

        OAuthToken.UpdateTokens(response.AccessToken, response.RefreshToken, response.ExpiresIn, response.Scope, response.TokenType);

        await GoTest.RunTests(Assembly.GetExecutingAssembly(), this, environment);
        TwitchMockupHelper.Stop();
    }

    /// <summary>
    /// Counts the [Test] methods GoDotTest would run for the given pattern (a suite name, or Suite.Method).
    /// </summary>
    private static int CountTests(string? pattern)
    {
        var suites = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsSubclassOf(typeof(TestClass)) && !type.IsAbstract);
        var parts = pattern?.Split('.', 2);

        return suites
            .Where(suite => parts is null || suite.Name.Equals(parts[0], StringComparison.Ordinal))
            .SelectMany(suite => suite.GetMethods())
            .Where(method => method.GetCustomAttribute<TestAttribute>() is not null)
            .Count(method => parts is not { Length: 2 } || method.Name.Equals(parts[1], StringComparison.Ordinal));
    }
}
