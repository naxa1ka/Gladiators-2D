using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private OptionPanelView _optionPanelView;
    [SerializeField] private SimpleLoaderScene _loaderScene;
    [SerializeField] private Reloader _reloader;

    private void OnEnable()
    {
        _optionPanelView.OnOpen += Open;
        _optionPanelView.OnClose += Close;
        _optionPanelView.OnExit += Exit;
        _optionPanelView.OnRestart += Restart;
    }

    private void Restart()
    {
        _reloader.ReloadScene();
    }

    private void Open()
    {
        TimeState.Stop();
    }

    private void Close()
    {
        TimeState.Resume();
    }

    private void Exit()
    {
        _loaderScene.Load(ScenesID.MapAndShop);
    }

    private void OnDisable()
    {
        _optionPanelView.OnOpen -= Open;
        _optionPanelView.OnClose -= Close;
        _optionPanelView.OnExit -= Exit;
        _optionPanelView.OnRestart -= Restart;
    }
}