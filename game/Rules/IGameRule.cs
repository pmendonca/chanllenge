using game.sketch.Enums;

namespace game.Rules;

public interface IGameRule
{
    GameResult DetermineWinner(int playerOne, int playerTwo, int totalOptions);
}