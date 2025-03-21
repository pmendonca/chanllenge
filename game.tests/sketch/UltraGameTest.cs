using game.sketch;
using game.sketch.Enums;

namespace game.tests.sketch;

public class UltraGameTest
{
    [Theory]
    [InlineData("O jogo precisa de pelo menos 3 opções.", new[] { "Rock", "Fire" })]
    [InlineData("", new[] { "Rock", "Fire", "Moon" })]
    public void Play_ShouldReturnCorrectRsesultInvalidInitialization(string message, string[] labels)
    {
        try
        {
            var game = new UltraGame(labels);
        }
        catch (ArgumentException ex)
        {
            Assert.Equal(message, ex.Message);
        }
    }

    [Theory]
    [InlineData(0, 2, GameResult.PlayerOne)]
    [InlineData(0, 14, GameResult.PlayerTwo)]
    [InlineData(1, 13, GameResult.PlayerTwo)]
    [InlineData(1, 1, GameResult.Odd)]
    [InlineData(15, 1, GameResult.InvalidMove)]
    public void Play_ShouldReturnCorrectResultForValidMoves(int pOneChoice, int pTwoChoice, GameResult gameResult)
    {
        var game = new UltraGame([
            "Rock", "Fire", "Scissors", "Snake", "Human", "Tree", "Wolf", "Sponge",
            "Paper", "Air", "Water", "Dragon", "Devil", "Lightning", "Gun"
        ]);

        var result = game.Play(pOneChoice, pTwoChoice);

        Assert.Equal(gameResult, result);
    }
}