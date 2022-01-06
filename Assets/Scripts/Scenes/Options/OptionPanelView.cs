using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanelView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _canvasGroup;

    public event Action OnOpenButton;
    public event Action OnCloseButton;
    public event Action OnExitButton;
    public event Action OnRestartButton;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Opened);
        _closeButton.onClick.AddListener(Closed);
        _exitButton.onClick.AddListener(Exit);
        _restartButton.onClick.AddListener(Restart);
    }

    private void Opened()
    {
        OnOpenButton?.Invoke();
        Open();
    }

    private void Closed()
    {
        OnCloseButton?.Invoke();
        Close();
    }

    private void Exit()
    {
        OnExitButton?.Invoke();
    }

    private void Restart()
    {
        OnRestartButton?.Invoke();
    }

    private void Open()
    {
        _canvasGroup.OpenWindow();
    }

    private void Close()
    {
        _canvasGroup.CloseWindow();
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Opened);
        _closeButton.onClick.RemoveListener(Closed);
        _exitButton.onClick.RemoveListener(Exit);
        _restartButton.onClick.RemoveListener(Restart);
    }
}