using System;
using System.Collections.Generic;

public class Carousel<T>
{
    private readonly int _maxIndexArray;
    private int _currentIndexArray;

    private readonly IReadOnlyList<T> _array;
    private T CurrentArrayValue => _array[_currentIndexArray];

    public event Action<T> OnItemChanged;

    public Carousel(IReadOnlyList<T> array, int initIndex = 0)
    {
        _array = array;
        _maxIndexArray =  array.Count - 1;
        
        if (initIndex < 0 || initIndex > _maxIndexArray)
        {
            throw new ArgumentException("Init index should be greater zero and less array length!");
        }
        
        _currentIndexArray = initIndex;
    }

    public void Next()
    {
        if (_currentIndexArray == _maxIndexArray)
        {
            _currentIndexArray = 0;
        }
        else
        {
            _currentIndexArray++;
        }
        
        OnItemChanged?.Invoke(CurrentArrayValue);
    }

    public void Previous()
    {
        if (_currentIndexArray == 0)
        {
            _currentIndexArray = _maxIndexArray;
        }
        else
        {
            _currentIndexArray--;
        }

        OnItemChanged?.Invoke(CurrentArrayValue);
    }
}