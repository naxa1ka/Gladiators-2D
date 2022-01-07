using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private LoaderSceneSelectedLevel _loaderSceneSelectedLevel;
    [SerializeField] private ShopView _shopView;
    
    private SelectableLevelButton[] _levelButtons;
    private ChosenChampionsDataProvider _chosenChampionsDataProvider;
    
    private Level _selectedLevel;

    private bool IsAvailableSceneLoading => _chosenChampionsDataProvider.ChosenChampions.Count > 0;
    
    [Inject]
    private void Constructor(ChosenChampionsDataProvider chosenChampionsDataProvider)
    {
        _chosenChampionsDataProvider = chosenChampionsDataProvider;
    }
    
    private void Awake()
    {
        _levelButtons = GetComponentsInChildren<SelectableLevelButton>();
    }

    private async void Start()
    {
        await CheckingSelectionResult();
    }

    private async UniTask CheckingSelectionResult()
    {
        _selectedLevel = await WaitingForLevelSelection();
        
        if (IsAvailableSceneLoading)
        {
            _loaderSceneSelectedLevel.Load(_selectedLevel);
        }
        else
        {
            FillChampions();
            await CheckingSelectionResult();
        }
    }

    private void FillChampions()
    {
        _shopView.Open();
    }

    private async UniTask<Level> WaitingForLevelSelection()
    {
        var tasks = _levelButtons.Select(levelButton => levelButton.LevelSelection());
        var result = await UniTask.WhenAny(tasks);
        
        return result.result;
    }
}