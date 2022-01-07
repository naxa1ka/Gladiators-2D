using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class OpenCloseWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    
    public event Action OnOpen;
    public event Action OnClose;

    protected void Enable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    public void Open()
    {
        _canvasGroup.OpenWindow();
        OnOpen?.Invoke();
    }

    public void Close()
    {
        _canvasGroup.CloseWindow();
        OnClose?.Invoke();
    }

    protected void Disable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }
}