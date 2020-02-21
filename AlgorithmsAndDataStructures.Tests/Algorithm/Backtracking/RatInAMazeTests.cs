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
            var maze = new int[3,3];
            maze[0, 0] = 1;
            Assert.True(sut.IsPathExists(maze, 0, 0));
        }

        [Fact]
        public void IfSurroundedByDeadEnsPathDonotExists()
        {
            var sut = new RatInAMaze();
            var maze = new int[3, 3];
            maze[0, 0] = 1;
            Assert.False(sut.IsPathExists(maze, 2, 2));
        }

        [Fact]
        public void SimplePath()
        {
            var sut = new RatInAMaze();
            var maze = new int[2, 2];
            maze[0, 0] = 1;
            maze[0, 1] = 1;
            maze[1, 1] = 1;
            Assert.True(sut.IsPathExists(maze, 1, 1));
        }

        [Fact]
        public void ComplexPath()
        {
            var sut = new RatInAMaze();
            var maze = new int[4, 5]
            {
                {1, 0, 1, 1, 0},
                { 1, 1, 1, 0, 1},
                { 0, 1, 0, 1, 1},
                { 1, 1, 1, 1, 1}
            };
            Assert.True(sut.IsPathExists(maze, 2, 3));
        }
    }
}
