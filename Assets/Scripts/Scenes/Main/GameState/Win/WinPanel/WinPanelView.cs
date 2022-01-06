using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class StarViewDictionary
{
    public LevelState State;
    public Image Image;
}

[RequireComponent(typeof(CanvasGroup))]
public class WinPanelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsWin;
    [SerializeField] private Button _continueButton;
    [SerializeField] private StarViewDictionary[] _starViewDictionaries = new StarViewDictionary[StarsAmount];

    private CanvasGroup _canvasGroup;

    private const int StarsAmount = 4;

    public event Action OnContinue;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnValidate()
    {
        InitDictionary();

        if (_starViewDictionaries.Length != StarsAmount)
        {
            throw new ArgumentException($"Amount starts must be {StarsAmount}!");
        }
    }

    private void InitDictionary()
    {
        _starViewDictionaries[0].State = LevelState.Star0;
        _starViewDictionaries[1].State = LevelState.Start1;
        _starViewDictionaries[2].State = LevelState.Start2;
        _starViewDictionaries[3].State = LevelState.Start3;
    }

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        OnContinue?.Invoke();
        _canvasGroup.CloseWindow();
    }

    public void OpenWindow(LevelState levelState, int winCoins)
    {
        ShowStar(levelState);
        ShowCoinsAmount(winCoins);
        _canvasGroup.OpenWindow();
    }

    private void ShowStar(LevelState levelState)
    {
        foreach (var starView in _starViewDictionaries)
        {
            starView.Image.gameObject.SetActive(starView.State == levelState);
        }
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