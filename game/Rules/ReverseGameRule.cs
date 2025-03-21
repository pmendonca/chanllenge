using game.sketch.Enums;

namespace game.Rules;

public class ReverseGameRule :IGameRule
{
    public GameResult DetermineWinner(int playerOne, int playerTwo, int totalOptions)
    {
        if (playerOne == playerTwo) return GameResult.Odd;

        var half = totalOptions / 2;
        var diff = (playerTwo - playerOne + totalOptions) % totalOptions;
        
        return diff > half ? GameResult.PlayerTwo : GameResult.PlayerOne;
    }
}