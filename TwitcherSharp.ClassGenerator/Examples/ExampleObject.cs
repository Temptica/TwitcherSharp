// using Godot;
// using TwitcherSharp.Interfaces;
//
// namespace TwitcherSharp.Generated.ExampleObject;
//
// public partial class ExampleObjectBody : Resource, ITwitcherSharp<ExampleObjectBody>
// {
//     private GodotObject _data;
//     public string TestObject { get; set; }
//     public string[] TestArray { get; set; }
//     public ExampleObjectBody TestDataObject { get; set; }
//
//     public static ExampleObjectBody FromObject(GodotObject data)
//     {
//         return new ExampleObjectBody
//         {
//             _data = data,
//             TestObject = data.Get("test_object").AsString(),
//             TestArray = data.Get("test_array").AsStringArray()
//         };
//     }
//
//     public GodotObject ToGodotObject()
//     {
//         var script =GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");
//         
//         var optClass = script.Get("Body").AsGodotObject();
//         var request = optClass.Call("new").AsGodotObject();
//         request.Set("test_array", TestArray);
//         request.Set("test_object", TestObject);
//         request.Set("test_data_object", TestDataObject.ToGodotObject());
//         return request;
//     }
// }
//
// public partial class ExampleObjectOptionals : Resource, ITwitcherSharp<ExampleObjectOptionals>
// {
//     private GodotObject _data;
//     public static ExampleObjectOptionals FromObject(GodotObject data)
//     {
//         return new ExampleObjectOptionals
//         {
//             _data = data
//         };
//     }
//
//     public GodotObject ToGodotObject()
//     {
//         return _data;
//     }
// }
//
// public partial class ExampleObjectResponse : Resource, ITwitcherSharp<ExampleObjectResponse>
// {
//     private GodotObject _data;
//     public static ExampleObjectResponse FromObject(GodotObject data)
//     {
//         return new ExampleObjectResponse
//         {
//             _data = data
//         };
//     }
//
//     public GodotObject ToGodotObject()
//     {
//         return _data;
//     }
// }