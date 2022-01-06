using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private OptionPanelView _optionPanelView;
    [SerializeField] private Reloader _reloader;
    [SerializeField] private SimpleLoaderScene _loaderScene;

    private void OnEnable()
    {
        _optionPanelView.OnOpenButton += Open;
        _optionPanelView.OnCloseButton += Close;
        _optionPanelView.OnExitButton += Exit;
        _optionPanelView.OnRestartButton += Restart;
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
        TimeState.Resume();
        _loaderScene.Load(ScenesID.MapAndShop);
    }

    private void OnDisable()
    {
        _optionPanelView.OnOpenButton -= Open;
        _optionPanelView.OnCloseButton -= Close;
        _optionPanelView.OnExitButton -= Exit;
        _optionPanelView.OnRestartButton -= Restart;
    }
}