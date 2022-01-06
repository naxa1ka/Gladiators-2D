using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(HeroIconView))]
[RequireComponent(typeof(ChooseButton))]
public class HeroChooseMediator : MonoBehaviour
{
    private ChooseButton _chooseButton;
    private HeroIconView _heroIconView;
    private Champion _champion;

    private void Awake()
    {
        _heroIconView = GetComponent<HeroIconView>();
        _chooseButton = GetComponent<ChooseButton>();
    }

    public void Init(Champion champion)
    {
        _champion = champion;
        
        var circleIcon = champion.ChampionView.CircleIcon;
        
        _heroIconView.Init(circleIcon.Activated, circleIcon.Deactivated);
        
        _chooseButton.EnableInteractable();
        _heroIconView.Activate();
    }

    public void NullInit()
    {
        _chooseButton.DisableInteractable();
    }
    
    public async UniTask<Champion> ChooseHero()
    {
        await _chooseButton.WaitPressingButton();
        
        _chooseButton.DisableInteractable();
        _heroIconView.Deactivate();
        
        return _champion;
    }
}