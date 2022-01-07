using System;
using UnityEngine;

public class WinStarViewFactory : MonoBehaviour
{
    [SerializeField] private Sprite _star0;
    [SerializeField] private Sprite _star1;
    [SerializeField] private Sprite _star2;
    [SerializeField] private Sprite _star3;

    public Sprite Get(LevelResult levelResult)
    {
        return levelResult switch
        {
            LevelResult.Star0 => _star0,
            LevelResult.Start1 => _star1,
            LevelResult.Start2 => _star2,
            LevelResult.Start3 => _star3,
            _ => throw new ArgumentOutOfRangeException(nameof(levelResult), levelResult, null)
        };
    }
}