public class LevelSaver
{
    private readonly ISaver _saver;
    private readonly Level _level;

    public LevelSaver(ISaver saver, Level level)
    {
        _level = level;
        _saver = saver;
    }

    public void SaveState(LevelState levelState)
    {
        _level.LevelState = levelState;
        _saver.Save(_level);
    }
}