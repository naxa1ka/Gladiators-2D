using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyChooseMediator : MonoBehaviour
{
    [SerializeField] private SelectButton _selectButton;
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
        _selectButton.EnableInteractable();
    }

    private void OnDie(Character character)
    {
         Disable();
         _enemy.ONDie -= OnDie;
    }

    private void Disable()
    {
        _selectButton.DisableInteractable();
    }

    public async UniTask<Enemy> ChooseEnemy()
    {
        await _selectButton.WaitForButtonPress();
        
        return _enemy;
    }
}