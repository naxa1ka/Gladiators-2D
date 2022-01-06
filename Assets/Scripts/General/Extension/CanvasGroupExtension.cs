using UnityEngine;

public static class CanvasGroupExtension
{
    public static void CloseWindow(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public static void OpenWindow(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    
    public static void EnableInteractable(this CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = true;
    }
    
    public static void DisableInteractable(this CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
    }
}