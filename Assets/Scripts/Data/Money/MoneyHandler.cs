using System;
using UnityEngine;

public class MoneyHandler 
{
    private int _money;
    private const string Key = "Money";

    public int Money => _money;

    public event Action<int> OnMoneyChanged;

    public MoneyHandler()
    {
        _money = PlayerPrefs.GetInt(Key);
    }

    public void AddMoney(int amount)
    {
        _money += amount;

        MoneyChanged();
    }

    public bool TryBuy(int amount)
    {
        if (amount > _money) return false;

        _money -= amount;
        
        MoneyChanged();

        return true;
    }

    private void MoneyChanged()
    {
        OnMoneyChanged?.Invoke(_money);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(Key, _money);
        PlayerPrefs.Save();
    }
}