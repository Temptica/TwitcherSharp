using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;

public partial class TwitchGetHypeTrainStatusResponse : RefCounted, ITwitcherSharp<TwitchGetHypeTrainStatusResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }
    public TwitchResponseAllTimeHigh AllTimeHigh { get; set; }
    public TwitchResponseSharedAllTimeHigh SharedAllTimeHigh { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainStatusResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetHypeTrainStatusResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
            AllTimeHigh = data.Get("all_time_high").As<TwitchResponseAllTimeHigh>(),
            SharedAllTimeHigh = data.Get("shared_all_time_high").As<TwitchResponseSharedAllTimeHigh>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        request.Set("all_time_high", AllTimeHigh?.ToGodotObject());
        request.Set("shared_all_time_high", SharedAllTimeHigh?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information related to the channel’s Hype Train. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public TwitchResponseCurrent Current { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                Current = data.Get("current").As<TwitchResponseCurrent>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("current", Current?.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// An object describing the current Hype Train. Null if a Hype Train is not active. 
        /// </summary>
        public partial class TwitchResponseCurrent : RefCounted, ITwitcherSharp<TwitchResponseCurrent>
        {
            private GodotObject _data;
            public string Id { get; set; }
            public string BroadcasterUserId { get; set; }
            public string BroadcasterUserLogin { get; set; }
            public string BroadcasterUserName { get; set; }
            public int Level { get; set; }
            public int Total { get; set; }
            public int Progress { get; set; }
            public int Goal { get; set; }
            public TwitchResponseTopContributions[] TopContributions { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseCurrent object.
            /// </summary> 
            public static TwitchResponseCurrent FromObject(GodotObject data)
            {
                if(data == null) return null;
                var topContributionsArray = data.Get("top_contributions").AsGodotArray<GodotObject>();
                return new TwitchResponseCurrent
                {
                    Id = data.Get("id").AsString(),
                    BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                    BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                    BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                    Level = data.Get("level").AsInt32(),
                    Total = data.Get("total").AsInt32(),
                    Progress = data.Get("progress").AsInt32(),
                    Goal = data.Get("goal").AsInt32(),
                    TopContributions = topContributionsArray.Select(TwitchResponseTopContributions.FromObject).ToArray(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                var twitchResponseCurrentClass = script.Get("ResponseCurrent").AsGodotObject();
                var request = twitchResponseCurrentClass.Call("new").AsGodotObject();
                request.Set("id", Id);
                request.Set("broadcaster_user_id", BroadcasterUserId);
                request.Set("broadcaster_user_login", BroadcasterUserLogin);
                request.Set("broadcaster_user_name", BroadcasterUserName);
                request.Set("level", Level);
                request.Set("total", Total);
                request.Set("progress", Progress);
                request.Set("goal", Goal);
                if(TopContributions != null) request.Set("top_contributions", TopContributions?.ToGodotArray());
                return request;
            }
            
            /// <summary> 
            /// The contributors with the most points contributed. 
            /// </summary>
            public partial class TwitchResponseTopContributions : RefCounted, ITwitcherSharp<TwitchResponseTopContributions>
            {
                private GodotObject _data;
                public string UserId { get; set; }
                public string UserLogin { get; set; }
                public string UserName { get; set; }
                public string Type { get; set; }
                public int Total { get; set; }
                public TwitchResponseSharedTrainParticipants[] SharedTrainParticipants { get; set; }
                public string StartedAt { get; set; }
                public string ExpiresAt { get; set; }
                public bool IsSharedTrain { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchResponseTopContributions object.
                /// </summary> 
                public static TwitchResponseTopContributions FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    var sharedTrainParticipantsArray = data.Get("shared_train_participants").AsGodotArray<GodotObject>();
                    return new TwitchResponseTopContributions
                    {
                        UserId = data.Get("user_id").AsString(),
                        UserLogin = data.Get("user_login").AsString(),
                        UserName = data.Get("user_name").AsString(),
                        Type = data.Get("type").AsString(),
                        Total = data.Get("total").AsInt32(),
                        SharedTrainParticipants = sharedTrainParticipantsArray.Select(TwitchResponseSharedTrainParticipants.FromObject).ToArray(),
                        StartedAt = data.Get("started_at").AsString(),
                        ExpiresAt = data.Get("expires_at").AsString(),
                        IsSharedTrain = data.Get("is_shared_train").AsBool(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                    var twitchResponseTopContributionsClass = script.Get("ResponseTopContributions").AsGodotObject();
                    var request = twitchResponseTopContributionsClass.Call("new").AsGodotObject();
                    request.Set("user_id", UserId);
                    request.Set("user_login", UserLogin);
                    request.Set("user_name", UserName);
                    request.Set("type", Type);
                    request.Set("total", Total);
                    if(SharedTrainParticipants != null) request.Set("shared_train_participants", SharedTrainParticipants?.ToGodotArray());
                    request.Set("started_at", StartedAt);
                    request.Set("expires_at", ExpiresAt);
                    request.Set("is_shared_train", IsSharedTrain);
                    return request;
                }
                
                /// <summary> 
                /// A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared. 
                /// </summary>
                public partial class TwitchResponseSharedTrainParticipants : RefCounted, ITwitcherSharp<TwitchResponseSharedTrainParticipants>
                {
                    private GodotObject _data;
                    public string BroadcasterUserId { get; set; }
                    public string BroadcasterUserLogin { get; set; }
                    public string BroadcasterUserName { get; set; }
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchResponseSharedTrainParticipants object.
                    /// </summary> 
                    public static TwitchResponseSharedTrainParticipants FromObject(GodotObject data)
                    {
                        if(data == null) return null;
                        return new TwitchResponseSharedTrainParticipants
                        {
                            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                        };
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                        var twitchResponseSharedTrainParticipantsClass = script.Get("ResponseSharedTrainParticipants").AsGodotObject();
                        var request = twitchResponseSharedTrainParticipantsClass.Call("new").AsGodotObject();
                        request.Set("broadcaster_user_id", BroadcasterUserId);
                        request.Set("broadcaster_user_login", BroadcasterUserLogin);
                        request.Set("broadcaster_user_name", BroadcasterUserName);
                        return request;
                    }
                
                }
            
            }
        
        }
    
    }
    
    /// <summary> 
    /// An object with information about the channel’s Hype Train records. Null if a Hype Train has not occurred. 
    /// </summary>
    public partial class TwitchResponseAllTimeHigh : RefCounted, ITwitcherSharp<TwitchResponseAllTimeHigh>
    {
        private GodotObject _data;
        public int Level { get; set; }
        public int Total { get; set; }
        public string AchievedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseAllTimeHigh object.
        /// </summary> 
        public static TwitchResponseAllTimeHigh FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseAllTimeHigh
            {
                Level = data.Get("level").AsInt32(),
                Total = data.Get("total").AsInt32(),
                AchievedAt = data.Get("achieved_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseAllTimeHighClass = script.Get("ResponseAllTimeHigh").AsGodotObject();
            var request = twitchResponseAllTimeHighClass.Call("new").AsGodotObject();
            request.Set("level", Level);
            request.Set("total", Total);
            request.Set("achieved_at", AchievedAt);
            return request;
        }
    
    }
    
    /// <summary> 
    /// An object with information about the channel’s shared Hype Train records. Null if a Hype Train has not occurred. 
    /// </summary>
    public partial class TwitchResponseSharedAllTimeHigh : RefCounted, ITwitcherSharp<TwitchResponseSharedAllTimeHigh>
    {
        private GodotObject _data;
        public int Level { get; set; }
        public int Total { get; set; }
        public string AchievedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseSharedAllTimeHigh object.
        /// </summary> 
        public static TwitchResponseSharedAllTimeHigh FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseSharedAllTimeHigh
            {
                Level = data.Get("level").AsInt32(),
                Total = data.Get("total").AsInt32(),
                AchievedAt = data.Get("achieved_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseSharedAllTimeHighClass = script.Get("ResponseSharedAllTimeHigh").AsGodotObject();
            var request = twitchResponseSharedAllTimeHighClass.Call("new").AsGodotObject();
            request.Set("level", Level);
            request.Set("total", Total);
            request.Set("achieved_at", AchievedAt);
            return request;
        }
    
    }

}
