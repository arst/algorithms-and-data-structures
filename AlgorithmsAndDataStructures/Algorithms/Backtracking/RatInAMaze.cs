using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Utils;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    /// <summary>
    /// Solves the Rat in a Maze problem - finding a path from start (0,0) to a target position
    /// in a maze where 1 represents passable cells and 0 represents walls.
    /// </summary>
    public class RatInAMaze
    {
        private static readonly (int dx, int dy)[] PossibleMoves = {
            (1, 0),  // Down
            (-1, 0), // Up
            (0, 1),  // Right
            (0, -1)  // Left
        };

        /// <summary>
        /// Checks if there exists a path from (0,0) to the target position.
        /// </summary>
        /// <param name="maze">The maze where 1 represents passable cells and 0 represents walls</param>
        /// <param name="targetX">Target X coordinate</param>
        /// <param name="targetY">Target Y coordinate</param>
        /// <returns>True if a path exists, false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown when maze is null</exception>
        /// <exception cref="ArgumentException">Thrown when maze is empty or jagged</exception>
        public bool IsPathExists(int[][] maze, int targetX, int targetY)
        {
            ValidateMaze(maze);
            ValidateTarget(maze, targetX, targetY);

            var visited = ArrayUtils.InitializeMultiDimensionalArray<bool>(maze.Length, maze[0].Length);
            return TryFindPath(maze, 0, 0, targetX, targetY, visited);
        }

        /// <summary>
        /// Finds a path from (0,0) to the target position and returns the sequence of moves.
        /// </summary>
        /// <param name="maze">The maze where 1 represents passable cells and 0 represents walls</param>
        /// <param name="targetX">Target X coordinate</param>
        /// <param name="targetY">Target Y coordinate</param>
        /// <returns>List of positions representing the path if found, null otherwise</returns>
        public List<(int x, int y)> GetPath(int[][] maze, int targetX, int targetY)
        {
            ValidateMaze(maze);
            ValidateTarget(maze, targetX, targetY);

            var visited = ArrayUtils.InitializeMultiDimensionalArray<bool>(maze.Length, maze[0].Length);
            var path = new List<(int x, int y)>();
            
            if (FindPathWithTracking(maze, 0, 0, targetX, targetY, visited, path))
            {
                return path;
            }

            return null;
        }

        private static void ValidateMaze(int[][] maze)
        {
            if (maze == null)
            {
                throw new ArgumentNullException(nameof(maze));
            }

            if (maze.Length == 0)
            {
                throw new ArgumentException("Maze cannot be empty", nameof(maze));
            }

            var width = maze[0]?.Length ?? 0;
            if (width == 0)
            {
                throw new ArgumentException("Maze rows cannot be empty", nameof(maze));
            }

            // Check for jagged arrays
            for (var i = 1; i < maze.Length; i++)
            {
                if (maze[i] == null || maze[i].Length != width)
                {
                    throw new ArgumentException("All maze rows must have the same length", nameof(maze));
                }
            }

            // Check if starting position is valid
            if (maze[0][0] == 0)
            {
                throw new ArgumentException("Starting position (0,0) must be passable", nameof(maze));
            }
        }

        private static void ValidateTarget(int[][] maze, int targetX, int targetY)
        {
            if (!IsValidPosition(maze.Length, maze[0].Length, targetX, targetY))
            {
                throw new ArgumentException(
                    $"Target position ({targetX},{targetY}) is outside the {maze.Length}x{maze[0].Length} maze");
            }
        }

        private static bool TryFindPath(IReadOnlyList<int[]> maze, int currentX, int currentY, 
            int targetX, int targetY, IReadOnlyList<bool[]> visited)
        {
            if (maze[currentX][currentY] == 0)
            {
                return false;
            }

            if (currentX == targetX && currentY == targetY)
            {
                return true;
            }

            visited[currentX][currentY] = true;

            foreach (var (dx, dy) in PossibleMoves)
            {
                var nextX = currentX + dx;
                var nextY = currentY + dy;

                if (IsValidPosition(maze.Count, maze[0].Length, nextX, nextY) && 
                    maze[nextX][nextY] == 1 && !visited[nextX][nextY])
                {
                    if (TryFindPath(maze, nextX, nextY, targetX, targetY, visited))
                    {
                        return true;
                    }
                }
            }

            visited[currentX][currentY] = false;
            return false;
        }

        private static bool FindPathWithTracking(IReadOnlyList<int[]> maze, int currentX, int currentY,
            int targetX, int targetY, IReadOnlyList<bool[]> visited, List<(int x, int y)> path)
        {
            if (maze[currentX][currentY] == 0)
            {
                return false;
            }

            path.Add((currentX, currentY));

            if (currentX == targetX && currentY == targetY)
            {
                return true;
            }

            visited[currentX][currentY] = true;

            foreach (var (dx, dy) in PossibleMoves)
            {
                var nextX = currentX + dx;
                var nextY = currentY + dy;

                if (IsValidPosition(maze.Count, maze[0].Length, nextX, nextY) &&
                    maze[nextX][nextY] == 1 && !visited[nextX][nextY])
                {
                    if (FindPathWithTracking(maze, nextX, nextY, targetX, targetY, visited, path))
                    {
                        return true;
                    }
                }
            }

            visited[currentX][currentY] = false;
            path.RemoveAt(path.Count - 1);
            return false;
        }

        private static bool IsValidPosition(int rows, int cols, int x, int y) =>
            x >= 0 && y >= 0 && x < rows && y < cols;
    }
}