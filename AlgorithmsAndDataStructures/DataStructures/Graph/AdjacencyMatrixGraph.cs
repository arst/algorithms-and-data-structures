namespace AlgorithmsAndDataStructures.DataStructures.Graph
{
    public class AdjacencyMatrixGraph
    {
        private readonly int[][] graph;

        public AdjacencyMatrixGraph(int capacity)
        {
            graph = new int[capacity][];
        }

        public void AddNode(int source, int destination)
        {
            graph[source][destination] = 1;
            graph[destination][source] = 1;
        }
    }
}
