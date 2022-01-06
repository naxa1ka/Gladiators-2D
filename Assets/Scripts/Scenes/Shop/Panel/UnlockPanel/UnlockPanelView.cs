﻿using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UnlockPanelView : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _canvasGroup.OpenWindow();
    }

    public void Close()
    {
        _canvasGroup.CloseWindow();
    }
}