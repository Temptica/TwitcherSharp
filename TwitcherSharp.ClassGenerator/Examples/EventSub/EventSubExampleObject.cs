/*using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace ClassGenerator.Examples.EventSub;

public partial class EventSubExampleObject : Resource, ITwitcherSharpEventSub<EventSubExampleObject>
{
    public TwitchData[] Data { get; set; }
    public TwitchData DataTest { get; set; }

    public static EventSubExampleObject FromObject(GodotObject data)
    {
        return new EventSubExampleObject
        {
            Data = data.Get("data").AsGodotObjectArray<GodotObject>().Select(TwitchData.FromObject).ToArray(),
            DataTest = TwitchData.FromObject(data.Get("data_test").AsGodotObject())
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");

        var optClass = script.Get("Body").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        request.Set("data_test", DataTest);
        return request;
    }

    public partial class TwitchData : Resource, ITwitcherSharpEventSub<TwitchData>
    {
        public string BroadcasterUserId { get; set; }
        public string BroadcasterUserName { get; set; }
        public string BroadcasterUserLogin { get; set; }

        public static TwitchData FromObject(GodotObject data)
        {
            return new TwitchData
            {
                BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString()
            };
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_es_automod_message_hold.gd");
            var optClass = script.Get("Body").AsGodotObject();
            var request = optClass.Call("new").AsGodotObject();
            request.Set("broadcaster_user_id", BroadcasterUserId);
            request.Set("broadcaster_user_name", BroadcasterUserName);
            request.Set("broadcaster_user_login", BroadcasterUserLogin);
            return request;
        }
    }
}


// EventSubComponent
// // Fields
// // EventSubComponent
// // // fields,...

/*
  {
       "data": [
         {
           "broadcaster_user_id": "1337",
           "broadcaster_user_name": "CoolUser",
           "broadcaster_user_login": "cooluser",
           "moderator_user_id": "9001",
           "moderator_user_name": "CoolMod",
           "moderator_user_login": "coolmod",
           "overall_level": null,
           "disability": 3,
           "aggression": 3,
           "sexuality_sex_or_gender": 3,
           "misogyny": 3,
           "bullying": 3,
           "swearing": 0,
           "race_ethnicity_or_religion": 3,
           "sex_based_terms":30
         }
       ]
     }
 #1#*/