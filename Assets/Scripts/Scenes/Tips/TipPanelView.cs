using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class TipPanelView : MonoBehaviour
{
    [TextArea] [SerializeField] private string _defaultDescription;
    [SerializeField] private TextMeshProUGUI _description;
    [Space(10)] 
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(Opened);
        _closeButton.onClick.AddListener(Closed);
    }

    private void Start()
    {
        UpdateText(_defaultDescription);
    }

    private void Opened()
    {
        _canvasGroup.OpenWindow();
    }

    private void Closed()
    {
        _canvasGroup.CloseWindow();
    }

    public void UpdateText(string text)
    {
        _description.text = text;
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(Opened);
        _closeButton.onClick.RemoveListener(Closed);
    }
}