using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Roap
{
    public class RoapTests
    {
        [Fact]
        public void CanBuildRope()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap("Test!");
            Assert.Equal("Test!", sut.Traverse());
        }

        [Fact]
        public void CanGetCaracterAtPosition()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap("Test");
            sut.Concat(" value.");

            Assert.Equal('T', sut.CharAt(0));
            Assert.Equal('e', sut.CharAt(1));
            Assert.Equal('s', sut.CharAt(2));
            Assert.Equal('t', sut.CharAt(3));

            Assert.Equal(' ', sut.CharAt(4));
            Assert.Equal('v', sut.CharAt(5));
            Assert.Equal('a', sut.CharAt(6));
            Assert.Equal('l', sut.CharAt(7));
            Assert.Equal('u', sut.CharAt(8));
            Assert.Equal('e', sut.CharAt(9));
            Assert.Equal('.', sut.CharAt(10));
        }

        [Fact]
        public void CantGetCaracterAtPositionOutsideOfAString()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap("Test");
            sut.Concat(" value.");

            Assert.Throws<IndexOutOfRangeException>(() => sut.CharAt(11));
        }

        [Fact]
        public void CanConcatTwoRopesImtoSingleOne()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap("Test");
            sut.Concat(" value.");
            Assert.Equal("Test value.", sut.Traverse());
        }

        [Fact]
        public void CanSplitRopeIntoTwoRopes()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap();
        }

        [Fact]
        public void CanInsertCharacterAtPosition()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap();
        }

        [Fact]
        public void CanDeleteCharacterAtPosition()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap();
        }

        [Fact]
        public void CanGetSubstringFromRope()
        {
            var sut = new AlgorithmsAndDataStructures.DataStructures.Roap.Roap();
        }
    }
}
