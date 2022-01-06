using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Open);
        _closeButton.onClick.AddListener(Close);
    }

    private void Open()
    {
        _shop.Open();
    }

    private void Close()
    {
        _shop.Close();
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Open);
        _closeButton.onClick.RemoveListener(Close);
    }
}