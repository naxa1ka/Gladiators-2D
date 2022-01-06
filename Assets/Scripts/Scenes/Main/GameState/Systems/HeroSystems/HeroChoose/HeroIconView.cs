using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HeroIconView : MonoBehaviour
{
    private Image _image;
    private Sprite _activated;
    private Sprite _deactivated;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Init(Sprite activated, Sprite deactivated)
    {
        _activated = activated;
        _deactivated = deactivated;
    }

    public void Activate()
    {
        _image.sprite = _activated;
    }

    public void Deactivate()
    {
        _image.sprite = _deactivated;
    }
}