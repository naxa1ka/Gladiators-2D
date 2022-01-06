using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private WinPanelView _winPanelView;
    [SerializeField] private SimpleLoaderScene _loaderScene;

    private void OnEnable()
    {
        _winPanelView.OnContinue += Continue;
    }

    private void Continue()
    {
        _loaderScene.Load(ScenesID.MapAndShop);
    }

    public void Open(LevelState levelState, int winCoins)
    {
        _winPanelView.OpenWindow(levelState, winCoins);
    }

    private void OnDisable()
    {
        _winPanelView.OnContinue -= Continue;
    }
}