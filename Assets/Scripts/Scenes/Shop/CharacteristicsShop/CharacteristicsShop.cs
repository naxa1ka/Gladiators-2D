using UnityEngine;
using Zenject;

public class CharacteristicsShop : MonoBehaviour
{
    [SerializeField] private CharacteristicsView _damage;
    [SerializeField] private CharacteristicsView _health;
    [Space(10)] 
    [SerializeField] private ChampionCarousel _championsCarousel;

    private Champion _currentChampion;
    private MoneyHandler _moneyHandler;

    [Inject]
    private void Constructor(MoneyHandler moneyHandler)
    {
        _moneyHandler = moneyHandler;
    }
    
    private void OnEnable()
    {
        _championsCarousel.OnRedraw += Redraw;
        _damage.OnUpgradeClicked += DamageUpgrade;
        _health.OnUpgradeClicked += HealthUpgrade;
    }

    private void HealthUpgrade()
    {
        if (_moneyHandler.TryBuy(_currentChampion.Health.CurrentCost))
        {
            _currentChampion.Health.Upgrade();
            DrawCharacteristics(_health, _currentChampion.Health);
        }
    }

    private void DamageUpgrade()
    {
        if (_moneyHandler.TryBuy(_currentChampion.Damage.CurrentCost))
        {
            _currentChampion.Damage.Upgrade();
            DrawCharacteristics(_damage, _currentChampion.Damage);
        }
    }

    private void Redraw(Champion champion)
    {
        _currentChampion = champion;
        
        DrawAllCharacteristics();
    }

    private void DrawAllCharacteristics()
    {
         DrawCharacteristics(_damage, _currentChampion.Damage);
         DrawCharacteristics(_health, _currentChampion.Health);
    }

    private void DrawCharacteristics(CharacteristicsView characteristicsView, Characteristics characteristics)
    {
         SetCharacteristicValue(characteristicsView, characteristics);
         SetInteractable(characteristicsView, characteristics);
         SetBars(characteristicsView, characteristics);
    }

    private void SetInteractable(CharacteristicsView characteristicsView, Characteristics characteristics)
    {
        var interactable = !characteristics.IsMaxLevel;
        
        if (interactable)
        {
            characteristicsView.EnableInteractable();
        }
        else
        {
            characteristicsView.DisableInteractable();
        }
    }

    private void SetCharacteristicValue(CharacteristicsView characteristicsView, Characteristics characteristics)
    {
        var currentValue = characteristics.CurrentValue;
        var currentCost = characteristics.CurrentCost;
        
        characteristicsView.DrawCharacteristicValue(currentValue, currentCost);
    }

    private void SetBars(CharacteristicsView characteristicsView, Characteristics characteristics)
    {
        characteristicsView.DrawBars(characteristics.CurrentLevel);
    }

    private void OnDisable()
    {
        _championsCarousel.OnRedraw -= Redraw;
        _damage.OnUpgradeClicked -= DamageUpgrade;
        _health.OnUpgradeClicked -= HealthUpgrade;
    }
}