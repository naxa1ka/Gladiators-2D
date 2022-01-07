using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] private EnemyChooser _enemyChooser;
    [Space(10)]
    [SerializeField] private EnemyInit _enemyInit;
    [SerializeField] private WaveSystemPresenter _waveSystemPresenter;
    
    private WaveSystem _waveSystem;
    private AttackSystemEnemy _attackSystemEnemy;

    [Inject]
    private void Constructor(Wave wave)
    {
        _waveSystem = new WaveSystem(wave);
        _attackSystemEnemy = new AttackSystemEnemy();
        
        _waveSystemPresenter.Init(_waveSystem);
        _enemyInit.Init(_waveSystem, _attackSystemEnemy);
    }

    public async UniTask Attack(Hero hero)
    {
        await _attackSystemEnemy.Attack(hero);
    }

    public async UniTask<Enemy> ChooseEnemy()
    {
        var chooseEnemy = await _enemyChooser.ChooseEnemy();
        return chooseEnemy as Enemy;
    }

    public async UniTask Init()
    {
        await _enemyInit.Init();
    }

    public void Disable()
    {
        _enemyChooser.Disable();
    }

    public async UniTask<bool> IsExistsEnemyMoves()
    {
        if (!_attackSystemEnemy.IsEnemiesEnded) return true;

        if (_waveSystem.HasMoreNext)
        {
            await Init();
            return true;
        }

        return false;
    }
}