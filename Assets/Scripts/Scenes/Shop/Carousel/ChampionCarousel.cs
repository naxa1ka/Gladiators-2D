using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChampionCarousel : MonoBehaviour
{
    [SerializeField] private CarouselView _carouselView;

    private CarouselPresenter<Champion> _carouselPresenter;
    
    private IReadOnlyList<Champion> _champions;
    private Champion _lastChampion;

    private ChosenChampionsProvider _chosenChampionsProvider;
    public ChosenChampionsProvider ChosenChampionsProvider => _chosenChampionsProvider;

    public event Action<Champion> OnRedraw;

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider)
    {
        var initIndex = 0;

        _chosenChampionsProvider = championsDataProvider.ChosenChampionsProvider;
        _champions = championsDataProvider.Champions;
        
        _carouselPresenter = new CarouselPresenter<Champion>(_carouselView, new Carousel<Champion>(_champions, initIndex));
        
        _lastChampion = _champions[initIndex];
    }

    private void OnEnable()
    {
        _carouselPresenter.Enable();
        _carouselPresenter.OnItemChanged += ItemChanged;
    }

    private void ItemChanged(Champion champion)
    {
        _lastChampion = champion;
        OnRedraw?.Invoke(champion);
    }

    public void Redraw()
    {
        OnRedraw?.Invoke(_lastChampion);
    }

    private void OnDisable()
    {
        _carouselPresenter.Disable();
        _carouselPresenter.OnItemChanged -= ItemChanged;
    }
}