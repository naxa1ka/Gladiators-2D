using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Champion", menuName = "ScriptableObjects/Champions", order = 1)]
public class Champion : ScriptableObject, ISaveable
{
    [SerializeField] private Hero _prefab;
    [Space(10)] 
    [SerializeField] private ChampionView _championView;
    [Space(10)] 
    [SerializeField] private ChampionCharacteristics _championCharacteristics;

    public Hero Prefab => _prefab;
    public Characteristics Damage => _championCharacteristics.Damage;
    public Characteristics Health => _championCharacteristics.Health;
    public ChampionView ChampionView => _championView;

    public string GetFileName()
    {
        return Application.persistentDataPath + $"{_championView.Name}.so";
    }

    public object SaveableObject => _championCharacteristics;
}

[Serializable]
public class ChampionView
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _logo;
    [SerializeField] private CircleIcon _circleIcon;
    [SerializeField] private Lock _lock;

    public string Name => _name;
    public Sprite Logo => _logo;
    public CircleIcon CircleIcon => _circleIcon;
    public Lock Lock => _lock;
}

[Serializable]
public class CircleIcon
{
    [SerializeField] private Sprite _activated;
    [SerializeField] private Sprite _deactivated;

    public Sprite Activated => _activated;
    public Sprite Deactivated => _deactivated;
}

[Serializable]
public class Lock
{
    [SerializeField] private int _unlockingCost;
    [SerializeField] private bool _isUnlocked;

    public int UnlockingCost => _unlockingCost;
    public bool IsUnlocked => _isUnlocked;

    public void Unlock()
    {
        _isUnlocked = true;
    }
}

[Serializable]
public class ChampionCharacteristics
{
    [SerializeField] private Characteristics _damage;
    [SerializeField] private Characteristics _health;
    
    public Characteristics Damage => _damage;
    public Characteristics Health => _health;
}

[Serializable]
public class Characteristics
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private CostValue[] _values;

    public int CurrentLevel => _currentLevel;

    public int CurrentValue => _values[_currentLevel].Value;
    public int CurrentCost => _values[_currentLevel].Cost;
    public bool IsMaxLevel => _currentLevel == _values.Length - 1;

    public void Upgrade()
    {
        _currentLevel++;
    }
}

[Serializable]
public class CostValue
{
    [SerializeField] private int _value;
    [SerializeField] private int _cost;

    public int Value => _value;
    public int Cost => _cost;
}