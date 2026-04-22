using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Extensions;
using HttpClient = System.Net.Http.HttpClient;

namespace TwitcherSharp.Demo.Scenes.WordGames;

public partial class WordTemptation : Node
{
    public GameState State { get; private set; } = GameState.NotStarted;
    private char[] _letters = [];
    private readonly List<UserScore> _scores = [];
    private readonly List<string> _foundWords = [];
    private readonly Timer _timer = new();
    private int _counter;

    [Signal]
    public delegate void StartedEventHandler(string message);

    [Signal]
    public delegate void WordFoundEventHandler(string message, string color);

    [Signal]
    public delegate void EndedEventHandler(string message);

    public override async void _Ready()
    {
        AddChild(_timer);
        _timer.Timeout += OnTimeout;
        _letters = [];

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        TwitchChat.GetInstance().MessageReceived += OnMessageReceived;
        this.GetTwitcherNode<TwitchCommand>("StartCommand").CommandReceived += async (_, _, _) => await Start();
        this.GetTwitcherNode<TwitchCommand>("StopCommand").CommandReceived += async (_, _, _) => await Stop();
        this.GetTwitcherNode<TwitchCommand>("ScoreCommand").CommandReceived +=
            (username, _, _) => SendMessage(GetScore(username));
        this.GetTwitcherNode<TwitchCommand>("ScoresCommand").CommandReceived +=
            (_, _, _) => SendMessage(GetScores());

        this.GetTwitcherNode<TwitchCommand>("HowToCommand").CommandReceived += async (_, info, _) =>
        {
            await TwitchBot.SendMessage(
                "Guess as many words as possible with the given letters within a minute time. Letter scoring are based on the Scrabble letter values.",
                info.ChatMessage.MessageId);
        };
    }

    private async void OnMessageReceived(TwitchChatMessage message)
    {
        if (State != GameState.Playing) return;

        if (message.Content.Fragments.Length != 1 || message.Content.Fragments[0].Type != FragmentType.Text) return;

        var content = message.Content.Fragments[0].Text;

        var result = await CheckWord(content, message.ChatterUserLogin);

        if (string.IsNullOrEmpty(result)) return;

        EmitSignalWordFound(result, message.Color);
    }

    public async Task Start(int duration = 60)
    {
        _counter = 1;
        if (State == GameState.Playing)
        {
            return;
        }

        _scores.Clear();
        _foundWords.Clear();
        State = GameState.Playing;
        _timer.Stop();
        _timer.WaitTime = duration / 2f;
        _timer.Start();
        GenerateLetters();
        var msg =
            $"A game of Word Temptation has started. Find as many words with the following letters: {string.Join(", ", _letters)}";
        
        EmitSignalStarted(msg);
        
        await TwitchBot.Announcement(msg, TwitchAnnouncementColor.Green);
    }

    private static readonly char[] Vowels = ['A', 'E', 'O', 'I', 'U'];

    private void GenerateLetters()
    {
        _letters = new char[2];
        var rng = new Random();
        var lettersChance = new List<char>
        {
            'B', 'B',
            'C', 'C',
            'D', 'D', 'D', 'D',
            'F', 'F',
            'G', 'G', 'G',
            'H', 'H',
            'J', 'J',
            'K', 'K',
            'L', 'L', 'L', 'L',
            'M', 'M',
            'N', 'N', 'N', 'N', 'N', 'N',
            'P', 'P',
            'R', 'R', 'R', 'R', 'R', 'R',
            'S', 'S', 'S', 'S',
            'T', 'T', 'T', 'T', 'T', 'T',
            'V', 'V',
            'W', 'W',
            'Y', 'Y'
        };

        _letters[0] = Vowels[rng.Next(Vowels.Length)];
        _letters[1] = lettersChance[rng.Next(lettersChance.Count)];
    }

    private void OnTimeout()
    {
        if (State != GameState.Playing) return;

        _counter++;
        if (_counter == 3)
        {
            _ = Stop();
            _counter = 0;
            return;
        }

        _ = TwitchBot.Announcement(
            $"{_timer.WaitTime} seconds remaining. Find words with the letters: {string.Join(", ", _letters)}",
            TwitchAnnouncementColor.Blue);
    }

    public async Task<string> CheckWord(string word, string username)
    {
        if (word.Length <= 3 || !_letters.All(word.ToUpper().Contains) ||
            _foundWords.Contains(word, StringComparer.InvariantCultureIgnoreCase)) return "";

        var result = await TestWord(word);

        if (!result) return "";

        var score = 0;
        foreach (var letter in word)
        {
            switch (letter.ToString().ToLower())
            {
                case "q":
                case "z":
                    score += 10;
                    break;
                case "j":
                case "x":
                    score += 8;
                    break;
                case "k":
                    score += 5;
                    break;
                case "f":
                case "h":
                case "v":
                case "w":
                case "y":
                    score += 4;
                    break;
                case "b":
                case "c":
                case "m":
                case "p":
                    score += 3;
                    break;
                case "d":
                case "g":
                    score += 2;
                    break;
                default:
                    score++;
                    break;
            }
        }

        var user = _scores.FirstOrDefault(userScore => userScore.UserName == username);
        if (user is null)
        {
            _scores.Add(new UserScore
                { UserName = username, LetterCount = (uint)word.Length, Score = (uint)score, WordsFound = 1 });
        }
        else
        {
            user.LetterCount += (uint)word.Length;
            user.Score += (uint)score;
            user.WordsFound++;
        }

        _foundWords.Add(word);
        return $"{username} found a new word: {word} for {score} points!";
    }

    private const string ApiUrl = "https://api.dictionaryapi.dev/api/v2/entries/en/{0}";

    private async Task<bool> TestWord(string word)
    {
        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync(string.Format(ApiUrl, word));
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return !responseBody.Contains("No Definitions Found");
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }

    public string GetScore(string username)
    {
        if (State != GameState.Stopped)
        {
            return $"no results available {username}";
        }

        var user = _scores.FirstOrDefault(score => score.UserName == username);
        if (user is null)
        {
            return $"Couldn't find a score for you {username}";
        }

        return
            $"{username} found {user.WordsFound} words with a total score of {user.Score} points! {username} used {user.LetterCount} letters in total.";
    }

    public string GetScores()
    {
        var top3 = _scores.OrderByDescending(score => score.Score).Take(3).ToList();
        if (top3.Count == 0)
        {
            return "But no one played";
        }

        var result = $"Top {top3.Count} score:\n";
        var i = 0;
        foreach (var userScore in top3)
        {
            i++;
            result += $"\n{i}. {userScore.UserName}: {userScore.Score}.";
        }

        var totalWords = _scores.Sum(score => score.WordsFound);
        var totalPoints = _scores.Sum(score => score.Score);
        var longestWord = _foundWords.OrderByDescending(word => word.Length).First();
        result +=
            $"\n\nCommunity scores:\nTotal words count: {totalWords}.\nTotal score: {totalPoints}.\nLongest word: {longestWord}.";
        return result;
    }

    public async Task Stop()
    {
        if (State != GameState.Playing) return;
        State = GameState.Stopped;

        var scores = GetScores();
        EmitSignalEnded(scores);
        await TwitchBot.Announcement("!!WORD TEMPTATION ENDED!!", TwitchAnnouncementColor.Orange);
        _timer.Stop();
    }

    private static void SendMessage(string message)
    {
        _ = TwitchBot.SendMessage(message);
    }
}

public enum GameState
{
    NotStarted,
    Playing,
    Stopped
}

internal class UserScore
{
    public string UserName { get; set; }
    public uint WordsFound { get; set; }
    public uint Score { get; set; }
    public uint LetterCount { get; set; }
}