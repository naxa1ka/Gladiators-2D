using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WaveBarView : MonoBehaviour
{
    [SerializeField] private Sprite _deactivatedSprite;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Deactivate()
    {
        _image.sprite = _deactivatedSprite;
    }
}