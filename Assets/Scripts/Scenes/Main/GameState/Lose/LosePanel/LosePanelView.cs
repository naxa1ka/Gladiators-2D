using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class LosePanelView : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _watchVideoButton;
    [SerializeField] private Button _buyReviveButton;
    [Space(10)] 
    [SerializeField] private TextMeshProUGUI _reviveCostText;

    private CanvasGroup _canvasGroup;
    
    public UniTask ContinueClickTask => _continueButton.OnClickAsync();
    public UniTask VideoReviveClickTask => _watchVideoButton.OnClickAsync();
    public UniTask BuyReviveClickTask => _buyReviveButton.OnClickAsync();
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(Close);
        _watchVideoButton.onClick.AddListener(Close);
        _buyReviveButton.onClick.AddListener(Close);
    }
    
    public void OpenWithoutReviving(int reviveCost)
    {
        _watchVideoButton.interactable = false;
        _buyReviveButton.interactable = false;
        Open(reviveCost);
    }

    public void OpenWithoutBuying(int reviveCost)
    {
        _buyReviveButton.interactable = false;
        Open(reviveCost);
    }

    public void Open(int reviveCost)
    {
        _canvasGroup.OpenWindow();
        _reviveCostText.text = reviveCost.ToString();
    }
    
    private void Close()
    {
        _canvasGroup.CloseWindow();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(Close);
        _watchVideoButton.onClick.RemoveListener(Close);
        _buyReviveButton.onClick.RemoveListener(Close);
    }
}