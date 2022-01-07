using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject, ISaveable
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private Wave _wave;
    [SerializeField] private int _winCoins;
    [SerializeField] private ArrayLayout<ElementType> _gameBoard;
    [SerializeField] private Sprite _backGround;
    
    private readonly LevelSaveData _levelSaveData = new LevelSaveData();
    
    public LevelResult LevelResult
    {
        get => _levelSaveData._levelResult;
        set => _levelSaveData._levelResult = value;
    }
    public Wave Wave => _wave;
    public int WinCoins => _winCoins;
    public ArrayLayout<ElementType> GameBoard => _gameBoard;
    public Sprite BackGround => _backGround;
    
    public string GetFileName()
    {
        return Application.persistentDataPath + $"level{_levelNumber}.so";
    }

    public object SaveableObject => _levelSaveData;

    [ContextMenu("Generate")]
    public void GenerateRandomLayout()
    {
        for (var i = 0; i < _gameBoard.rows.Length; i++)
        {
            for (var j = 0; j < _gameBoard.rows[i].row.Length; j++)
            {
                _gameBoard[i, j] = ElementsFactory.GetRandomElementType();
            }
        }
    }
}

[Serializable]
public class LevelSaveData
{
    public LevelResult _levelResult = LevelResult.LevelAvailable;
}