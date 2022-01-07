
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopView _shopView;
    [SerializeField] private ChampionCarousel _championCarousel;

    private void OnEnable()
    {
        _shopView.OnOpen += OnOpen;
    }

    private void OnOpen()
    {
        _championCarousel.Redraw();
    }

    private void OnDisable()
    {
        _shopView.OnOpen -= OnOpen;
    }
}