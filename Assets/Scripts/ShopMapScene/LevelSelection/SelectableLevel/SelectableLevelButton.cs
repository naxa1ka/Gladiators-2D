using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SelectButton))]
public class SelectableLevelButton : MonoBehaviour
{
    private Level _level;
    private SelectButton _selectButton;

    private void Awake()
    {
        _selectButton = GetComponent<SelectButton>();
    }

    public void Init(Level level)
    {
        _level = level;
    }

    public void EmptyInit()
    {
        _selectButton.DisableInteractable();
    }

    public async UniTask<Level> LevelSelection()
    {
        await _selectButton.WaitForButtonPress();

        return _level;
    }
}