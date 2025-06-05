using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Utils;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    /// <summary>
    /// Represents a position in the maze
    /// </summary>
    public readonly struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public Position Move(Direction direction) => new Position(X + direction.DX, Y + direction.DY);

        public override string ToString() => $"({X}, {Y})";

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }

    /// <summary>
    /// Represents a direction of movement in the maze
    /// </summary>
    public readonly struct Direction
    {
        public Direction(int dx, int dy, string name)
        {
            DX = dx;
            DY = dy;
            Name = name;
        }

        public int DX { get; }
        public int DY { get; }
        public string Name { get; }

        public override string ToString() => Name;
    }

    /// <summary>
    /// Represents the result of a path finding operation
    /// </summary>
    public class PathFindingResult
    {
        private PathFindingResult(bool success, IReadOnlyList<Position> path = null)
        {
            Success = success;
            Path = path;
        }

        public bool Success { get; }
        public IReadOnlyList<Position> Path { get; }

        public static PathFindingResult Found(IReadOnlyList<Position> path) => new PathFindingResult(true, path);
        public static PathFindingResult NotFound() => new PathFindingResult(false);
    }

    /// <summary>
    /// Validates maze configurations
    /// </summary>
    public class MazeValidator
    {
        public void ValidateMaze(int[][] maze)
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

        public void ValidateTarget(int[][] maze, Position target)
        {
            if (!IsValidPosition(maze.Length, maze[0].Length, target))
            {
                throw new ArgumentException(
                    $"Target position {target} is outside the {maze.Length}x{maze[0].Length} maze");
            }
        }

        public bool IsValidPosition(int rows, int cols, Position pos) =>
            pos.X >= 0 && pos.Y >= 0 && pos.X < rows && pos.Y < cols;
    }

    /// <summary>
    /// Solves the Rat in a Maze problem - finding a path from start (0,0) to a target position
    /// in a maze where 1 represents passable cells and 0 represents walls.
    /// </summary>
    public class RatInAMaze
    {
        private static readonly Direction[] PossibleMoves = {
            new Direction(1, 0, "Down"),
            new Direction(-1, 0, "Up"),
            new Direction(0, 1, "Right"),
            new Direction(0, -1, "Left")
        };

        private readonly MazeValidator validator;

        public RatInAMaze(MazeValidator validator = null)
        {
            this.validator = validator ?? new MazeValidator();
        }

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
            var target = new Position(targetX, targetY);
            return FindPath(maze, target).Success;
        }

        /// <summary>
        /// Finds a path from (0,0) to the target position and returns the result with the path if found.
        /// </summary>
        /// <param name="maze">The maze where 1 represents passable cells and 0 represents walls</param>
        /// <param name="targetX">Target X coordinate</param>
        /// <param name="targetY">Target Y coordinate</param>
        /// <returns>PathFindingResult containing success status and path if found</returns>
        public PathFindingResult FindPath(int[][] maze, int targetX, int targetY)
        {
            return FindPath(maze, new Position(targetX, targetY));
        }

        private PathFindingResult FindPath(int[][] maze, Position target)
        {
            validator.ValidateMaze(maze);
            validator.ValidateTarget(maze, target);

            var visited = ArrayUtils.InitializeMultiDimensionalArray<bool>(maze.Length, maze[0].Length);
            var path = new List<Position>();

            if (TryFindPath(maze, new Position(0, 0), target, visited, path))
            {
                return PathFindingResult.Found(path);
            }

            return PathFindingResult.NotFound();
        }

        private bool TryFindPath(int[][] maze, Position current, Position target,
            IReadOnlyList<bool[]> visited, List<Position> path)
        {
            if (maze[current.X][current.Y] == 0)
            {
                return false;
            }

            path.Add(current);

            if (current.X == target.X && current.Y == target.Y)
            {
                return true;
            }

            visited[current.X][current.Y] = true;

            foreach (var move in PossibleMoves)
            {
                var next = current.Move(move);

                if (validator.IsValidPosition(maze.Length, maze[0].Length, next) &&
                    maze[next.X][next.Y] == 1 && !visited[next.X][next.Y])
                {
                    if (TryFindPath(maze, next, target, visited, path))
                    {
                        return true;
                    }
                }
            }

            visited[current.X][current.Y] = false;
            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}