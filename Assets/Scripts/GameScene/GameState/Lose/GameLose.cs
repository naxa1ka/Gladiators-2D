using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameLose : MonoBehaviour
{
    [SerializeField] private HeroReviver _heroReviver;
    [SerializeField] private LosePanel _losePanel;

    public async UniTask<bool> Open()
    {
        if (_heroReviver.IsAlreadyRevived)
        {
            return await _losePanel.OpenWithoutReviving();
        }

        var isRevived = await _losePanel.OpenWithReviveResult();
        if (isRevived)
        {
            _heroReviver.Reinit();    
        }

        return isRevived;
    }
}