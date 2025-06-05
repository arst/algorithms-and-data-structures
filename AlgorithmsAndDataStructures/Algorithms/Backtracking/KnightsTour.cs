using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking;

/// <summary>
///     Solves the Knight's Tour problem - finding a sequence of moves for a knight
///     that visits every square on a chess board exactly once.
/// </summary>
public class KnightsTour
{
    private const int StartingMoveNumber = 1;
    private const int SecondMoveNumber = StartingMoveNumber + 1;
    private const int MinimumBoardSize = 5; // Boards smaller than 5x5 have no solution
    private const int DefaultTimeoutMs = 5000; // 5 seconds timeout

    private static readonly (int dx, int dy)[] PossibleMoves =
    {
        (2, 1), (1, 2), (-1, 2), (-2, 1),
        (-2, -1), (-1, -2), (1, -2), (2, -1)
    };

    private readonly int[][] board;

    private readonly int boardSize;
    private readonly Stopwatch stopwatch;
    private readonly int timeoutMs;

    /// <summary>
    ///     Initializes a new instance of the KnightsTour class.
    /// </summary>
    /// <param name="boardSize">Size of the chess board (default is 8 for standard chess board)</param>
    /// <param name="timeoutMs">Timeout in milliseconds (default is 5000ms)</param>
    /// <exception cref="ArgumentException">Thrown when board size is less than 5 (as smaller boards have no solution)</exception>
    public KnightsTour(int boardSize = 8, int timeoutMs = DefaultTimeoutMs)
    {
        if (boardSize < MinimumBoardSize)
            throw new ArgumentException($"Board size must be at least {MinimumBoardSize}x{MinimumBoardSize}",
                nameof(boardSize));

        if (timeoutMs <= 0) throw new ArgumentException("Timeout must be positive", nameof(timeoutMs));

        this.boardSize = boardSize;
        board = CreateBoard(boardSize);
        this.timeoutMs = timeoutMs;
        stopwatch = new Stopwatch();
    }

    /// <summary>
    ///     Attempts to find a knight's tour starting from the specified position.
    /// </summary>
    /// <param name="startX">Starting X coordinate (0-based)</param>
    /// <param name="startY">Starting Y coordinate (0-based)</param>
    /// <returns>True if a tour was found, false otherwise</returns>
    /// <exception cref="TimeoutException">Thrown when the search exceeds the specified timeout</exception>
    public bool TryFindTour(int startX = 0, int startY = 0)
    {
        ValidateStartingPosition(startX, startY);
        ResetBoard();

        stopwatch.Restart();
        board[startX][startY] = StartingMoveNumber;

        try
        {
            return TryMove(startX, startY, SecondMoveNumber);
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    /// <summary>
    ///     Attempts to find a knight's tour and returns the sequence of moves if successful.
    /// </summary>
    /// <param name="startX">Starting X coordinate (0-based)</param>
    /// <param name="startY">Starting Y coordinate (0-based)</param>
    /// <returns>List of moves if a tour was found, null otherwise</returns>
    /// <exception cref="TimeoutException">Thrown when the search exceeds the specified timeout</exception>
    public List<(int x, int y)> GetTourPath(int startX = 0, int startY = 0)
    {
        if (!TryFindTour(startX, startY)) return null;

        var path = new List<(int x, int y)>(boardSize * boardSize);
        var moves = new int[boardSize * boardSize + 1];

        // Convert board state to ordered path
        for (var x = 0; x < boardSize; x++)
        for (var y = 0; y < boardSize; y++)
            moves[board[x][y]] = x * boardSize + y;

        // Convert positions back to coordinates
        for (var i = StartingMoveNumber; i <= boardSize * boardSize; i++)
        {
            var pos = moves[i];
            path.Add((pos / boardSize, pos % boardSize));
        }

        return path;
    }

    private static int[][] CreateBoard(int size)
    {
        var board = new int[size][];
        for (var i = 0; i < size; i++) board[i] = new int[size];
        return board;
    }

    private void ResetBoard()
    {
        for (var i = 0; i < boardSize; i++) Array.Clear(board[i], 0, boardSize);
    }

    private bool TryMove(int currentX, int currentY, int moveNumber)
    {
        if (stopwatch.ElapsedMilliseconds > timeoutMs)
            throw new TimeoutException($"Failed to find solution within {timeoutMs}ms");

        if (moveNumber > boardSize * boardSize) return true;

        // Use Warnsdorff's heuristic: try moves with fewest onward moves first
        var nextMoves = new List<(int x, int y, int accessibility)>();
        foreach (var (dx, dy) in PossibleMoves)
        {
            var nextX = currentX + dx;
            var nextY = currentY + dy;

            if (IsValidMove(nextX, nextY) && board[nextX][nextY] == 0)
            {
                var accessibility = CountAccessibleMoves(nextX, nextY);
                nextMoves.Add((nextX, nextY, accessibility));
            }
        }

        // Sort moves by accessibility (fewest options first)
        nextMoves.Sort((a, b) => a.accessibility.CompareTo(b.accessibility));

        foreach (var (nextX, nextY, _) in nextMoves)
        {
            board[nextX][nextY] = moveNumber;
            if (TryMove(nextX, nextY, moveNumber + 1)) return true;
            board[nextX][nextY] = 0;
        }

        return false;
    }

    private int CountAccessibleMoves(int x, int y)
    {
        var count = 0;
        foreach (var (dx, dy) in PossibleMoves)
        {
            var nextX = x + dx;
            var nextY = y + dy;
            if (IsValidMove(nextX, nextY) && board[nextX][nextY] == 0) count++;
        }

        return count;
    }

    private bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < boardSize && y >= 0 && y < boardSize;
    }

    private void ValidateStartingPosition(int x, int y)
    {
        if (!IsValidMove(x, y))
            throw new ArgumentException($"Starting position ({x},{y}) is outside the {boardSize}x{boardSize} board");
    }
}