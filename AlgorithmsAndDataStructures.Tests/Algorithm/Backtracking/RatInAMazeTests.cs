using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking
{
    public class RatInAMazeTests
    {
        [Fact]
        public void IfStartedAtTargetThenPathExists()
        {
            var sut = new RatInAMaze();
            const int sampleSize = 3;
            var maze = new int[sampleSize][];
            maze[0] = new int[sampleSize];
            maze[0][0] = 1;
            Assert.True(sut.IsPathExists(maze, 0, 0));
        }

        [Fact]
        public void IfSurroundedByDeadEnsPathDoNotExists()
        {
            var sut = new RatInAMaze();
            const int sampleSize = 3;
            var maze = new int[sampleSize][];
            maze[0] = new int[sampleSize];
            maze[1] = new int[sampleSize];
            maze[2] = new int[sampleSize];
            maze[0][0] = 1;
            Assert.False(sut.IsPathExists(maze, 2, 2));
        }

        [Fact]
        public void SimplePath()
        {
            var sut = new RatInAMaze();
            const int sampleSize = 2;
            var maze = new int[sampleSize][];
            maze[0] = new int[sampleSize];
            maze[1] = new int[sampleSize];
            maze[0][0] = 1;
            maze[0][1] = 1;
            maze[1][1] = 1;
            Assert.True(sut.IsPathExists(maze, 1, 1));
        }

        [Fact]
        public void ComplexPath()
        {
            var sut = new RatInAMaze();

            var maze = new int[4][];
            maze[0] = new[] {1, 0, 1, 1, 0};
            maze[1] = new[] {1, 1, 1, 0, 1};
            maze[2] = new[] {0, 1, 0, 1, 1};
            maze[3] = new[] {1, 1, 1, 1, 1};

            Assert.True(sut.IsPathExists(maze, 2, 3));
        }
    }
}
