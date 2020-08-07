using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Utils;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class RatInAMaze
    {
#pragma warning disable CA1822 // Mark members as static
        public bool IsPathExists(int[][] maze, int targetX, int targetY)
#pragma warning restore CA1822 // Mark members as static
        {
            if (maze == null)
            {
                throw new ArgumentNullException(nameof(maze));
            }
            var visited = ArrayUtils.InitializeMultiDimensionalArray<bool>(maze.Length, maze[0].Length);
            visited[0][0] = true;
            return Go(maze, 0, 0, targetX, targetY, visited);
        }

        private static bool Go(IReadOnlyList<int[]> maze, int positionX, int positionY, int targetX, int targetY, IReadOnlyList<bool[]> visited)
        {
            if (maze[positionX][positionY] == 0)
            {
                return false;
            }

            if (positionX == targetX && positionY == targetY)
            {
                return true;
            }
            visited[positionX][positionY] = true;
            var movesX = new [] { 1, -1, 0, 0 };
            var movesY = new [] { 0, 0, 1, -1 };

            for (var i = 0; i < movesX.Length; i++)
            {
                var nextX = positionX + movesX[i];
                var nextY = positionY + movesY[i];
                var isSafeMove = IsSafeMove(maze.Count, maze[0].Length, nextX, nextY);

                if (isSafeMove && maze[nextX][nextY] != 0 && !visited[nextX][nextY])
                {
                    if (Go(maze, nextX, nextY, targetX, targetY, visited))
                    {
                        return true;
                    }

                    visited[positionX][positionY] = false;
                }
            }

            return false;
        }

        private static bool IsSafeMove(int xSize, int ySize, int x, int y)
        {
            return x >= 0 && y >= 0 && xSize > x && ySize > y;
        }
    }
}
