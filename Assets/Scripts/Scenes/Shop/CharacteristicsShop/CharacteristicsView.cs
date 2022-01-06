using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacteristicsView : MonoBehaviour
{
    [SerializeField] private CharacteristicBar[] _characteristicBars;
    [SerializeField] private TextMeshProUGUI _textValue;
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private Button _button;

    private const byte EnabledButtonAlpha = 255;
    private const byte DisabledButtonAlpha = 125;
    public event Action OnUpgradeClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(UpgradeClicked);
    }

    public void DrawCharacteristicValue(int currentValue, int currentCost)
    {
        _textValue.text = currentValue.ToString();
        _textCost.text = currentCost.ToString();
    }

    public void DrawBars(int level)
    {
        foreach (var characteristicBar in _characteristicBars)
        {
            characteristicBar.DeactivateBar();
        }

        for (var i = 0; i < level; i++)
        {
            _characteristicBars[i].ActivateBar();
        }
    }

    public void EnableInteractable()
    {
        _button.interactable = true;
        SetTextCostAlpha(EnabledButtonAlpha);
    }

    public void DisableInteractable()
    {
        _button.interactable = false;
        SetTextCostAlpha(DisabledButtonAlpha);
    }

    private void SetTextCostAlpha(byte alpha)
    {
        var color = _textCost.color;
        _textCost.color = new Color32((byte)color.r, (byte)color.g, (byte)color.b, alpha);
    }

    private void UpgradeClicked()
    {
        OnUpgradeClicked?.Invoke();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UpgradeClicked);
    }
}