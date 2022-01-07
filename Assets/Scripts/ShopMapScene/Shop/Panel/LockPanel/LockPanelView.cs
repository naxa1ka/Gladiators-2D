using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class LockPanelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Button _unlockButton;
    
    private CanvasGroup _canvasGroup;

    public event Action OnUnlockButtonClicked;

    public void Open()
    {
        _canvasGroup.OpenWindow();
    }

    public void Close()
    {
        _canvasGroup.CloseWindow();
    }

    public void SetCostText(int cost)
    {
        _cost.text = cost.ToString();
    }
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    private void OnEnable()
    {
        _unlockButton.onClick.AddListener(UnlockButtonClicked);
    }

    private void UnlockButtonClicked()
    {
        OnUnlockButtonClicked?.Invoke();
    }
    
    private void OnDisable()
    {
        _unlockButton.onClick.AddListener(UnlockButtonClicked);
    }
}