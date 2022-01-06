using System;
using UnityEngine;
using Zenject;

public class WaveSystemPresenter : MonoBehaviour, IDisposable
{
    [SerializeField] private WaveBarView[] _waveBarView;

    private WaveSystem _waveSystem;
    private WaveSystemView _waveSystemView;

    public void Init(WaveSystem waveSystem)
    {
        _waveSystem = waveSystem;
        _waveSystemView = new WaveSystemView(_waveBarView);
        
        _waveSystem.ONSpawnWave += OnSpawnWave;
    }

    private void OnSpawnWave(int waveIndex)
    {
        _waveSystemView.DeactivateBar(waveIndex);
    }
    
    public void Dispose()
    {
        _waveSystem.ONSpawnWave -= OnSpawnWave;
    }
}