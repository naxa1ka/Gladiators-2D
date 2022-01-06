using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class EnemyInit : MonoBehaviour
{
    [SerializeField] private EnemyChooser _enemyChooser;
    [Space(15)] 
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform[] _destinationPoints;

    private AttackSystemEnemy _attackSystemEnemy;
    private WaveSystem _waveSystem;

    private void OnValidate()
    {
        if (_destinationPoints.Length != WaveSettings.WaveSize)
        {
            throw new ArgumentException($"Count destination points must be {WaveSettings.WaveSize}!");
        }
    }
    
    public void Init(WaveSystem waveSystem, AttackSystemEnemy attackSystemEnemy)
    {
        _waveSystem = waveSystem;
        _attackSystemEnemy = attackSystemEnemy;
    }

    public async UniTask Init()
    {
        EnemyWithCharacterstics[] enemies = _waveSystem.Spawn();
        Enemy[] initedEnemies = new Enemy[enemies.Length];
        
        for (int i = 0; i < enemies.Length; i++)
        {
            initedEnemies[i] = Instantiate(enemies[i].Enemy, _spawnPoint.position, Quaternion.identity);
            initedEnemies[i].Init(enemies[i].Health, enemies[i].Damage);
            
            await initedEnemies[i].Move(_destinationPoints[i].position);
            
            initedEnemies[i].InitStartPosition();
        }
        
        _enemyChooser.Init(initedEnemies);
        _attackSystemEnemy.Init(initedEnemies);
    }
}