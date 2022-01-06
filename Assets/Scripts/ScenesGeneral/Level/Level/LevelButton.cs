using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ChooseButton))]
public class LevelButton : MonoBehaviour
{
    private Level _level;
    private ChooseButton _chooseButton;

    private void Awake()
    {
        _chooseButton = GetComponent<ChooseButton>();
    }

    public void Init(Level level)
    {
        _level = level;
    }

    public void EmptyInit()
    {
        _chooseButton.DisableInteractable();
    }

    public async UniTask<Level> ChooseLevel()
    {
        await _chooseButton.WaitPressingButton();

        return _level;
    }
}