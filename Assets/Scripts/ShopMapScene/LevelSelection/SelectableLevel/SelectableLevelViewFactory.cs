using System;
using UnityEngine;

public class SelectableLevelViewFactory : MonoBehaviour
{
    [SerializeField] private Sprite _lvl0Star;
    [SerializeField] private Sprite _lvl1Star;
    [SerializeField] private Sprite _lvl2Star;
    [SerializeField] private Sprite _lvl3Star;
    [SerializeField] private Sprite _lvlAvailable;
    [SerializeField] private Sprite _lvlLocked;

    public Sprite Get(LevelResult levelResult)
    {
        return levelResult switch
        {
            LevelResult.LevelAvailable => _lvlAvailable,
            LevelResult.Star0 => _lvl0Star,
            LevelResult.Start1 => _lvl1Star,
            LevelResult.Start2 => _lvl2Star,
            LevelResult.Start3 => _lvl3Star,
            LevelResult.LevelLocked => _lvlLocked,
            _ => throw new ArgumentOutOfRangeException(nameof(levelResult), levelResult, null)
        };
    }
}