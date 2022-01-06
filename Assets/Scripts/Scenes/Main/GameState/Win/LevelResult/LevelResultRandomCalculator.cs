using System.Collections.Generic;

public class LevelResultRandomCalculator : ILevelResultCalculator
{
    private readonly List<LevelState> _levelStates = new List<LevelState>
    {
        LevelState.Start1,
        LevelState.Start2,
        LevelState.Start3
    };

    public LevelState GetResult()
    {
        return _levelStates.RandomItem();
    }
}