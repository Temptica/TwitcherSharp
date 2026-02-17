/*using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Generated.ExampleObject;

public partial class ExampleObjectBody : Resource, ITwitcherSharp<ExampleObjectBody>
{
    private GodotObject _data;
    public string TestObject { get; set; }
    public string[] TestArray { get; set; }
    public ExampleObject[] Objects { get; set; }
    public TwitchData[] Objects2 { get; set; }

    public static ExampleObjectBody FromObject(GodotObject data)
    {
        var objectsArray = data.Get("object_array").AsGodotArray<GodotObject>();
        return new ExampleObjectBody
        {
            _data = data,
            TestObject = data.Get("test_object").AsString(),
            TestArray = data.Get("test_array").AsStringArray(),
            Objects = objectsArray.Select(ExampleObject.FromObject).ToArray(),
            Objects2 = objectsArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script =GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");
        
        var optClass = script.Get("Body").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        request.Set("test_array", TestArray);
        request.Set("test_object", TestObject);
        return request;
    }
    
    public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
    {
        public static TwitchData FromObject(GodotObject data)
        {
            throw new NotImplementedException();
        }

        public GodotObject ToGodotObject()
        {
            throw new NotImplementedException();
        }
    }
    
}

public partial class ExampleObjectOptionals : Resource, ITwitcherSharp<ExampleObjectOptionals>
{
    private GodotObject _data;
    public static ExampleObjectOptionals FromObject(GodotObject data)
    {
        return new ExampleObjectOptionals
        {
            _data = data
        };
    }

    public GodotObject ToGodotObject()
    {
        return _data;
    }
}

public partial class ExampleObjectResponse : Resource, ITwitcherSharp<ExampleObjectResponse>
{
    private GodotObject _data;
    public static ExampleObjectResponse FromObject(GodotObject data)
    {
        return new ExampleObjectResponse
        {
            _data = data
        };
    }

    public void Test()
    {
        var test = new ExampleObjectBody();
        test.Objects2[0] = new ExampleObjectBody.TwitchData();
    }

    public GodotObject ToGodotObject()
    {
        return _data;
    }
}

public partial class ExampleObject : Resource, ITwitcherSharp<ExampleObject>
{
    private GodotObject _data;
    public static ExampleObject FromObject(GodotObject data)
    {
        return new ExampleObject
        {
            _data = data
        };
    }

    public GodotObject ToGodotObject()
    {
        return _data;
    }
}*/