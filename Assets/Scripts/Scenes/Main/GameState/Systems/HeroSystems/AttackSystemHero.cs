using Cysharp.Threading.Tasks;
using UnityEngine;

public class AttackSystemHero
{
    private Hero _hero;
    private bool _isHeroAlive;
    private int _amountHeroes;

    public Hero Hero => _hero;
    public bool IsHeroAlive => _isHeroAlive;
    public bool IsHeroesEnded
    {
        get
        {
            Debug.Log(_amountHeroes);
            return _amountHeroes == 0;
        }
    }
    
    public void Constructor(int amountHeroes)
    {
        _amountHeroes = amountHeroes;
    }
    
    public void Init(Hero hero)
    {
        _hero = hero;
        _isHeroAlive = true;

        _hero.ONDie += OnDie;
    }

    public void SetNextAction(ElementType elementType)
    {
        _hero.SetNextAction(elementType);
    }
    
    public async UniTask Attack(Enemy enemy)
    {
        await _hero.Attack(enemy);
    }

    private void OnDie(Character character)
    {
        _isHeroAlive = false;
        _amountHeroes--;

        _hero.ONDie -= OnDie;
    }
}