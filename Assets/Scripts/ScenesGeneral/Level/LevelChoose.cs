using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelChoose : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Shop _shop;
    
    private LevelButton[] _levelButtons;
    private ChampionsDataProvider _championsDataProvider;
    
    private Level _levelResult;

    [Inject]
    private void Constructor(ChampionsDataProvider championsDataProvider)
    {
        _championsDataProvider = championsDataProvider;
    }
    
    private void Awake()
    {
        _levelButtons = GetComponentsInChildren<LevelButton>();
    }

    private async void Start()
    {
        await CheckClickResult();
    }

    private async UniTask CheckClickResult()
    {
        _levelResult = await WaitButtonPress();
        if (_championsDataProvider.ChosenChampions.Count > 0)
        {
            _levelLoader.Load(_levelResult);
        }
        else
        {
            _shop.Open();
            await CheckClickResult();
        }
    }

    private async UniTask<Level> WaitButtonPress()
    {
        var uniTasks = _levelButtons.Select(chooseButton => chooseButton.ChooseLevel());
        var valueTuple = await UniTask.WhenAny(uniTasks);
        
        return valueTuple.result;
    }
}