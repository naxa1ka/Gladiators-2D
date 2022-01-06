using System.Collections.Generic;
using UnityEngine;

public class LevelFiller : MonoBehaviour
{
    [SerializeField] private LevelStateView _levelStateView;

    private void Start()
    {
        FillLevels();
    }

    private void FillLevels()
    {
        var levels = new LevelsDataProvider().Levels;

        var levelViews = GetComponentsInChildren<LevelView>();
        var levelButtons = GetComponentsInChildren<LevelButton>();

        InitButtons(levels, levelButtons);
        InitView(levelViews, levels);
    }

    private void InitButtons(IReadOnlyList<Level> levels, LevelButton[] levelButtons)
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

    private void InitView(LevelView[] levelViews, IReadOnlyList<Level> levels)
    {
        for (int i = 0; i < levelViews.Length; i++)
        {
            Sprite sprite;
            if (i > levels.Count - 1)
            {
                sprite = _levelStateView.Get(LevelState.LevelLocked);
            }
            else
            {
                sprite = _levelStateView.Get(levels[i].LevelState);
            }

            levelViews[i].Init(sprite);
        }
    }
}