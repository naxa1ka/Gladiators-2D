using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanelView : OpenCloseWindow
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;

    public event Action OnExit;
    public event Action OnRestart;

    private void OnEnable()
    {
        Enable();
        
        _exitButton.onClick.AddListener(Exit);
        _restartButton.onClick.AddListener(Restart);
    }

    private void Exit()
    {
        OnExit?.Invoke();
    }

    private void Restart()
    {
        OnRestart?.Invoke();
    }

    private void OnDisable()
    {
        Disable();
        
        _exitButton.onClick.RemoveListener(Exit);
        _restartButton.onClick.RemoveListener(Restart);
    }
}