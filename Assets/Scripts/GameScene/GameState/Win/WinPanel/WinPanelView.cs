using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelView : Window
{
    [SerializeField] private TextMeshProUGUI _coinsWin;
    [SerializeField] private Button _continueButton;
    [Space(10)]
    [SerializeField] private WinStarViewFactory _winStarViewFactory;
    [SerializeField] private Image _star;

    public event Action OnContinue;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        OnContinue?.Invoke();
        CloseWindow();
    }

    public void OpenWindow(LevelResult levelResult, int winCoins)
    {
        ShowStar(levelResult);
        ShowCoinsAmount(winCoins);
        OpenWindow();
    }

    private void ShowStar(LevelResult levelResult)
    {
        _star.sprite = _winStarViewFactory.Get(levelResult);
    }

    private void ShowCoinsAmount(int coins)
    {
        _coinsWin.text = coins.ToString();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(Continue);
    }
}