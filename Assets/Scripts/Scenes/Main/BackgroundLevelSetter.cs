using UnityEngine;
using UnityEngine.UI;

public class BackgroundLevelSetter : MonoBehaviour
{
    [SerializeField] private Image _backGround;

    public void Init(Sprite sprite)
    {
        _backGround.sprite = sprite;
    }
}