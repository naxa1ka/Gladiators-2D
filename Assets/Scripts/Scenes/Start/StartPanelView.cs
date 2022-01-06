using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;

    public event Action OnStartButtonClicked;
    public event Action OnCreditsButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartClicked);
        _creditsButton.onClick.AddListener(OnCreditsClicked);
    }

    private void OnStartClicked()
    {
        OnStartButtonClicked?.Invoke();
    }

    private void OnCreditsClicked()
    {
        OnCreditsButtonClicked?.Invoke();
    }

    private void OnDisable()
    {
        _startButton.onClick.AddListener(OnStartClicked);
        _creditsButton.onClick.AddListener(OnCreditsClicked);
    }
}