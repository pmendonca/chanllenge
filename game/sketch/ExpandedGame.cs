using game.sketch.Enums;

namespace game.sketch;

public class ExpandedGame
{
    private Dictionary<ExpandedOptions, List<ExpandedOptions>> RuleSet { get; } = new()
    {
        { ExpandedOptions.Rock, [ExpandedOptions.Scissors, ExpandedOptions.Lizard] },
        { ExpandedOptions.Paper, [ExpandedOptions.Rock, ExpandedOptions.Spock] },
        { ExpandedOptions.Scissors, [ExpandedOptions.Paper, ExpandedOptions.Lizard] },
        { ExpandedOptions.Lizard, [ExpandedOptions.Spock, ExpandedOptions.Paper] },
        { ExpandedOptions.Spock, [ExpandedOptions.Scissors, ExpandedOptions.Rock] }
    };
    
    public GameResult Play(ExpandedOptions playerOne, ExpandedOptions playerTwo)
    {
        return playerTwo == playerOne
            ? GameResult.Odd
            : RuleSet[playerOne].Contains(playerTwo)
                ? GameResult.PlayerOne
                : GameResult.PlayerTwo;
    }
}