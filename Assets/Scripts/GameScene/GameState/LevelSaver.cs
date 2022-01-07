public class LevelSaver
{
    private readonly ISaver _saver;
    private readonly Level _level;

    public LevelSaver(ISaver saver, Level level)
    {
        _level = level;
        _saver = saver;
    }

    public void SaveState(LevelResult levelResult)
    {
        _level.LevelResult = levelResult;
        _saver.Save(_level);
    }
}