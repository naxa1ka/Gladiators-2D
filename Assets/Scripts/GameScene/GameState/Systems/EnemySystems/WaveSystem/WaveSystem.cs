using System;

public class WaveSystem
{
    private readonly Wave _wave;
    private int _currentWave;

    public bool HasMoreNext => _currentWave != WaveSettings.WavesAmount;

    public event Action<int> ONSpawnWave;

    public WaveSystem(Wave wave)
    {
        _wave = wave;
    }

    public EnemyWithCharacterstics[] Spawn()
    {
        var spawnedEnemy = SpawnEnemy();

        ONSpawnWave?.Invoke(_currentWave);
        _currentWave++;

        return spawnedEnemy;
    }

    private EnemyWithCharacterstics[] SpawnEnemy()
    {
        EnemyWithCharacterstics[] spawnedEnemy = new EnemyWithCharacterstics[WaveSettings.WaveSize];
        
        for (var i = 0; i < spawnedEnemy.Length; i++)
        {
            spawnedEnemy[i] = _wave[_currentWave, i];
        }

        return spawnedEnemy;
    }
}