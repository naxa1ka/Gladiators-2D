using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    
    private CanvasGroup _canvasGroup;

    public event Action OnOpenButton;
    public event Action OnCloseButton;
    
    private void Awake()
    {
         _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Opened);
        _closeButton.onClick.AddListener(Closed);
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
    }
}