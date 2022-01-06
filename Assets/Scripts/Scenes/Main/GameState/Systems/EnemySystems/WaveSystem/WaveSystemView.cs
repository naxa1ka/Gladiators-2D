using System;

public class WaveSystemView
{
    private readonly WaveBarView[] _waveBarViews;

    public WaveSystemView(WaveBarView[] waveBarViews)
    {
        if (waveBarViews.Length != WaveSettings.WavesAmount)
        {
            throw new ArgumentException($"Amount bars must match with waves amount (must be {WaveSettings.WavesAmount}!)");
        }
        
        _waveBarViews = waveBarViews;
    }
    
    public void DeactivateBar(int numberOfWave)
    {
        _waveBarViews[numberOfWave].Deactivate();
    }
}