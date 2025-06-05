using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking;

public class RatInAMazeTests
{
    private readonly RatInAMaze sut;
    private readonly MazeValidator validator;

    public RatInAMazeTests()
    {
        validator = new MazeValidator();
        sut = new RatInAMaze(validator);
    }

    [Fact]
    public void IsPathExists_StartEqualsTarget_ReturnsTrue()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1 }
        });

        Assert.True(sut.IsPathExists(maze, 0, 0));
    }

    [Fact]
    public void IsPathExists_SurroundedByWalls_ReturnsFalse()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 0, 0 },
            new[] { 0, 0, 0 },
            new[] { 0, 0, 0 }
        });

        Assert.False(sut.IsPathExists(maze, 2, 2));
    }

    [Fact]
    public void IsPathExists_SimplePath_ReturnsTrue()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 1 },
            new[] { 0, 1 }
        });

        Assert.True(sut.IsPathExists(maze, 1, 1));
    }

    [Fact]
    public void IsPathExists_ComplexPath_ReturnsTrue()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 0, 1, 1, 0 },
            new[] { 1, 1, 1, 0, 1 },
            new[] { 0, 1, 0, 1, 1 },
            new[] { 1, 1, 1, 1, 1 }
        });

        Assert.True(sut.IsPathExists(maze, 2, 3));
    }

    [Fact]
    public void FindPath_StartEqualsTarget_ReturnsSinglePosition()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1 }
        });

        var result = sut.FindPath(maze, 0, 0);

        Assert.True(result.Success);
        Assert.Single(result.Path);
        Assert.Equal(new Position(0, 0), result.Path[0]);
    }

    [Fact]
    public void FindPath_SimplePath_ReturnsCorrectSequence()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 1 },
            new[] { 0, 1 }
        });

        var result = sut.FindPath(maze, 1, 1);

        Assert.True(result.Success);
        Assert.Equal(3, result.Path.Count);
        Assert.Equal(new Position(0, 0), result.Path[0]); // Start
        Assert.Equal(new Position(0, 1), result.Path[1]); // Right
        Assert.Equal(new Position(1, 1), result.Path[2]); // Down
    }

    [Fact]
    public void FindPath_NoPathExists_ReturnsNotFoundResult()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 0 },
            new[] { 0, 1 }
        });

        var result = sut.FindPath(maze, 1, 1);

        Assert.False(result.Success);
        Assert.Null(result.Path);
    }

    [Theory]
    [InlineData(null)]
    public void ValidateMaze_NullMaze_ThrowsArgumentNullException(int[][] maze)
    {
        Assert.Throws<ArgumentNullException>(() => validator.ValidateMaze(maze));
    }

    [Fact]
    public void ValidateMaze_EmptyMaze_ThrowsArgumentException()
    {
        var maze = Array.Empty<int[]>();
        Assert.Throws<ArgumentException>(() => validator.ValidateMaze(maze));
    }

    [Fact]
    public void ValidateMaze_JaggedMaze_ThrowsArgumentException()
    {
        var maze = new[]
        {
            new[] { 1, 1 },
            new[] { 1 }
        };
        Assert.Throws<ArgumentException>(() => validator.ValidateMaze(maze));
    }

    [Fact]
    public void ValidateMaze_BlockedStart_ThrowsArgumentException()
    {
        var maze = CreateMaze(new[]
        {
            new[] { 0, 1 },
            new[] { 1, 1 }
        });
        Assert.Throws<ArgumentException>(() => validator.ValidateMaze(maze));
    }

    [Theory]
    [InlineData(-1, 0)]  // X too small
    [InlineData(0, -1)]  // Y too small
    [InlineData(2, 0)]   // X too large
    [InlineData(0, 2)]   // Y too large
    public void ValidateTarget_InvalidPosition_ThrowsArgumentException(int targetX, int targetY)
    {
        var maze = CreateMaze(new[]
        {
            new[] { 1, 1 }
        });
        Assert.Throws<ArgumentException>(() => 
            validator.ValidateTarget(maze, new Position(targetX, targetY)));
    }

    [Fact]
    public void Position_Move_ReturnsNewPosition()
    {
        var pos = new Position(1, 1);
        var direction = new Direction(1, 0, "Down");

        var newPos = pos.Move(direction);

        Assert.Equal(2, newPos.X);
        Assert.Equal(1, newPos.Y);
    }

    [Fact]
    public void Position_ToString_ReturnsFormattedString()
    {
        var pos = new Position(1, 2);
        Assert.Equal("(1, 2)", pos.ToString());
    }

    [Fact]
    public void Direction_ToString_ReturnsName()
    {
        var direction = new Direction(1, 0, "Down");
        Assert.Equal("Down", direction.ToString());
    }

    private static int[][] CreateMaze(int[][] template)
    {
        var maze = new int[template.Length][];
        for (var i = 0; i < template.Length; i++)
        {
            maze[i] = new int[template[i].Length];
            Array.Copy(template[i], maze[i], template[i].Length);
        }
        return maze;
    }
}