using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void EnableInteractable()
    {
        _button.interactable = true;
    }

    public void DisableInteractable()
    {
        _button.interactable = false;
    }

    public async UniTask WaitForButtonPress()
    {
        await _button.OnClickAsync();
    }
}