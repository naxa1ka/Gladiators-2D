using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    [SerializeField] private MainPanelView _mainPanelView;
    
    private void OnEnable()
    {
        _championCarousel.OnRedraw += OnRedraw;
    }

    private void OnRedraw(Champion champion)
    {
        var championView = champion.ChampionView;
        _mainPanelView.Set(championView.Name, championView.Logo);
    }

    private void OnDisable()
    {
        _championCarousel.OnRedraw -= OnRedraw;
    }
}