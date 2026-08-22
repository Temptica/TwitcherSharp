using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;

public partial class TwitchGetHypeTrainStatusResponse : RefCounted, ITwitcherSharp<TwitchGetHypeTrainStatusResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public TwitchResponseAllTimeHigh AllTimeHigh { get => field ??= _data?.Get<TwitchResponseAllTimeHigh>("all_time_high")!; set; } = null!;
    public TwitchResponseSharedAllTimeHigh SharedAllTimeHigh { get => field ??= _data?.Get<TwitchResponseSharedAllTimeHigh>("shared_all_time_high")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainStatusResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetHypeTrainStatusResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(AllTimeHigh != null) request.Set("all_time_high", AllTimeHigh.ToGodotObject());
        if(SharedAllTimeHigh != null) request.Set("shared_all_time_high", SharedAllTimeHigh.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information related to the channel’s Hype Train. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public TwitchResponseCurrent Current { get => field ??= _data?.Get<TwitchResponseCurrent>("current")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData();
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Current != null) request.Set("current", Current.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// An object describing the current Hype Train. Null if a Hype Train is not active. 
        /// </summary>
        public partial class TwitchResponseCurrent : RefCounted, ITwitcherSharp<TwitchResponseCurrent>
        {
            private GodotObject? _data;
            public string Id { get; set; } = null!;
            public string BroadcasterUserId { get; set; } = null!;
            public string BroadcasterUserLogin { get; set; } = null!;
            public string BroadcasterUserName { get; set; } = null!;
            public int Level { get; set; }
            public int Total { get; set; }
            public int Progress { get; set; }
            public int Goal { get; set; }
            public TwitchResponseTopContributions[] TopContributions { get => field ??= _data?.GetArray<TwitchResponseTopContributions>("top_contributions")!; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseCurrent object.
            /// </summary> 
            public static TwitchResponseCurrent? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseCurrent
                {
                    Id = data.Get("id").AsString(),
                    BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                    BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                    BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                    Level = data.Get("level").AsInt32(),
                    Total = data.Get("total").AsInt32(),
                    Progress = data.Get("progress").AsInt32(),
                    Goal = data.Get("goal").AsInt32(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                var twitchResponseCurrentClass = script.Get("ResponseCurrent").AsGodotObject();
                var request = twitchResponseCurrentClass.Call("new").AsGodotObject();
                if(Id != null) request.Set("id", Id);
                if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
                if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
                if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
                request.Set("level", Level);
                request.Set("total", Total);
                request.Set("progress", Progress);
                request.Set("goal", Goal);
                if(TopContributions != null) request.Set("top_contributions", TopContributions.ToGodotArray());
                return request;
            }
            
            /// <summary> 
            /// The contributors with the most points contributed. 
            /// </summary>
            public partial class TwitchResponseTopContributions : RefCounted, ITwitcherSharp<TwitchResponseTopContributions>
            {
                private GodotObject? _data;
                public string UserId { get; set; } = null!;
                public string UserLogin { get; set; } = null!;
                public string UserName { get; set; } = null!;
                public string Type { get; set; } = null!;
                public int Total { get; set; }
                public TwitchResponseSharedTrainParticipants[] SharedTrainParticipants { get => field ??= _data?.GetArray<TwitchResponseSharedTrainParticipants>("shared_train_participants")!; set; } = null!;
                public string StartedAt { get; set; } = null!;
                public string ExpiresAt { get; set; } = null!;
                public bool IsSharedTrain { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchResponseTopContributions object.
                /// </summary> 
                public static TwitchResponseTopContributions? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchResponseTopContributions
                    {
                        UserId = data.Get("user_id").AsString(),
                        UserLogin = data.Get("user_login").AsString(),
                        UserName = data.Get("user_name").AsString(),
                        Type = data.Get("type").AsString(),
                        Total = data.Get("total").AsInt32(),
                        StartedAt = data.Get("started_at").AsString(),
                        ExpiresAt = data.Get("expires_at").AsString(),
                        IsSharedTrain = data.Get("is_shared_train").AsBool(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                    var twitchResponseTopContributionsClass = script.Get("ResponseTopContributions").AsGodotObject();
                    var request = twitchResponseTopContributionsClass.Call("new").AsGodotObject();
                    if(UserId != null) request.Set("user_id", UserId);
                    if(UserLogin != null) request.Set("user_login", UserLogin);
                    if(UserName != null) request.Set("user_name", UserName);
                    if(Type != null) request.Set("type", Type);
                    request.Set("total", Total);
                    if(SharedTrainParticipants != null) request.Set("shared_train_participants", SharedTrainParticipants.ToGodotArray());
                    if(StartedAt != null) request.Set("started_at", StartedAt);
                    if(ExpiresAt != null) request.Set("expires_at", ExpiresAt);
                    request.Set("is_shared_train", IsSharedTrain);
                    return request;
                }
                
                /// <summary> 
                /// A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared. 
                /// </summary>
                public partial class TwitchResponseSharedTrainParticipants : RefCounted, ITwitcherSharp<TwitchResponseSharedTrainParticipants>
                {
                    private GodotObject? _data;
                    public string BroadcasterUserId { get; set; } = null!;
                    public string BroadcasterUserLogin { get; set; } = null!;
                    public string BroadcasterUserName { get; set; } = null!;
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchResponseSharedTrainParticipants object.
                    /// </summary> 
                    public static TwitchResponseSharedTrainParticipants? FromObject(GodotObject? data)
                    {
                        if(data == null) return null;
                        var instance = new TwitchResponseSharedTrainParticipants
                        {
                            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
                            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                        };
                        
                        instance._data = data;
                        return instance;
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
                        var twitchResponseSharedTrainParticipantsClass = script.Get("ResponseSharedTrainParticipants").AsGodotObject();
                        var request = twitchResponseSharedTrainParticipantsClass.Call("new").AsGodotObject();
                        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
                        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
                        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
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
        private GodotObject? _data;
        public int Level { get; set; }
        public int Total { get; set; }
        public string AchievedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseAllTimeHigh object.
        /// </summary> 
        public static TwitchResponseAllTimeHigh? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseAllTimeHigh
            {
                Level = data.Get("level").AsInt32(),
                Total = data.Get("total").AsInt32(),
                AchievedAt = data.Get("achieved_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseAllTimeHighClass = script.Get("ResponseAllTimeHigh").AsGodotObject();
            var request = twitchResponseAllTimeHighClass.Call("new").AsGodotObject();
            request.Set("level", Level);
            request.Set("total", Total);
            if(AchievedAt != null) request.Set("achieved_at", AchievedAt);
            return request;
        }
    
    }
    
    /// <summary> 
    /// An object with information about the channel’s shared Hype Train records. Null if a Hype Train has not occurred. 
    /// </summary>
    public partial class TwitchResponseSharedAllTimeHigh : RefCounted, ITwitcherSharp<TwitchResponseSharedAllTimeHigh>
    {
        private GodotObject? _data;
        public int Level { get; set; }
        public int Total { get; set; }
        public string AchievedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseSharedAllTimeHigh object.
        /// </summary> 
        public static TwitchResponseSharedAllTimeHigh? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseSharedAllTimeHigh
            {
                Level = data.Get("level").AsInt32(),
                Total = data.Get("total").AsInt32(),
                AchievedAt = data.Get("achieved_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_status.gd");
            var twitchResponseSharedAllTimeHighClass = script.Get("ResponseSharedAllTimeHigh").AsGodotObject();
            var request = twitchResponseSharedAllTimeHighClass.Call("new").AsGodotObject();
            request.Set("level", Level);
            request.Set("total", Total);
            if(AchievedAt != null) request.Set("achieved_at", AchievedAt);
            return request;
        }
    
    }

}
