using System;

public interface IHealth
{
    public event Action<float, float> OnHealthChanged;
}