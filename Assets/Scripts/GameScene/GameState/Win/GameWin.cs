using UnityEngine;
using Zenject;

public class GameWin : MonoBehaviour
{
    [SerializeField] private WinPanel _winPanel;
    
    private ILevelResultCalculator _levelResultCalculator;
    private MoneyHandler _moneyHandler;
    private LevelSaver _levelSaver;
    private Level _level;

    [Inject]
    private void Constructor(LevelSaver levelSaver, Level level, ILevelResultCalculator levelResultCalculator, MoneyHandler moneyHandler)
    {
        _level = level;
        _levelSaver = levelSaver;
        _moneyHandler = moneyHandler;
        _levelResultCalculator = levelResultCalculator;
    }
    
    public void Open()
    {
        var levelState = _levelResultCalculator.GetResult();
        var winCoins = _level.WinCoins;
        
        _winPanel.Open(levelState, winCoins);

        _moneyHandler.AddMoney(winCoins);
        _levelSaver.SaveState(levelState);
    }
}