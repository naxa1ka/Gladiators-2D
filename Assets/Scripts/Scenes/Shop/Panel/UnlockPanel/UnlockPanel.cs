using UnityEngine;

public class UnlockPanel : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    [SerializeField] private UnlockPanelView _unlockPanelView;

    private void OnEnable()
    {
        _championCarousel.OnRedraw += OnRedraw;
    }

    private void OnRedraw(Champion champion)
    {
        var isUnlocked = champion.ChampionView.Lock.IsUnlocked;

        DrawPanel(isUnlocked);
    }

    private void DrawPanel(bool isUnlocked)
    {
        if (isUnlocked)
        {
            _unlockPanelView.Open();
        }
        else
        {
            _unlockPanelView.Close();
        }
    }

    private void OnDisable()
    {
        _championCarousel.OnRedraw -= OnRedraw;
    }
}