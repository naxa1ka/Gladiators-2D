using UnityEngine;
using UnityEngine.UI;

public class PreviewHero :  MonoBehaviour
{
    [SerializeField] private Sprite _deactivated;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Activate(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void Deactivate()
    {
        _image.sprite = _deactivated;
    }
}