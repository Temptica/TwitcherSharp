/*using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace ClassGenerator.Examples.EventSub;

public partial class EventSubExampleObject : Resource, ITwitcherSharpEventSub<EventSubExampleObject>
{
    public TwitchData[] Data { get; set; }
    public TwitchData DataTest { get; set; }

    public static EventSubExampleObject FromData(Dictionary data)
    {
        return new EventSubExampleObject
        {
            Data = data["data"].AsGodotArray().Select(x => TwitchData.FromData(x.AsGodotDictionary())).ToArray(),
            DataTest = TwitchData.FromData(data["data"].AsGodotDictionary())
        };
    }

    public partial class TwitchData : Resource, ITwitcherSharpEventSub<TwitchData>
    {
        public string BroadcasterUserId { get; set; }
        public string BroadcasterUserName { get; set; }
        public string BroadcasterUserLogin { get; set; }

        public static TwitchData FromData(Dictionary data)
        {
            return new TwitchData
            {
                BroadcasterUserId = data["broadcaster_user_id"].AsString(),
                BroadcasterUserName = data["broadcaster_user_name"].AsString(),
                BroadcasterUserLogin = data["broadcaster_user_login"].AsString()
            };
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