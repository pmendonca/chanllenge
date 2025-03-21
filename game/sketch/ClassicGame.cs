using game.sketch.Enums;

namespace game.sketch;

public class ClassicGame
{
    private Dictionary<ClassicOptions, ClassicOptions> RuleSet { get; } = new()
    {
        { ClassicOptions.Paper, ClassicOptions.Rock },
        { ClassicOptions.Rock, ClassicOptions.Scissors },
        { ClassicOptions.Scissors, ClassicOptions.Paper },
    };

    public GameResult Play(ClassicOptions playerOne, ClassicOptions playerTwo)
    {
        return playerTwo == playerOne
            ? GameResult.Odd
            : RuleSet[playerOne] == playerTwo
                ? GameResult.PlayerOne
                : GameResult.PlayerTwo;
    }
}