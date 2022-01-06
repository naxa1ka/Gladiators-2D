using UnityEngine;
using UnityEngine.UI;

public class MainPanelView : MonoBehaviour
{
    [SerializeField] private MultipleTMPEditing _name;
    [SerializeField] private Image _heroLogo;

    public void Set(string heroName, Sprite heroLogo)
    {
        _name.text = heroName;
        _heroLogo.sprite = heroLogo;
    }
}