using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectableLevelView : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Init(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}