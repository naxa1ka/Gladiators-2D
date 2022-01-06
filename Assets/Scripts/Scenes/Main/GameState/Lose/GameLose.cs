using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameLose : MonoBehaviour
{
    [SerializeField] private Reviver _reviver;
    [SerializeField] private LosePanel _losePanel;

    public async UniTask<bool> Open()
    {
        if (_reviver.IsAlreadyRevived)
        {
            return await _losePanel.OpenWithoutReviving();
        }

        var isRevived = await _losePanel.OpenWithReviveResult();
        if (isRevived)
        {
            _reviver.Reinit();    
        }

        return isRevived;
    }
}