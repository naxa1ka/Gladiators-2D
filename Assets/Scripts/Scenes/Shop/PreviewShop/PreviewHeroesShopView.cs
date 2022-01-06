using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewHeroesShopView : MonoBehaviour
{
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;
    [Space(10)] 
    [SerializeField] private List<PreviewHero> _previewHeroes;

    public event Action OnAddButtonClicked;
    public event Action OnRemoveButtonClicked;

    private void OnEnable()
    {
        _removeButton.onClick.AddListener(RemoveButtonClicked);
        _addButton.onClick.AddListener(AddButtonClicked);
    }

    private void RemoveButtonClicked() => OnRemoveButtonClicked?.Invoke();
    private void AddButtonClicked() => OnAddButtonClicked?.Invoke();
    
    public void DrawPreviewHeroes(IEnumerable<Sprite> previewHeroes)
    {
        foreach (var previewHero in _previewHeroes)
        {
            previewHero.Deactivate();
        }

        var index = 0;
        foreach (var previewHero in previewHeroes)
        {
            _previewHeroes[index].Activate(previewHero);
            index++;
        }
    }

    public void EnableInteractable()
    {
        _addButton.interactable = true;
    }

    public void DisableInteractable()
    {
        _addButton.interactable = false;
    }
    
    public void ShowAddButton()
    {
        _addButton.gameObject.SetActive(true);
        _removeButton.gameObject.SetActive(false);
    }
    
    public void ShowRemoveButton()
    {
        _removeButton.gameObject.SetActive(true);
        _addButton.gameObject.SetActive(false);
    }
    
    private void OnDisable()
    {
        _removeButton.onClick.RemoveListener(RemoveButtonClicked);
        _addButton.onClick.RemoveListener(AddButtonClicked);
    }
}