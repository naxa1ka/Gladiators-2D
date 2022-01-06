using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PreviewHeroesShop : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    [SerializeField] private PreviewHeroesShopView _previewHeroesShopView;
    
    private Champion _currentChampion;
    private ChosenChampionsProvider _chosenChampionsProvider;

    private readonly List<Sprite> _previewHeroes = new List<Sprite>();

    private void OnEnable()
    {
        _championCarousel.OnRedraw += Redraw;
        _previewHeroesShopView.OnRemoveButtonClicked += RemoveFromGroup;
        _previewHeroesShopView.OnAddButtonClicked += AddToGroup;
    }

    private void Start()
    {
        _chosenChampionsProvider = _championCarousel.ChosenChampionsProvider;
    }
    
    private void Redraw(Champion champion)
    {
        _currentChampion = champion;
        Draw();
    }

    private void RemoveFromGroup()
    {
        _chosenChampionsProvider.Remove(_currentChampion);
        Draw();
    }

    private void AddToGroup()
    {
        _chosenChampionsProvider.Add(_currentChampion);
        Draw();
    }

    private void Draw()
    {
        DrawCircles();
        DrawButton();
    }

    private void DrawCircles()
    {
        var championsCount = _chosenChampionsProvider.ChosenChampions.Count;
        
        _previewHeroes.Clear();
        for (var i = 0; i < championsCount; i++)
        {
            _previewHeroes.Add(_chosenChampionsProvider.ChosenChampions[i].ChampionView.CircleIcon.Activated);
        }

        _previewHeroesShopView.DrawPreviewHeroes(_previewHeroes);
    }

    private void DrawButton()
    {
        ShowStateButton();

        SetInteractable();
    }

    private void ShowStateButton()
    {
        bool isAddedToGroup = _chosenChampionsProvider.ChosenChampions.Contains(_currentChampion);

        if (isAddedToGroup)
        {
            _previewHeroesShopView.ShowRemoveButton();
        }
        else
        {
            _previewHeroesShopView.ShowAddButton();
        }
    }

    private void SetInteractable()
    {
        int emptyPlaces = ChampionSettings.MAXCapacity - _chosenChampionsProvider.ChosenChampions.Count;
        bool isContainsEmptyPlaces = emptyPlaces >= 0;

        if (isContainsEmptyPlaces)
        {
            _previewHeroesShopView.EnableInteractable();
        }
        else
        {
            _previewHeroesShopView.DisableInteractable();
        }
    }


    private void OnDisable()
    {
        _championCarousel.OnRedraw -= Redraw;
        _previewHeroesShopView.OnRemoveButtonClicked -= RemoveFromGroup;
        _previewHeroesShopView.OnAddButtonClicked -= AddToGroup;
    }
}