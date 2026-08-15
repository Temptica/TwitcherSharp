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
    
    public const string UserId = "5539307";
 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        TokenHandler ??= GetChild(0).GetChild(0).GetChild(2).GetChild(1);
        TwitchService.CreateInstance();
        GoTest.TimeoutMilliseconds = -1;
       _ = StartTest();
    }

    private async Task StartTest()
    {
        var usedScopes = TwitchOAuthScopes.Get("used_scopes");
        var scopes = usedScopes.AsStringArray();

        var response = await TwitchMockupHelper.AwaitForStart(scopes);

        OAuthToken.UpdateTokens(response.AccessToken, response.RefreshToken, response.ExpiresIn, response.Scope, response.TokenType);

        await GoTest.RunTests(Assembly.GetExecutingAssembly(), this);
    }
}