using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MoneyText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private MoneyHandler _moneyHandler;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    [Inject]
    private void Constructor(MoneyHandler moneyHandler)
    {
        _moneyHandler = moneyHandler;
    }

    private void OnEnable()
    {
        _moneyHandler.OnMoneyChanged += UpdateText;
    }

    private void Start()
    {
        UpdateText(_moneyHandler.Money);
    }

    private void UpdateText(int amount)
    {
        _text.text = amount.ToString();
    }

    private void OnDisable()
    {
        _moneyHandler.OnMoneyChanged -= UpdateText;
    }
}