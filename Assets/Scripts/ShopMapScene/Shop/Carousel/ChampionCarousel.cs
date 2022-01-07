using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChampionCarousel : MonoBehaviour
{
    [SerializeField] private CarouselView _carouselView;

    private CarouselPresenter<Champion> _carousel;
    
    private IReadOnlyList<Champion> _champions;
    private Champion _lastChampion;

    public event Action<Champion> OnRedraw;

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider)
    {
        _champions = championsDataProvider.Champions;
        
        _carousel = new CarouselPresenter<Champion>(_carouselView, new Carousel<Champion>(_champions));
        
        _lastChampion = _champions[0];
    }

    private void OnEnable()
    {
        _carousel.Enable();
        _carousel.OnItemChanged += ItemChanged;
    }

    private void ItemChanged(Champion champion)
    {
        _lastChampion = champion;
        Redraw();
    }

    public void Redraw()
    {
        OnRedraw?.Invoke(_lastChampion);
    }

    private void OnDisable()
    {
        _carousel.Disable();
        _carousel.OnItemChanged -= ItemChanged;
    }
}