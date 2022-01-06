using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopSaver : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _openButton;

    private readonly List<ISaveable> _saveables = new List<ISaveable>();
    private readonly ISaver _saver = new JsonSaver();

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider)
    {
        _saveables.AddRange(championsDataProvider.Champions);
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(Save);
        _openButton.onClick.AddListener(Load);
    }

    private void Start()
    {
         Load();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        foreach (var saveable in _saveables)
        {
            _saver.Save(saveable);
        }
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

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Save);
        _openButton.onClick.RemoveListener(Load);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}