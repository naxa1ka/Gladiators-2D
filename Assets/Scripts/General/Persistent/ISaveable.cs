public interface ISaveable
{
    public string GetFileName();
    public object SaveableObject { get; }
}