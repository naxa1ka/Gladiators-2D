using UnityEngine;
using Zenject;

public class Store : MonoBehaviour
{
    [SerializeField] private StoreView _storeView;
    
    private MoneyHandler _moneyHandler;

    [Inject]
    private void Constructor(MoneyHandler moneyHandler)
    {
        _moneyHandler = moneyHandler;
    }
    
    private void OnEnable()
    {
        _storeView.OnOpen += OnOpen;
        _storeView.OnClose += OnClose;
    }

    private void OnOpen()
    {
        TimeState.Stop();
    }

    private void OnClose()
    {
        TimeState.Resume();
    }

    public void Buy(int amount)
    {
        _moneyHandler.AddMoney(amount);
    }
    
    private void OnDisable()
    {
        _storeView.OnOpen -= OnOpen;
        _storeView.OnClose -= OnClose;
    }
}