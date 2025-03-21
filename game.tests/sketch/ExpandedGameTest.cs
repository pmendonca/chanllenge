using game.sketch;
using game.sketch.Enums;

namespace game.tests.sketch;

public class ExpandedGameTest
{
    [Theory]
    [InlineData(ExpandedOptions.Rock, new[] { ExpandedOptions.Scissors, ExpandedOptions.Lizard })]
    [InlineData(ExpandedOptions.Paper, new[] { ExpandedOptions.Rock, ExpandedOptions.Spock })]
    [InlineData(ExpandedOptions.Scissors, new[] { ExpandedOptions.Paper, ExpandedOptions.Lizard })]
    [InlineData(ExpandedOptions.Lizard, new[] { ExpandedOptions.Spock, ExpandedOptions.Paper })]
    [InlineData(ExpandedOptions.Spock, new[] { ExpandedOptions.Rock, ExpandedOptions.Scissors })]
    public void Play_ShouldReturnCorrectResultForValidMoves(ExpandedOptions playerOneMove, ExpandedOptions[] moves)
    {
        var game = new ExpandedGame();

        var results = moves.Select(m => game.Play(playerOneMove, m));

        Assert.All(results, result => Assert.Equal(GameResult.PlayerOne, result));
    }
}