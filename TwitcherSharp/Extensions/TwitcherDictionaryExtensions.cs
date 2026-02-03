using System;
using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Reward;


namespace TwitcherSharp.Extensions;

public static class TwitcherDictionaryExtensions
{
	extension(Dictionary data)
	{
		public string UserName => data["user_name"].AsString();
		public int Tier => int.Parse(data["tier"].AsString()[0].ToString());

		public string Message
		{
			get
			{
				var message = data["message"].AsString();

				if (message.StartsWith('{') && message.EndsWith('}'))
				{
					return data["message"].AsGodotDictionary()["text"].AsString();
				}

				return data["message"].AsString();
			}
		}

		public string CumulativeMonths => data["cumulative_months"].AsString();
		public string StreakMonths => data["streak_months"].AsString();
		public int Bits => data["bits"].AsInt32();
		public string FromBroadcasterUserName => data["from_broadcaster_user_name"].AsString();
		public int Viewers => data["viewers"].AsInt32();

		public int RewardChannelPoints
		{
			get
			{
				var test = data["reward"];
				return test.AsGodotDictionary()["channel_points"].AsInt32();
			}
		}

		public int RewardCost
		{
			get
			{
				var test = data["reward"];
				return test.AsGodotDictionary()["cost"].AsInt32();
			}
		}
	}
	
}
