using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    [SerializeField] private Store _store;
    [Space(10)]
    [SerializeField] private int _moneyImpact;
    [SerializeField] private Button _buyButton;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(Buy);
    }

    private void Buy()
    {
       _store.Buy(_moneyImpact);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(Buy);
    }
}
