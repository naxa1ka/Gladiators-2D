using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Waves")]
public class Wave : ScriptableObject
{
    [SerializeField] private SubWave[] _subWaves = new SubWave[WaveSettings.WavesAmount];
    public IReadOnlyList<SubWave> SubWaves => _subWaves;
    
    public EnemyWithCharacterstics this[int indexWave, int indexEnemy] => _subWaves[indexWave].Enemies[indexEnemy];
}

[Serializable]
public class SubWave
{
    [SerializeField] private EnemyWithCharacterstics[] _enemies = new EnemyWithCharacterstics[WaveSettings.WaveSize];
    public IReadOnlyList<EnemyWithCharacterstics> Enemies => _enemies;
}

[Serializable]
public class EnemyWithCharacterstics
{
    public Enemy Enemy;
    public float Health;
    public float Damage;
}