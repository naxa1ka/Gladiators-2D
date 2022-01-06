using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Reviver : MonoBehaviour
{
    [SerializeField] private HeroSystem _heroSystem;
    
    private IReadOnlyList<Champion> _champions;
    private bool _isAlreadyRevived;

    public bool IsAlreadyRevived => _isAlreadyRevived;
    
    [Inject]
    private void Constructor(IReadOnlyList<Champion> champions)
    {
        _champions = champions;
    }
    
    public void Reinit()
    {
        if (_isAlreadyRevived)
        {
            throw new ArgumentException("Hero is been revived!");
        }
        
        _heroSystem.Init(_champions);
        _isAlreadyRevived = true;
    }
    
}