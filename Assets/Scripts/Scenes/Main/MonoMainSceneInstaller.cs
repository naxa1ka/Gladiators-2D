using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MonoMainSceneInstaller : MonoBehaviour
{
    [SerializeField] private HeroSystem _heroSystem;
    [SerializeField] private GameCycle _gameCycle ;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private BackgroundLevelSetter _backgroundLevelSetter;
    
    private IReadOnlyList<Champion> _champions;
    private Level _level;

    [Inject]
    private void Constructor(IReadOnlyList<Champion> champions, Level level)
    {
        _level = level;
        _champions = champions;
    }

    private async void Start()
    {
        _gameBoard.Init(_level.GameBoard);
        _heroSystem.Init(_champions);
        _backgroundLevelSetter.Init(_level.BackGround);
        
        await _gameCycle.Init();
    }
}