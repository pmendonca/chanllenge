using game.sketch;
using game.sketch.Enums;

namespace game.tests.sketch;

public class ClassicGameTest
{
    [Theory]
    [InlineData(ClassicOptions.Scissors, ClassicOptions.Paper, GameResult.PlayerOne)]
    [InlineData(ClassicOptions.Rock, ClassicOptions.Scissors, GameResult.PlayerOne)]
    [InlineData(ClassicOptions.Paper, ClassicOptions.Rock, GameResult.PlayerOne)]
    [InlineData(ClassicOptions.Scissors, ClassicOptions.Scissors, GameResult.Odd)]
    [InlineData(ClassicOptions.Rock, ClassicOptions.Rock, GameResult.Odd)]
    [InlineData(ClassicOptions.Paper, ClassicOptions.Paper, GameResult.Odd)]
    public void Play_ShouldReturnCorrectResultForValidMoves(ClassicOptions playerOneMove, ClassicOptions playerTwoMove,
        GameResult expectedResult)
    {
        var game = new ClassicGame();

        var result = game.Play(playerOneMove, playerTwoMove);

        Assert.Equal(expectedResult, result);
    }
}