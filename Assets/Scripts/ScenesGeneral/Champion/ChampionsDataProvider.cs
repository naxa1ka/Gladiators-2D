using System.Collections.Generic;
using UnityEngine;

public class ChampionsDataProvider 
{
    private const string Path = "Champions";

    private readonly Champion[] _champions;
    
    public IReadOnlyList<Champion> Champions => _champions;
    public IReadOnlyList<Champion> ChosenChampions => ChosenChampionsProvider.ChosenChampions;
    public ChosenChampionsProvider ChosenChampionsProvider { get; }
    
    public ChampionsDataProvider()
    {
        _champions = Resources.LoadAll<Champion>(Path);
        ChosenChampionsProvider = new ChosenChampionsProvider();
    }
}