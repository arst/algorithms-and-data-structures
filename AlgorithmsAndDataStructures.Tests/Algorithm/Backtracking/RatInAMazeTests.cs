using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking;

public class RatInAMazeTests
{
    [Fact]
    public void IsPathExists_StartEqualsTarget_ReturnsTrue()
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 1 }
        });

        Assert.True(sut.IsPathExists(maze, 0, 0));
    }

    [Fact]
    public void IsPathExists_SurroundedByWalls_ReturnsFalse()
    {
        var sut = new RatInAMaze();
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
        var sut = new RatInAMaze();
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
        var sut = new RatInAMaze();
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
    public void GetPath_StartEqualsTarget_ReturnsSinglePosition()
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 1 }
        });

        var path = sut.GetPath(maze, 0, 0);

        Assert.NotNull(path);
        Assert.Single(path);
        Assert.Equal((0, 0), path[0]);
    }

    [Fact]
    public void GetPath_SimplePath_ReturnsCorrectSequence()
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 1, 1 },
            new[] { 0, 1 }
        });

        var path = sut.GetPath(maze, 1, 1);

        Assert.NotNull(path);
        Assert.Equal(3, path.Count);
        Assert.Equal((0, 0), path[0]); // Start
        Assert.Equal((0, 1), path[1]); // Right
        Assert.Equal((1, 1), path[2]); // Down
    }

    [Fact]
    public void GetPath_NoPathExists_ReturnsNull()
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 1, 0 },
            new[] { 0, 1 }
        });

        var path = sut.GetPath(maze, 1, 1);

        Assert.Null(path);
    }

    [Theory]
    [InlineData(null)]
    public void IsPathExists_NullMaze_ThrowsArgumentNullException(int[][] maze)
    {
        var sut = new RatInAMaze();
        Assert.Throws<ArgumentNullException>(() => sut.IsPathExists(maze, 0, 0));
    }

    [Fact]
    public void IsPathExists_EmptyMaze_ThrowsArgumentException()
    {
        var sut = new RatInAMaze();
        var maze = Array.Empty<int[]>();
        Assert.Throws<ArgumentException>(() => sut.IsPathExists(maze, 0, 0));
    }

    [Fact]
    public void IsPathExists_JaggedMaze_ThrowsArgumentException()
    {
        var sut = new RatInAMaze();
        var maze = new[]
        {
            new[] { 1, 1 },
            new[] { 1 }
        };
        Assert.Throws<ArgumentException>(() => sut.IsPathExists(maze, 1, 1));
    }

    [Fact]
    public void IsPathExists_BlockedStart_ThrowsArgumentException()
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 0, 1 },
            new[] { 1, 1 }
        });
        Assert.Throws<ArgumentException>(() => sut.IsPathExists(maze, 1, 1));
    }

    [Theory]
    [InlineData(-1, 0)]  // X too small
    [InlineData(0, -1)]  // Y too small
    [InlineData(2, 0)]   // X too large
    [InlineData(0, 2)]   // Y too large
    public void IsPathExists_InvalidTarget_ThrowsArgumentException(int targetX, int targetY)
    {
        var sut = new RatInAMaze();
        var maze = CreateMaze(new[]
        {
            new[] { 1, 1 }
        });
        Assert.Throws<ArgumentException>(() => sut.IsPathExists(maze, targetX, targetY));
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