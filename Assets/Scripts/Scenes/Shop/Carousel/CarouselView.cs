using System;
using UnityEngine;
using UnityEngine.UI;

public class CarouselView : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;

    public event Action OnNextClicked;
    public event Action OnPreviousClicked;

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(NextClicked);
        _previousButton.onClick.AddListener(PreviousClicked);
    }

    private void NextClicked()
    {
        OnNextClicked?.Invoke();
    }

    private void PreviousClicked()
    {
        OnPreviousClicked?.Invoke();
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(NextClicked);
        _previousButton.onClick.RemoveListener(PreviousClicked);
    }
}