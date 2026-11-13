using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;

public partial class TwitchGetHypeTrainStatusResponse : RefCounted, ITwitcherSharp<TwitchGetHypeTrainStatusResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public TwitchResponseAllTimeHigh AllTimeHigh { get => field ??= _data.Get<TwitchResponseAllTimeHigh>("all_time_high")!; set; } = null!;
    public TwitchResponseSharedAllTimeHigh SharedAllTimeHigh { get => field ??= _data.Get<TwitchResponseSharedAllTimeHigh>("shared_all_time_high")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainStatusResponse object.
    /// </summary> 
    public static TwitchGetHypeTrainStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetHypeTrainStatusResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(AllTimeHigh != null) request.SetObject("all_time_high", AllTimeHigh);
        if(SharedAllTimeHigh != null) request.SetObject("shared_all_time_high", SharedAllTimeHigh);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list that contains information related to the channel’s Hype Train. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public TwitchResponseCurrent Current { get => field ??= _data.Get<TwitchResponseCurrent>("current")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData();
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseData");
            if(Current != null) request.SetObject("current", Current);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// An object describing the current Hype Train. Null if a Hype Train is not active. 
        /// </summary>
        public partial class TwitchResponseCurrent : RefCounted, ITwitcherSharp<TwitchResponseCurrent>
        {
            private Variant _data;
            public string Id { get; set; } = null!;
            public string BroadcasterUserId { get; set; } = null!;
            public string BroadcasterUserLogin { get; set; } = null!;
            public string BroadcasterUserName { get; set; } = null!;
            public int Level { get; set; }
            public int Total { get; set; }
            public int Progress { get; set; }
            public int Goal { get; set; }
            public TwitchResponseTopContributions[] TopContributions { get => field ??= _data.GetArray<TwitchResponseTopContributions>("top_contributions")!; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseCurrent object.
            /// </summary> 
            public static TwitchResponseCurrent? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseCurrent
                {
                    Id = data.ReadAsString("id"),
                    BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
                    BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
                    BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
                    Level = data.ReadAsInt32("level"),
                    Total = data.ReadAsInt32("total"),
                    Progress = data.ReadAsInt32("progress"),
                    Goal = data.ReadAsInt32("goal"),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseCurrent");
                if(Id != null) request.SetValue("id", Id);
                if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
                if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
                if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
                request.SetValue("level", Level);
                request.SetValue("total", Total);
                request.SetValue("progress", Progress);
                request.SetValue("goal", Goal);
                if(TopContributions != null) request.SetArray("top_contributions", TopContributions);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
            
            /// <summary> 
            /// The contributors with the most points contributed. 
            /// </summary>
            public partial class TwitchResponseTopContributions : RefCounted, ITwitcherSharp<TwitchResponseTopContributions>
            {
                private Variant _data;
                public string UserId { get; set; } = null!;
                public string UserLogin { get; set; } = null!;
                public string UserName { get; set; } = null!;
                public string Type { get; set; } = null!;
                public int Total { get; set; }
                public TwitchResponseSharedTrainParticipants[] SharedTrainParticipants { get => field ??= _data.GetArray<TwitchResponseSharedTrainParticipants>("shared_train_participants")!; set; } = null!;
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
                        UserId = data.ReadAsString("user_id"),
                        UserLogin = data.ReadAsString("user_login"),
                        UserName = data.ReadAsString("user_name"),
                        Type = data.ReadAsString("type"),
                        Total = data.ReadAsInt32("total"),
                        StartedAt = data.ReadAsString("started_at"),
                        ExpiresAt = data.ReadAsString("expires_at"),
                        IsSharedTrain = data.ReadAsBool("is_shared_train"),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseTopContributions");
                    if(UserId != null) request.SetValue("user_id", UserId);
                    if(UserLogin != null) request.SetValue("user_login", UserLogin);
                    if(UserName != null) request.SetValue("user_name", UserName);
                    if(Type != null) request.SetValue("type", Type);
                    request.SetValue("total", Total);
                    if(SharedTrainParticipants != null) request.SetArray("shared_train_participants", SharedTrainParticipants);
                    if(StartedAt != null) request.SetValue("started_at", StartedAt);
                    if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
                    request.SetValue("is_shared_train", IsSharedTrain);
                    return request;
                }
            
                /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                protected override void Dispose(bool disposing)
                {
                    if (disposing) _data.Dispose();
                    base.Dispose(disposing);
                }
                
                /// <summary> 
                /// A list containing the broadcasters participating in the shared Hype Train. Null if the Hype Train is not shared. 
                /// </summary>
                public partial class TwitchResponseSharedTrainParticipants : RefCounted, ITwitcherSharp<TwitchResponseSharedTrainParticipants>
                {
                    private Variant _data;
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
                            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
                            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
                            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
                        };
                        
                        instance._data = Variant.CreateFrom(data);
                        return instance;
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseSharedTrainParticipants");
                        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
                        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
                        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
                        return request;
                    }
                
                    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                    protected override void Dispose(bool disposing)
                    {
                        if (disposing) _data.Dispose();
                        base.Dispose(disposing);
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
        private Variant _data;
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
                Level = data.ReadAsInt32("level"),
                Total = data.ReadAsInt32("total"),
                AchievedAt = data.ReadAsString("achieved_at"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseAllTimeHigh");
            request.SetValue("level", Level);
            request.SetValue("total", Total);
            if(AchievedAt != null) request.SetValue("achieved_at", AchievedAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }
    
    /// <summary> 
    /// An object with information about the channel’s shared Hype Train records. Null if a Hype Train has not occurred. 
    /// </summary>
    public partial class TwitchResponseSharedAllTimeHigh : RefCounted, ITwitcherSharp<TwitchResponseSharedAllTimeHigh>
    {
        private Variant _data;
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
                Level = data.ReadAsInt32("level"),
                Total = data.ReadAsInt32("total"),
                AchievedAt = data.ReadAsString("achieved_at"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_hype_train_status.gd", "ResponseSharedAllTimeHigh");
            request.SetValue("level", Level);
            request.SetValue("total", Total);
            if(AchievedAt != null) request.SetValue("achieved_at", AchievedAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
