using System;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class RatInAMaze
    {
        public bool IsPathExists(int[,] maze, int targetX, int targetY)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            visited[0, 0] = true;
            return Go(maze, 0, 0, targetX, targetY, visited);
        }

        private bool Go(int[,] maze, int positionX, int positionY, int targetX, int targetY, bool[,] visited)
        {
            if (maze[positionX, positionY] == 0)
            {
                return false;
            }

            if (positionX == targetX && positionY == targetY)
            {
                return true;
            }
            visited[positionX, positionY] = true;
            var movesX = new int[] { 1, -1, 0, 0 };
            var movesY = new int[] { 0, 0, 1, -1 };

            for (int i = 0; i < movesX.Length; i++)
            {
                var nextX = positionX + movesX[i];
                var nextY = positionY + movesY[i];

                if (IsSafeMove(maze.GetLength(0), maze.GetLength(1), nextX, nextY) && maze[nextX, nextY] != 0 && !visited[nextX, nextY])
                {
                    if (Go(maze, nextX, nextY, targetX, targetY, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsSafeMove(int xSize, int ySize, int x, int y)
        {
            return x >= 0 && y >= 0 && xSize > x && ySize > y;
        }
    }
}
