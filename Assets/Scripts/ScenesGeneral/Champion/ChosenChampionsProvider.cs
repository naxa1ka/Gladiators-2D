using System.Collections.Generic;

public class ChosenChampionsProvider
{
    private readonly List<Champion> _champions;
    public IReadOnlyList<Champion> ChosenChampions => _champions;

    public ChosenChampionsProvider()
    {
        _champions = new List<Champion>(ChampionSettings.MAXCapacity);
    }
    
    public void Remove(Champion currentChampion)
    {
        _champions.Remove(currentChampion);
    }

    public void Add(Champion currentChampion)
    {
        _champions.Add(currentChampion);
    }
}