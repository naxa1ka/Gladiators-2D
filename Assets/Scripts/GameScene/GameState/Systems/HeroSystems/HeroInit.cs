using Cysharp.Threading.Tasks;
using UnityEngine;

public class HeroInit : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [Space(10)]
    [SerializeField] private Transform _spawnPoint;

    public async UniTask<Hero> Init(Champion champion)
    {
        var hero = champion.Prefab;
        
        var spawnedHero = Instantiate(hero, _spawnPoint.position, Quaternion.identity);
        spawnedHero.Init(champion.Health.CurrentValue, champion.Damage.CurrentValue);
        
        await spawnedHero.Opening();

        _healthBar.Init(spawnedHero);

        return spawnedHero;
    }
}