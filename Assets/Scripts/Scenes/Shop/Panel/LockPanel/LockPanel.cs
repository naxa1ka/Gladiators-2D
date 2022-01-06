using UnityEngine;

public class LockPanel : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    [SerializeField] private LockPanelView _lockPanelView;
    
    private Champion _currentChampion;

    private void OnEnable()
    {
        _championCarousel.OnRedraw += OnRedraw;
        _lockPanelView.OnUnlockButtonClicked += Unlock;
    }

    private void OnRedraw(Champion champion)
    {
        _currentChampion = champion;
        Draw();
    }

    private void Draw()
    {
        bool isUnlocked = _currentChampion.ChampionView.Lock.IsUnlocked;

        DrawPanel(isUnlocked);
        
        SetCostText(isUnlocked);
    }

    private void DrawPanel(bool isUnlocked)
    {
        if (isUnlocked)
        {
            _lockPanelView.Close();
        }
        else
        {
            _lockPanelView.Open();
        }
    }

    private void SetCostText(bool isUnlocked)
    {
        if (isUnlocked == false)
        {
            var costText = _currentChampion.ChampionView.Lock.UnlockingCost;
            _lockPanelView.SetCostText(costText);
        }
    }

    private void Unlock()
    {
        _currentChampion.ChampionView.Lock.Unlock();
        _championCarousel.Redraw();
    }

    private void OnDisable()
    {
        _championCarousel.OnRedraw -= OnRedraw;
        _lockPanelView.OnUnlockButtonClicked -= Unlock;
    }
}