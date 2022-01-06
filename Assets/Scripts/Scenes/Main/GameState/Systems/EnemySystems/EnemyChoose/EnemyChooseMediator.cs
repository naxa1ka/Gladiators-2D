using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyChooseMediator : MonoBehaviour
{
    [SerializeField] private ChooseButton _chooseButton;
    [SerializeField] private HealthBar _healthBar;
    
    private Enemy _enemy;

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.ONDie += OnDie;

        _healthBar.Init(_enemy);

        Enable();
    }

    private void Enable()
    {
        _chooseButton.EnableInteractable();
    }

    private void OnDie(Character character)
    {
         Disable();
         _enemy.ONDie -= OnDie;
    }

    private void Disable()
    {
        _chooseButton.DisableInteractable();
    }

    public async UniTask<Enemy> ChooseEnemy()
    {
        await _chooseButton.WaitPressingButton();
        
        return _enemy;
    }
}