using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyChooser : MonoBehaviour
{
    [SerializeField] private CanvasGroup _chooseCanvasView;
    [SerializeField] private EnemyChooseMediator[] _enemyChooseMediators;

    private void OnValidate()
    {
        if (_enemyChooseMediators.Length != WaveSettings.WaveSize)
        {
            throw new ArgumentException($"Count mediators must be {WaveSettings.WaveSize}!");
        }
    }

    public void Init(Enemy[] enemies)
    {
        for (var i = 0; i < _enemyChooseMediators.Length; i++)
        {
            _enemyChooseMediators[i].Init(enemies[i]);
        }
    }
    
    public async Task<Character> ChooseEnemy()
    {
        Enable();
        
        IEnumerable<UniTask<Enemy>> uniTasks = _enemyChooseMediators.Select(chooseButton => chooseButton.ChooseEnemy());
        var valueTuple = await UniTask.WhenAny(uniTasks);
 
        Disable();
        
        return valueTuple.result;
    }

    public void Disable()
    {
        _chooseCanvasView.DisableInteractable();
    }

    public void Enable()
    {
        _chooseCanvasView.EnableInteractable();
    }
} 