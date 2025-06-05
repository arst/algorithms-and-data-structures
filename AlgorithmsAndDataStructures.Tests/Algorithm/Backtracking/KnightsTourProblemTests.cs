using System;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Backtracking;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Backtracking
{
    public class KnightsTourProblemTests
    {
        [Theory]
        [InlineData(8, 0, 0)]  // Standard board, top-left corner (known good starting point)
        [InlineData(6, 0, 0)]  // 6x6 board, top-left corner
        [InlineData(5, 0, 0)]  // Minimum size board, top-left corner
        public void TryFindTour_ValidInputs_ReturnsTrue(int boardSize, int startX, int startY)
        {
            var sut = new KnightsTour(boardSize);
            Assert.True(sut.TryFindTour(startX, startY));
        }

        [Theory]
        [InlineData(8, 0, 0)]  // Standard board, top-left corner (known good starting point)
        [InlineData(6, 0, 0)]  // 6x6 board, top-left corner
        [InlineData(5, 0, 0)]  // Minimum size board, top-left corner
        public void GetTourPath_ValidInputs_ReturnsValidPath(int boardSize, int startX, int startY)
        {
            var sut = new KnightsTour(boardSize);
            var path = sut.GetTourPath(startX, startY);

            Assert.NotNull(path);
            Assert.Equal(boardSize * boardSize, path.Count);
            
            // Verify the starting position
            var (firstX, firstY) = path[0];
            Assert.Equal(startX, firstX);
            Assert.Equal(startY, firstY);
            
            // Verify each move is valid knight's move
            for (var i = 1; i < path.Count; i++)
            {
                var (x1, y1) = path[i - 1];
                var (x2, y2) = path[i];
                
                var dx = Math.Abs(x2 - x1);
                var dy = Math.Abs(y2 - y1);
                
                Assert.True((dx == 2 && dy == 1) || (dx == 1 && dy == 2),
                    $"Invalid knight's move from ({x1},{y1}) to ({x2},{y2}) at step {i}");
            }

            // Verify all positions are unique
            var uniquePositions = path.Distinct().Count();
            Assert.Equal(boardSize * boardSize, uniquePositions);

            // Verify all positions are within board bounds
            Assert.True(path.All(p => p.x >= 0 && p.x < boardSize && p.y >= 0 && p.y < boardSize),
                "Found position outside board bounds");
        }

        [Theory]
        [InlineData(4)]  // Too small
        [InlineData(0)]  // Invalid
        [InlineData(-1)] // Invalid
        public void Constructor_InvalidBoardSize_ThrowsArgumentException(int size)
        {
            Assert.Throws<ArgumentException>(() => new KnightsTour(size));
        }

        [Theory]
        [InlineData(8, -1, 0)]   // X out of bounds (negative)
        [InlineData(8, 0, -1)]   // Y out of bounds (negative)
        [InlineData(8, 8, 0)]    // X out of bounds (too large)
        [InlineData(8, 0, 8)]    // Y out of bounds (too large)
        [InlineData(5, 5, 0)]    // X out of bounds for minimum board size
        [InlineData(6, 0, 6)]    // Y out of bounds for non-standard board size
        public void TryFindTour_InvalidStartPosition_ThrowsArgumentException(int boardSize, int x, int y)
        {
            var sut = new KnightsTour(boardSize);
            Assert.Throws<ArgumentException>(() => sut.TryFindTour(x, y));
        }

        [Fact]
        public void Constructor_InvalidTimeout_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new KnightsTour(8, timeoutMs: 0));
            Assert.Throws<ArgumentException>(() => new KnightsTour(8, timeoutMs: -1));
        }
    }
}
