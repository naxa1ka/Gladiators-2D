using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void OpenWindow()
    {
        _canvasGroup.OpenWindow();
    }

    public void CloseWindow()
    {
        _canvasGroup.CloseWindow();
    }
}