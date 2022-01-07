using System.Collections.Generic;
using UnityEngine;

public class LevelsDataProvider
{
    private const string Path = "Levels";

    private readonly Level[] _levels;
    private readonly ISaver _saver;
    public IReadOnlyList<Level> Levels => _levels;

    public LevelsDataProvider(ISaver saver)
    {
        _levels = Resources.LoadAll<Level>(Path);

        _saver = saver;
        Load();
    }

    private void Load()
    {
        foreach (var level in _levels)
        {
            if (_saver.IsFileExist(level))
            {
                _saver.Load(level);
            }
        }
    }
}