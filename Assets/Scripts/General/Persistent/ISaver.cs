public interface ISaver
{
    public void Save(ISaveable obj);
    public void Load(ISaveable obj);
    public bool IsFileExist(ISaveable obj);
}