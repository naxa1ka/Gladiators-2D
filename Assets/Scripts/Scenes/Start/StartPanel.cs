using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private StartPanelView _startPanelView;
    [SerializeField] private SimpleLoaderScene _loaderScene;

    private const string HyperLink = "https://github.com/naxa1ka";

    private void OnEnable()
    {
        _startPanelView.OnStartButtonClicked += OnStartButtonClicked;
        _startPanelView.OnCreditsButtonClicked += OnCreditsButtonClicked;
    }

    private void OnCreditsButtonClicked()
    {
        Application.OpenURL(HyperLink);
    }

    private void OnStartButtonClicked()
    {
        _loaderScene.Load(ScenesID.MapAndShop);
    }

    private void OnDisable()
    {
        _startPanelView.OnStartButtonClicked -= OnStartButtonClicked;
        _startPanelView.OnCreditsButtonClicked -= OnCreditsButtonClicked;
    }
}