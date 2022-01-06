using System.Collections.Generic;
using UnityEngine;

public class LevelsDataProvider
{
    private const string Path = "Levels";

    private readonly Level[] _levels;
    public IReadOnlyList<Level> Levels => _levels;

    public LevelsDataProvider()
    {
        _levels = Resources.LoadAll<Level>(Path);

        Load();
    }

    private void Load()
    {
        ISaver saver = new JsonSaver();
        foreach (var level in _levels)
        {
            if (saver.IsFileExist(level))
            {
                saver.Load(level);
            }
        }
    }
}