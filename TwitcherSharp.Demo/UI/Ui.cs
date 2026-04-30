using System.Threading.Tasks;
using Godot;
using TwitcherSharp.Demo.Scenes.NumbersGame;
using TwitcherSharp.Demo.Scenes.WordGames;

namespace TwitcherSharp.Demo.UI;

public partial class Ui : Control
{
    private VBoxContainer _wordsContainer;
    private VBoxContainer _numbersContainer;
    private WordTemptation _wordTemptation;
    private Numbers404 _numbers404;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _wordsContainer = GetNode<VBoxContainer>("%WordsContainer");
        _numbersContainer = GetNode<VBoxContainer>("%NumbersContainer");
        _wordTemptation = GetNode<WordTemptation>("WordTemptation");
        _numbers404 = GetNode<Numbers404>("Numbers404");

        SetupWords();
        SetupNumbers();
    }

    private void SetupWords()
    {
        _wordTemptation.Started += OnWordTemptationStarted;
        _wordTemptation.WordFound += OnWordFound;
        _wordTemptation.Ended += async message => await OnWordTemptationEnded(message);
    }

    private static readonly LabelSettings BigLabelSetting = new()
    {
        FontSize = 26,
    };

    private void OnWordTemptationStarted(string message)
    {
        foreach (var child in _wordsContainer.GetChildren())
        {
            child.QueueFree();
        }

        _wordsContainer.AddChild(new Label
            { Text = message, LabelSettings = BigLabelSetting, AutowrapMode = TextServer.AutowrapMode.WordSmart });
    }

    private void OnWordFound(string message, string htmlColor)
    {
        var color = Color.FromHtml(htmlColor);
        if (color == Colors.Black) color = Colors.White;
        _wordsContainer.AddChild(CreateLabel(message, color));

        if (_wordsContainer.GetChildCount() > 15)
        {
            //Skip first, which has the letters to guess
            _wordsContainer.GetChild(1).QueueFree();
        }
    }

    private async Task OnWordTemptationEnded(string message)
    {
        foreach (var child in _wordsContainer.GetChildren())
        {
            child.QueueFree();
        }

        var label = CreateBigLabel(message);
        _wordsContainer.AddChild(label);

        await ToSignal(GetTree().CreateTimer(20), "timeout");

        label.QueueFree();
    }

    private void SetupNumbers()
    {
        _numbers404.Started += OnNumbersStarted;
        _numbers404.Guessed += OnNumbersGuessed;
        _numbers404.VotingStarted += OnNumbersVotingStarted;
        _numbers404.VotingEnded += OnNumbersVotingEnded;
        _numbers404.Ended += async msg => await OnNumbersEnded(msg);
    }

    private void OnNumbersStarted(string message)
    {
        foreach (var child in _numbersContainer.GetChildren())
        {
            child.QueueFree();
        }

        _numbersContainer.AddChild(CreateBigLabel(message));
    }

    private void OnNumbersGuessed(string message, string htmlColor)
    {
        var color = Color.FromHtml(htmlColor);
        if (color == Colors.Black) color = Colors.White;
        _numbersContainer.AddChild(CreateLabel(message, color));
    }

    private void OnNumbersVotingStarted(string message)
    {
        ClearNumberLabels();
        _numbersContainer.AddChild(CreateBigLabel(message));
    }

    private void OnNumbersVotingEnded(string message)
    {
        ClearNumberLabels();
        _numbersContainer.AddChild(CreateBigLabel(message));
    }

    private async Task OnNumbersEnded(string message)
    {
        ClearNumberLabels();
        var label = CreateBigLabel(message);
        _numbersContainer.AddChild(label);
        await ToSignal(GetTree().CreateTimer(20), "timeout");

        label.QueueFree();
    }

    private void ClearNumberLabels()
    {
        foreach (var child in _numbersContainer.GetChildren())
        {
            child.QueueFree();
        }
    }

    private static Label CreateLabel(string text, Color color)
    {
        return new Label
        {
            Text = text, LabelSettings = new LabelSettings { FontColor = color, FontSize = 20 },
            AutowrapMode = TextServer.AutowrapMode.WordSmart
        };
    }

    private static Label CreateBigLabel(string text)
    {
        return new Label
        {
            Text = text, LabelSettings = BigLabelSetting, AutowrapMode = TextServer.AutowrapMode.WordSmart
        };
    }
}