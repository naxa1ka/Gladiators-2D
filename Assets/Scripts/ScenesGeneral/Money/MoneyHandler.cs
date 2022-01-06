using System;
using UnityEngine;
using Zenject;

public class MoneyHandler : IInitializable
{
    private int _money;
    public int Money => _money;
    
    public event Action<int> OnMoneyChanged;

    private const string Key = "Money";

    public MoneyHandler()
    {
        _money = PlayerPrefs.GetInt(Key);
    }
    
    public void Initialize()
    {
        OnMoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int amount)
    {
        _money += amount;
        OnMoneyChanged?.Invoke(_money);
        
        Save();
    }

    public bool TryBuy(int amount)
    {
        if (amount > _money) return false;

        _money -= amount;
        OnMoneyChanged?.Invoke(_money);

        Save();
        
        return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(Key, _money);
        PlayerPrefs.Save();
    }
}