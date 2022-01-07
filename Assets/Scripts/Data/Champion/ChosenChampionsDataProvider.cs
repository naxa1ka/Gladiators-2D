using System.Collections.Generic;

public class ChosenChampionsDataProvider
{
    private readonly List<Champion> _champions;
    public IReadOnlyList<Champion> ChosenChampions => _champions;

    public ChosenChampionsDataProvider()
    {
        _champions = new List<Champion>(ChampionChooseSettings.MAXCapacity);
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