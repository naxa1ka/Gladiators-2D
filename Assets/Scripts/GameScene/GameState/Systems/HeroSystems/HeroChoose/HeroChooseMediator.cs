using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(HeroIconView))]
[RequireComponent(typeof(SelectButton))]
public class HeroChooseMediator : MonoBehaviour
{
    private SelectButton _selectButton;
    private HeroIconView _heroIconView;
    private Champion _champion;

    private void Awake()
    {
        _heroIconView = GetComponent<HeroIconView>();
        _selectButton = GetComponent<SelectButton>();
    }

    public void Init(Champion champion)
    {
        _champion = champion;
        
        var circleIcon = champion.ChampionView.CircleIcon;
        
        _heroIconView.Init(circleIcon.Activated, circleIcon.Deactivated);
        
        _selectButton.EnableInteractable();
        _heroIconView.Activate();
    }

    public void NullInit()
    {
        _selectButton.DisableInteractable();
    }
    
    public async UniTask<Champion> ChooseHero()
    {
        await _selectButton.WaitForButtonPress();
        
        _selectButton.DisableInteractable();
        _heroIconView.Deactivate();
        
        return _champion;
    }
}