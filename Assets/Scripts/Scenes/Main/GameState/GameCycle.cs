using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private GameBoardElementsSelector _gameBoardElementsSelector;
    [Space(10)] 
    [SerializeField] private HeroSystem _heroSystem;
    [SerializeField] private EnemySystem _enemySystem;
    [Space(10)] 
    [SerializeField] private GameWin _gameWin;
    [SerializeField] private GameLose _gameLose;

    /// <summary>
    /// <para>Инициализация</para>
    /// Отключаем выбор врагов
    /// Выбираем героя и спавним его
    /// Спавним врагов и включаем выбор элементов для атаки
    /// </summary>
    public async UniTask Init()
    {
        _enemySystem.Disable();

        await _heroSystem.Choose();

        await _enemySystem.Init();

        await ChooseElementsToAttack();
    }

    /// <summary>
    /// Выбираем элементы
    /// </summary>
    private async UniTask ChooseElementsToAttack()
    {
        var selectingElements = await _gameBoardElementsSelector.SelectingElements();
        _heroSystem.SetNextAction(selectingElements.First().ElementType);
        
        await AttackEnemy();
    }

    /// <summary>
    /// <para>Ударяем врага</para>
    /// выбираем врага для атаки
    /// и ударяем выбранного врага
    /// </summary>
    private async UniTask AttackEnemy()
    {
        var enemy = await _enemySystem.ChooseEnemy(); 
        await _heroSystem.Attack(enemy); 

        await ValidationEnemy();
    }
    
    /// <summary>
    /// <para>Валидация врага</para>
    /// Если остались ходы у врага (система внутри сама
    /// проверит волны и при надобности заспавнит) - атакуем врага
    /// иначе мы выиграли 
    /// </summary>
    private async UniTask ValidationEnemy()
    {
        var isExistsEnemyMoves = await _enemySystem.IsExistsEnemyMoves();
        if (isExistsEnemyMoves)
        {
            await AttackHero();
        }
        else
        {
            _gameWin.Open();
        }
    }

    /// <summary>
    /// Враг ударяет героя
    /// </summary>
    private async UniTask AttackHero()
    {
        await _enemySystem.Attack(_heroSystem.CurrentHero);
        await ValidationHero();
    }
    
    /// <summary>
    /// <para>Валидация героя </para>
    /// если герой жив - играем дальше
    /// иначе если нового героя можно выбрать - выбираем нового
    /// иначе пробуем воскресить  
    /// </summary>
    private async UniTask ValidationHero()
    {
        if (_heroSystem.IsHeroAlive)
        {
            await ChooseElementsToAttack();
        }
        else
        {
            if (_heroSystem.CanChooseNewHero)
            {
                await NewHeroInit();
            }
            else
            {
                var isRevived = await _gameLose.Open();
                if (isRevived)
                {
                    await NewHeroInit();
                }
            }
        }
    }
    
    /// <summary>
    ///  Выбираем нового героя для игры 
    /// </summary>
    private async UniTask NewHeroInit()
    {
        await _heroSystem.Choose();
        await ChooseElementsToAttack();
    }
}