using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataView", menuName = "ScriptableObjects/LevelDataView", order = 1)]
public class LevelStateView : ScriptableObject
{
    [SerializeField] private Sprite _lvl0Star;
    [SerializeField] private Sprite _lvl1Star;
    [SerializeField] private Sprite _lvl2Star;
    [SerializeField] private Sprite _lvl3Star;
    [SerializeField] private Sprite _lvlAvailable;
    [SerializeField] private Sprite _lvlLocked;

    public Sprite Get(LevelState levelState)
    {
        return levelState switch
        {
            LevelState.LevelAvailable => _lvlAvailable,
            LevelState.Star0 => _lvl0Star,
            LevelState.Start1 => _lvl1Star,
            LevelState.Start2 => _lvl2Star,
            LevelState.Start3 => _lvl3Star,
            LevelState.LevelLocked => _lvlLocked,
            _ => throw new ArgumentOutOfRangeException(nameof(levelState), levelState, null)
        };
    }
}