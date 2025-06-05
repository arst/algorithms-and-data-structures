namespace AlgorithmsAndDataStructures.DataStructures.Cache;

public class CacheMeanHeapEntry
{
    public CacheMeanHeapEntry(int key, string value)
    {
        Key = key;
        Value = value;
        Frequency = 1;
    }

    public int Key { get; }
    public string Value { get; private set; }

    public int Frequency { get; private set; }

    public void IncrementFrequency()
    {
        Frequency++;
    }

    public void SetValue(string value)
    {
        Value = value;
    }
}