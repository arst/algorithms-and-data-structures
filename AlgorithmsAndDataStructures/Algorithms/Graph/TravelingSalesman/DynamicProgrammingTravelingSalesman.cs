using System;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman
{
    public class DynamicProgrammingTravelingSalesman
    {
        public int GetPath(int[][] graph)
        {
            var dp = new int[(int)Math.Pow(2, graph.Length)][];
            var allvisited = (1 << graph.Length) - 1;

            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[graph.Length];

                for (var j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }

            var currentRoute = 1; // 0000000000000001 - starting city marked as visited
            var currentCity = 0; // city at which we start the travel
            return Travel(graph, dp, allvisited, currentRoute, currentCity);
        }

        private int Travel(int[][] graph, int[][] dp, double allvisited, int currentRoute, int currentCity)
        {
            if (currentRoute == allvisited)
            {
                // If all cities visited we need to return to the starting city.
                return graph[currentCity][0];
            }

            if (dp[currentRoute][currentCity] != -1)
            {
                // If disatnce is already precalculated we can reuse it.
                return dp[currentRoute][currentCity];
            }

            var minDistance = int.MaxValue;

            for (var city = 0; city < graph.Length; city++)
            {
                // Check if city is already a part of the route.
                if ((currentRoute & (1 << city)) == 0)
                {
                    var distanceThroughCity = graph[currentCity][city] + Travel(graph, dp, allvisited, currentRoute | (1 << city) /*to ensure that city is included in the route*/, city/*we travel further from the city*/);

                    minDistance = Math.Min(minDistance, distanceThroughCity);
                }
            }

            dp[currentRoute][currentCity] = minDistance;

            return minDistance;
        }
    }
}
