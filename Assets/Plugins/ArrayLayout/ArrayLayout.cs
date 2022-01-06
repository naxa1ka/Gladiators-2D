[System.Serializable]
public class ArrayLayout<T>
{
    [System.Serializable]
    public struct RowData
    {
        public T[] row;
    }

    public RowData[] rows = new RowData[Size]; 
    
    public T this[int i, int j]
    {
        get => rows[i].row[j];
        set => rows[i].row[j] = value;
    }
    public const int Size = 7;
}
