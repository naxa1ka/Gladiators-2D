using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class HeroChooser : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private HeroChooseMediator[] _heroChooseMediators;

    private void OnValidate()
    {
        if (_heroChooseMediators.Length != ChampionChooseSettings.MAXCapacity)
        {
            throw new ArgumentException($"Count mediators must be {ChampionChooseSettings.MAXCapacity}!");
        }
    }

    public void Constructor(IReadOnlyList<Champion> champions)
    {
        for (int i = 0; i < _heroChooseMediators.Length; i++)
        {
            if (i > champions.Count - 1)
            {
                _heroChooseMediators[i].NullInit();
            }
            else
            {
                var champion = champions[i];
                _heroChooseMediators[i].Init(champion);
            }
        }
    }

    public async Task<Champion> ChooseHero()
    {
        _canvasGroup.EnableInteractable();
        
        IEnumerable<UniTask<Champion>> uniTasks = _heroChooseMediators.Select(chooseButton => chooseButton.ChooseHero());
        var valueTuple = await UniTask.WhenAny(uniTasks);
 
        _canvasGroup.DisableInteractable();
        
        return valueTuple.result;
    }
}