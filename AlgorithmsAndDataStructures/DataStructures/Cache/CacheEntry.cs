namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class CacheEntry
    {
        public CacheEntry Previous { get; set; }

        public CacheEntry Next { get; set; }

        public string Value { get; private set; }

        public int Key { get; }

        public CacheEntry(int key, string value)
        {
            Key = key;
            Value = value;
        }

        internal void UpdateValue(string value)
        {
            Value = value;
        }
    }
}
