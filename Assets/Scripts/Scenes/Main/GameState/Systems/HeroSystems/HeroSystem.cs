using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class HeroSystem : MonoBehaviour
{
    [SerializeField] private HeroChooser _heroChooser;
    [SerializeField] private HeroInit _heroInit;

    private readonly AttackSystemHero _attackSystemHero = new AttackSystemHero();
    private IReadOnlyList<Champion> _champions;

    public Hero CurrentHero => _attackSystemHero.Hero;
    public bool CanChooseNewHero => !_attackSystemHero.IsHeroesEnded;
    public bool IsHeroAlive => _attackSystemHero.IsHeroAlive;

    public void Init(IReadOnlyList<Champion> champions)
    {
        _champions = champions;

        _attackSystemHero.Constructor(_champions.Count);
        _heroChooser.Constructor(_champions);
    }

    public async UniTask Choose()
    {
        var chooseChampion = await _heroChooser.ChooseHero();

        var spawnedHero = await _heroInit.Init(chooseChampion);
        
        _attackSystemHero.Init(spawnedHero);
    }

    public async UniTask Attack(Enemy enemy)
    {
        await _attackSystemHero.Attack(enemy);
    }

    public void SetNextAction(ElementType elementType)
    {
        _attackSystemHero.SetNextAction(elementType);
    }
}