using TMPro;
using UnityEngine;

public class TipPanelView : OpenCloseWindow
{
    [TextArea] [SerializeField] private string _defaultDescription;
    [SerializeField] private TextMeshProUGUI _description;

    private void OnEnable()
    {
        Enable();
    }

    private void Start()
    {
        UpdateText(_defaultDescription);
    }
    
    public void UpdateText(string text)
    {
        _description.text = text;
    }

    private void OnDisable()
    {
        Disable();
    }
}