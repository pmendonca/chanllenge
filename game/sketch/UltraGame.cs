using game.sketch.Enums;

namespace game.sketch;

public class UltraGame
{
    private readonly int _totalOptions;

    public UltraGame(string[] optionLabels)
    {
        if (optionLabels.Length < 3)
            throw new ArgumentException("O jogo precisa de pelo menos 3 opções.");

        _totalOptions = optionLabels.Length;
    }

    public GameResult Play(int playerOne, int playerTwo)
    {
        if (InvalidMove(playerOne, playerTwo))
            return GameResult.InvalidMove;

        if (playerOne == playerTwo)
            return GameResult.Odd;

        var half = _totalOptions / 2;
        var diff = (playerTwo - playerOne + _totalOptions) % _totalOptions;

        return diff <= half ? GameResult.PlayerOne : GameResult.PlayerTwo;
    }

    private bool InvalidMove(int playerOne, int playerTwo)
    {
        return !(
            playerOne >= 0
            && playerOne < _totalOptions
            && playerTwo >= 0
            && playerTwo < _totalOptions
        );
    }
}