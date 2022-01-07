using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class AttackSystemEnemy 
{
    private readonly List<Enemy> _enemies = new List<Enemy>();

    public bool IsEnemiesEnded => _enemies.Count == 0;

    public void Init(IEnumerable<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            AddEnemy(enemy);
        }
    }
    
    private void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        
        enemy.ONDie += RemoveEnemy;
    }

    private void RemoveEnemy(Character enemy)
    {
        enemy.ONDie -= RemoveEnemy;
        
        _enemies.Remove(enemy as Enemy);
    }
    
    public async UniTask Attack(Hero hero)
    {
        var enemy = _enemies.RandomItem();
        
        await enemy.Attack(hero);
    }
}