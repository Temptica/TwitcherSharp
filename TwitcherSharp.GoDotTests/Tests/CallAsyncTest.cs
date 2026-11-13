using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// GodotObjectExtension.CallAsync against every kind of result (Fixtures/call_async_fixture.gd).
/// </summary>
public class CallAsyncTest(Node testScene) : TestClass(testScene)
{
    private const string FixturePath = "res://Tests/Fixtures/call_async_fixture.gd";

    private GDScript _script = null!;
    private GodotObject _fixture = null!;

    [Setup]
    public void Setup()
    {
        _script = GD.Load<GDScript>(FixturePath);
        _fixture = _script.New().AsGodotObject();
    }

    [Cleanup]
    public void Cleanup()
    {
        _fixture.Dispose();
        _script.Dispose();
    }

    [Test]
    public async Task PlainReturn()
    {
        using var result = await _fixture.CallAsync("plain");

        result.AsInt32().ShouldBe(42);
    }

    [Test]
    public async Task NullObjectReturn()
    {
        using var result = await _fixture.CallAsync("null_object");

        result.AsGodotObject().ShouldBeNull();
    }

    [Test]
    public async Task UntypedNullReturn()
    {
        using var result = await _fixture.CallAsync("untyped_null");

        result.VariantType.ShouldBe(Variant.Type.Nil);
    }

    [Test]
    public async Task ObjectReturn()
    {
        using var result = await _fixture.CallAsync("object");

        using var returned = result.AsGodotObject();
        returned.GetMeta("name").AsString().ShouldBe("object");
    }

    [Test]
    public async Task AwaitingFunction()
    {
        using var result = await _fixture.CallAsync("awaiting");

        result.AsString().ShouldBe("awaited");
    }

    [Test]
    public async Task AwaitingFunctionReturningAnObject()
    {
        using var result = await _fixture.CallAsync("awaiting_object");

        using var returned = result.AsGodotObject();
        returned.GetMeta("name").AsString().ShouldBe("object");
    }

    [Test]
    public async Task AwaitingFunctionReturningNull()
    {
        using var result = await _fixture.CallAsync("awaiting_null");

        result.AsGodotObject().ShouldBeNull();
    }

    [Test]
    public async Task ReturnedObjectIsReleased()
    {
        // No AsGodotObject here: Godot hands out one wrapper per object, so disposing one of the test's own would
        // also release a wrapper CallAsync left behind.
        using (await _fixture.CallAsync("object"))
        {
            _fixture.Call("last_object_alive").AsBool().ShouldBeTrue();
        }

        _fixture.Call("last_object_alive").AsBool().ShouldBeFalse();
    }

    [Test]
    public async Task FunctionStatesAreReleased()
    {
        const int calls = 20;
        var before = Performance.GetMonitor(Performance.Monitor.ObjectCount);

        for (var i = 0; i < calls; i++)
        {
            using var result = await _fixture.CallAsync("awaiting");
        }

        // Each call creates a GDScriptFunctionState; an undisposed wrapper keeps it alive until the GC runs.
        (Performance.GetMonitor(Performance.Monitor.ObjectCount) - before).ShouldBeLessThan(calls / 2);
    }

    [Test]
    public async Task TypedNullReturn()
    {
        (await _fixture.CallAsync<TwitchUser>("null_object")).ShouldBeNull();
    }
}
