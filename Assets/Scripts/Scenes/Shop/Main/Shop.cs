using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Shop : MonoBehaviour
{
    [SerializeField] private ChampionCarousel _championCarousel;
    
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _canvasGroup.OpenWindow();
        _championCarousel.Redraw();
    }

    public void Close()
    {
        _canvasGroup.CloseWindow();
    }
}