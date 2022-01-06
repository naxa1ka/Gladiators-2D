using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private LosePanelView _losePanelView;
    [SerializeField] private SimpleLoaderScene _loaderScene;

    private MoneyHandler _moneyHandler;
    private LevelSaver _levelSaver;
    private const int ReviveCost = 250;

    [Inject]
    private void Constructor(MoneyHandler moneyHandler, LevelSaver levelSaver)
    {
        _levelSaver = levelSaver;
        _moneyHandler = moneyHandler;
    }

    public async UniTask<bool> OpenWithReviveResult()
    {
        if (_moneyHandler.Money >= ReviveCost)
        {
            _losePanelView.Open(ReviveCost);
        }
        else
        {
            _losePanelView.OpenWithoutBuying(ReviveCost);
        }

        return await IsReviveResult();
    }

    public async UniTask<bool> OpenWithoutReviving()
    {
        _losePanelView.OpenWithoutReviving(ReviveCost);

        return await IsReviveResult();
    }

    private async UniTask<bool> IsReviveResult()
    {
        var taskResult = await UniTask.WhenAny(
            _losePanelView.ContinueClickTask,
            _losePanelView.BuyReviveClickTask,
            _losePanelView.VideoReviveClickTask
        );

        switch (taskResult)
        {
            case 0:
                Continue();
                break;
            case 1:
                BuyRevive();
                break;
            case 2:
                VideoRevive();
                break;
        }

        return taskResult != 0;
    }

    private void Continue()
    {
        _levelSaver.SaveState(LevelState.Star0);

        _loaderScene.Load(ScenesID.MapAndShop);
    }

    private void BuyRevive()
    {
        _moneyHandler.TryBuy(ReviveCost);
    }

    private void VideoRevive()
    {
    }
}