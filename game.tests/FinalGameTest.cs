using game.Rules;
using game.sketch.Enums;

namespace game.tests;

public class FinalGameTest
{
    [Theory]
    [InlineData("O jogo precisa de pelo menos 3 opções.", new[] { "Rock", "Fire" })]
    [InlineData("", new[] { "Rock", "Paper", "Scissors" })]
    public void Play_ShouldHandleInvalidInitialization(string message, string[] options)
    {
        try
        {
            GameFactory.CreateStandardGame(options);
        }
        catch (ArgumentException ex)
        {
            Assert.Equal(message, ex.Message);
        }
    }

    [Theory]
    [InlineData(0, 1, GameResult.PlayerTwo)]
    public void UltraGameWithStrategy(int playerOne, int playerTwo, GameResult shouldResult)
    {
        var game = GameFactory.CreateStandardGame(["Rock", "Paper", "Scissors"]);
        var result = game.Play(playerOne, playerTwo);
        
        Assert.Equal(shouldResult, result);
    }

    [Theory]
    [InlineData(0, 1, GameResult.PlayerOne)]
    public void UltraGameWithStrategy2(int playerOne, int playerTwo, GameResult shouldResult)
    {
        var game = GameFactory.CreateCustomGame(["Rock", "Paper", "Scissors"], new ReverseGameRule());
        var result = game.Play(playerOne, playerTwo);
        
        Assert.Equal(shouldResult, result);
    }

    [Theory]
    [InlineData(0, 1, GameResult.PlayerTwo)]
    [InlineData(0, 14, GameResult.PlayerOne)]
    [InlineData(14, 14, GameResult.Odd)]
    public void UltraGameWithStrategy3(int playerOne, int playerTwo, GameResult shouldResult)
    {
        var game = GameFactory.CreateStandardGame([
            "Rock", "Fire", "Scissors", "Snake", "Human", "Tree", "Wolf", "Sponge",
            "Paper", "Air", "Water", "Dragon", "Devil", "Lightning", "Gun"
        ]);

        var result = game.Play(playerOne, playerTwo);

        Assert.Equal(shouldResult, result);
    }
}