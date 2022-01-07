using System.Collections.Generic;

public class LevelResultRandomCalculator : ILevelResultCalculator
{
    private readonly List<LevelResult> _levelStates = new List<LevelResult>
    {
        LevelResult.Start1,
        LevelResult.Start2,
        LevelResult.Start3
    };

    public LevelResult GetResult()
    {
        return _levelStates.RandomItem();
    }
}