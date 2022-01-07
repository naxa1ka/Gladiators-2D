using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopSaver : MonoBehaviour
{
    [SerializeField] private ShopView _shopView;
 
    private readonly List<ISaveable> _saveables = new List<ISaveable>();
    private ISaver _saver;

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider, ISaver saver)
    {
        _saver = saver;
        _saveables.AddRange(championsDataProvider.Champions);
    }

    private void OnEnable()
    {
        _shopView.OnOpen += Load;
        _shopView.OnClose += Save;
    }

    private void Start()
    {
        Load();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        foreach (var saveable in _saveables)
        {
            if (_saver.IsFileExist(saveable))
            {
                _saver.Load(saveable);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        foreach (var saveable in _saveables)
        {
            _saver.Save(saveable);
        }
    }

    private void OnDisable()
    {
        _shopView.OnOpen -= Load;
        _shopView.OnClose -= Save;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}