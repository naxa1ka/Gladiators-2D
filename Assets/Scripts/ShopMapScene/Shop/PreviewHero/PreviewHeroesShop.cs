using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PreviewHeroesShop : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    [SerializeField] private PreviewHeroesShopView _previewHeroesShopView;

    private Champion _currentChampion;
    private ChosenChampionsDataProvider _chosenChampionsDataProvider;

    private readonly List<Sprite> _previewHeroes = new List<Sprite>();

    private void OnEnable()
    {
        _championCarousel.OnRedraw += Redraw;
        _previewHeroesShopView.OnRemoveButtonClicked += RemoveFromGroup;
        _previewHeroesShopView.OnAddButtonClicked += AddToGroup;
    }

    [Inject]
    private void Constructor(ChosenChampionsDataProvider chosenChampionsDataProvider)
    {
        _chosenChampionsDataProvider = chosenChampionsDataProvider;
    }

    private void Redraw(Champion champion)
    {
        _currentChampion = champion;
        Draw();
    }

    private void RemoveFromGroup()
    {
        _chosenChampionsDataProvider.Remove(_currentChampion);
        Draw();
    }

    private void AddToGroup()
    {
        _chosenChampionsDataProvider.Add(_currentChampion);
        Draw();
    }

    private void Draw()
    {
        DrawCircles();
        DrawButton();
    }

    private void DrawCircles()
    {
        var championsCount = _chosenChampionsDataProvider.ChosenChampions.Count;

        _previewHeroes.Clear();
        for (var i = 0; i < championsCount; i++)
        {
            _previewHeroes.Add(_chosenChampionsDataProvider.ChosenChampions[i].ChampionView.CircleIcon.Activated);
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
        bool isAddedToGroup = _chosenChampionsDataProvider.ChosenChampions.Contains(_currentChampion);

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
        int emptyPlaces = ChampionChooseSettings.MAXCapacity - _chosenChampionsDataProvider.ChosenChampions.Count;
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