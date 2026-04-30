using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Extensions;

namespace TwitcherSharp.Demo.Scenes.NumbersGame;

public partial class Numbers404 : Node
{
    private int _digit;
    public GameState State { get; set; }
    private readonly Random _rng = new();
    private Timer _timer = new();
    private int _turnsCounter;
    private List<Guess> _guess = [];
    private List<Vote> _vote = [];
    private int _minNumber;
    private int _maxNumber;
    private int? _hint;

    [Signal]
    public delegate void StartedEventHandler(string message);

    [Signal]
    public delegate void GuessedEventHandler(string message, string color);

    [Signal]
    public delegate void VotingStartedEventHandler(string message);

    [Signal]
    public delegate void VotingEndedEventHandler(string message);

    [Signal]
    public delegate void EndedEventHandler(string message);

    public override async void _Ready()
    {
        AddChild(_timer);
        _timer.Timeout += OnTimeout;

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        TwitchChat.GetInstance().MessageReceived += async message => await OnMessageReceived(message);
        this.GetTwitcherNode<TwitchCommand>("StartCommand").CommandReceived += async (_, _, _) => await Start();
        this.GetTwitcherNode<TwitchCommand>("StopCommand").CommandReceived += async (_, _, _) => await Stop();
    }

    private async Task OnMessageReceived(TwitchChatMessage message)
    {
        if (message.Content.Fragments.Length != 1 || message.Content.Fragments[0].Type != FragmentType.Text ||
            !int.TryParse(message.Content.Fragments[0].Text, out var number)) return;
        var result = Input(message.ChatterUserName, number, message.Color);
        if (string.IsNullOrEmpty(result)) return;

        await TwitchBot.SendMessage(result, message.MessageId);
    }

    private async Task Start()
    {
        _hint = null;
        _minNumber = 1;
        _maxNumber = 10000;
        _turnsCounter = 1;
        _digit = _rng.Next(_minNumber, _maxNumber + 1); //1-10000
        State = GameState.Guessing;
        _guess = [];
        _vote = [];
        var msg = $"A game of Number404 has started. Guess a number between {_minNumber} and {_maxNumber}";

        EmitSignalStarted(msg);
        await TwitchBot.Announcement(msg, TwitchAnnouncementColor.Orange);
    }

    private string Input(string username, int number, string color) =>
        State switch
        {
            GameState.Guessing when number > _minNumber && number < _maxNumber => Guess(new Guess(username, number,
                color)),
            GameState.Voting when number > 0 && number <= _guess.Count => Vote(new Vote(username, number)),
            _ => ""
        };

    private string Guess(Guess guess)
    {
        if (_guess.Any(e => e.HasGuessOrName(guess))) return "";
        _guess.Add(guess);
        EmitSignalGuessed($"{guess.UserName} guessed {guess.GuessedNumber}", guess.UserColor);
        if (_guess.Count != 1) return "";
        _timer.Start(10);
        return "10 seconds remaining to guess a number.";
    }

    private void OnTimeout()
    {
        _timer.Stop();
        if (State == GameState.Guessing)
        {
            OnGuessElapse();
            return;
        }

        VoteElapse();
    }

    private void OnGuessElapse()
    {
        if (_guess.Count > 1)
        {
            var response = "Please vote for the next guesses:\n";
            var i = 0;
            foreach (var guess in _guess.Take(10).ToList())
            {
                i++;
                response += $"{i}: {guess.GuessedNumber}\n";
            }

            State = GameState.Voting;
            EmitSignalVotingStarted(response);

            return;
        }

        HigherOrLower(1);
    }

    private string Vote(Vote vote)
    {
        if (_vote.Count == 0)
        {
            _timer.Start(10);
        }
        else if (_vote.Any(v => v.UserName == vote.UserName))
        {
            return "You can't vote twice!";
        }

        _vote.Add(vote);
        return "";
    }

    private void VoteElapse()
    {
        State = GameState.Waiting;
        var mostVoted = _vote.GroupBy(v => v.VoteNumber).OrderByDescending(v => v.Count()).ThenBy(v => v.Key).First()
            .Key;
        HigherOrLower(mostVoted);
    }

    private void HigherOrLower(int vote)
    {
        var guess = _guess[vote - 1];
        _guess = [];
        _vote = [];
        Task.Delay(3000);
        if (guess.GuessedNumber == _digit)
        {
            var msg = $"Congrats, you guessed the number {_digit} in {_turnsCounter} turns!";
            EmitSignalEnded(msg);
            SendMessage(msg);

            State = GameState.Ended;
            return;
        }

        _turnsCounter++;
        var response = $"Round {_turnsCounter}!\nThe number is ";
        if (guess.GuessedNumber > _digit)
        {
            response += "lower";
            _maxNumber = guess.GuessedNumber;
        }
        else
        {
            response += "higher";
            _minNumber = guess.GuessedNumber;
        }

        response += $" than {guess.GuessedNumber}.\nPlease guess a number between {_minNumber} and {_maxNumber}.";
        response += Hint();
        EmitSignalVotingEnded(response);
        State = GameState.Guessing;
    }


    private string Hint()
    {
        var rng = new Random();
        var hints = "";
        if (_turnsCounter >= 3)
        {
            _hint ??= int.Parse(_digit.ToString()[rng.Next(0, _digit.ToString().Length)].ToString());
            hints += $"\nHINT 1: The number contains a {_hint}";
        }

        if (_turnsCounter >= 6)
        {
            hints +=
                $"\nHINT 2: The sum of the numbers is {_digit.ToString().ToCharArray().Sum(n => int.Parse(n.ToString()))}";
        }

        if (_turnsCounter >= 9)
            hints += _digit % 2 == 0
                ? "\nHINT 3: The number is an even number."
                : "\nHINT 3: The number is an odd number.";

        return hints;
    }

    public async Task Stop()
    {
        State = GameState.Ended;
        var msg = $"Game has been stopped. The number was {_digit}";
        EmitSignalEnded(msg);
        await TwitchBot.SendMessage(msg);
        _hint = null;
    }

    private static void SendMessage(string message)
    {
        _ = TwitchBot.SendMessage(message);
    }
}

internal record Vote(string UserName, int VoteNumber);

internal record Guess(string UserName, int GuessedNumber, string UserColor)
{
    public bool HasGuessOrName(Guess guess)
    {
        return guess.GuessedNumber == GuessedNumber || guess.UserName == UserName;
    }
}

public enum GameState
{
    Guessing = 1,
    Voting,
    Waiting,
    Ended
}