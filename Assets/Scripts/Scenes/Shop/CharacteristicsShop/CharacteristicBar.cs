using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CharacteristicBar : MonoBehaviour
{
    [SerializeField] private Sprite _activatedBar;
    [SerializeField] private Sprite _deactivatedBar;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ActivateBar()
    {
        _image.sprite = _activatedBar;
    }
    
    public void DeactivateBar()
    {
        _image.sprite = _deactivatedBar;
    }
}