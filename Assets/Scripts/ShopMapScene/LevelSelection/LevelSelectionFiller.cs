using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelSelectionFiller : MonoBehaviour
{
    [SerializeField] private SelectableLevelViewFactory _selectableLevelViewFactory;
    
    private SelectableLevelView[] _levelViews;
    private SelectableLevelButton[] _levelButtons;
    
    private LevelsDataProvider _levelsDataProvider;

    private void Awake()
    {
        _levelViews = GetComponentsInChildren<SelectableLevelView>();
        _levelButtons = GetComponentsInChildren<SelectableLevelButton>();
    }

    [Inject]
    private void Constructor(LevelsDataProvider levelsDataProvider)
    {
        _levelsDataProvider = levelsDataProvider;
    }
    
    private void Start()
    {
        var levels = _levelsDataProvider.Levels;
        
        InitButtons(levels, _levelButtons);
        InitView(levels, _levelViews);
    }

    private void InitButtons(IReadOnlyList<Level> levels, SelectableLevelButton[] levelButtons)
    {
        for (var i = 0; i < levelButtons.Length; i++)
        {
            if (i > levels.Count - 1)
            {
                levelButtons[i].EmptyInit();
            }
            else
            {
                levelButtons[i].Init(levels[i]);
            }
        }
    }

    private void InitView(IReadOnlyList<Level> levels, SelectableLevelView[] levelViews)
    {
        for (int i = 0; i < levelViews.Length; i++)
        {
            Sprite sprite;
            if (i > levels.Count - 1)
            {
                sprite = _selectableLevelViewFactory.Get(LevelResult.LevelLocked);
            }
            else
            {
                sprite = _selectableLevelViewFactory.Get(levels[i].LevelResult);
            }

            levelViews[i].Init(sprite);
        }
    }
}