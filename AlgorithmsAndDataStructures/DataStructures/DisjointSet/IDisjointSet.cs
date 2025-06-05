namespace AlgorithmsAndDataStructures.DataStructures.DisjointSet;

public interface IDisjointSet
{
    void Union(int a, int b);

    bool Connected(int a, int b);
}