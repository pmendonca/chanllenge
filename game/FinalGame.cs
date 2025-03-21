using game.Rules;
using game.sketch.Enums;

namespace game;

public class FinalGame
{
    private readonly int _totalOptions;
    private readonly IGameRule _rule;

    public FinalGame(string[] optionLabels, IGameRule rule)
    {
        if (optionLabels.Length < 3)
            throw new ArgumentException("O jogo precisa de pelo menos 3 opções.");

        _totalOptions = optionLabels.Length;
        _rule = rule;
    }

    public GameResult Play(int playerOne, int playerTwo)
    {
        return InvalidMove(playerOne, playerTwo)
            ? GameResult.InvalidMove
            : _rule.DetermineWinner(playerOne, playerTwo, _totalOptions);
    }

    private bool InvalidMove(int playerOne, int playerTwo)
    {
        return !(playerOne >= 0 && playerOne < _totalOptions &&
                 playerTwo >= 0 && playerTwo < _totalOptions);
    }
}