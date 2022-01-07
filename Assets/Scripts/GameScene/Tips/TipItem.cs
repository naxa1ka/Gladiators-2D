using UnityEngine;
using UnityEngine.UI;

public class TipItem : MonoBehaviour
{
    [TextArea] [SerializeField] private string _description;
    [SerializeField] private Button _button;
    [SerializeField] private TipPanelView _tipPanelView;

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowText);
    }

    private void ShowText()
    {
        _tipPanelView.UpdateText(_description);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowText);
    }
}