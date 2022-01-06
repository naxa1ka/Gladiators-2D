using TMPro;
using UnityEngine;

public class MultipleTMPEditing : MonoBehaviour
{
    [SerializeField] private string _text;

    public string text
    {
        set
        {
            _text = value;
            Print();
        }
    }
    
    private TextMeshProUGUI[] _textsMeshPro;
    
    private void Awake()
    {
        _textsMeshPro = GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Print()
    {
        foreach (var textMeshProUgui in _textsMeshPro)
        {
            textMeshProUgui.text = _text;
        }
    }
}
