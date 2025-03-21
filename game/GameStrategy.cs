using game.Rules;

namespace game;

public static class GameFactory
{
    public static FinalGame CreateStandardGame(string[] options)
    {
        return new FinalGame(options, new GameRule());
    }

    public static FinalGame CreateCustomGame(string[] options, IGameRule rule)
    {
        return new FinalGame(options, rule);
    }
}