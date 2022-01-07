using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LosePanelView : Window
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _watchVideoButton;
    [SerializeField] private Button _buyReviveButton;
    [Space(10)] 
    [SerializeField] private TextMeshProUGUI _reviveCostText;

    public UniTask ContinueClickTask => _continueButton.OnClickAsync();
    public UniTask VideoReviveClickTask => _watchVideoButton.OnClickAsync();
    public UniTask BuyReviveClickTask => _buyReviveButton.OnClickAsync();

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(CloseWindow);
        _watchVideoButton.onClick.AddListener(CloseWindow);
        _buyReviveButton.onClick.AddListener(CloseWindow);
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
        OpenWindow();
        _reviveCostText.text = reviveCost.ToString();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(CloseWindow);
        _watchVideoButton.onClick.RemoveListener(CloseWindow);
        _buyReviveButton.onClick.RemoveListener(CloseWindow);
    }
}