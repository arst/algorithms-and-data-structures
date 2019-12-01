using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.LinkedList
{
    public class SkipListTests
    {
        [Fact]
        public void Test()
        {
            var sut = new SkipList<int>(3);

            for (int i = 0; i < 100; i++)
            {
                var r = new Random();
                var value = r.Next(1,100);
                sut.Append(value);
            }

            sut.PintSkipList();
            
        }
    }
}
