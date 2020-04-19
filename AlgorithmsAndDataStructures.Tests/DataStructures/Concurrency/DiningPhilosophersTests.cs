using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using System;
using System.Threading;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class DiningPhilosophersTests
    {
        [Fact]
        public void CanDine()
        {
            var sut = new DiningPhilosophers();

            var philosopher0 = new Thread(() => Dine(0));
            var philosopher1 = new Thread(() => Dine(1));
            var philosopher2 = new Thread(() => Dine(2));
            var philosopher3 = new Thread(() => Dine(3));
            var philosopher4 = new Thread(() => Dine(4));

            philosopher0.Start();
            philosopher1.Start();
            philosopher2.Start();
            philosopher3.Start();
            philosopher4.Start();

            philosopher0.Join();
            philosopher1.Join();
            philosopher2.Join();
            philosopher3.Join();
            philosopher4.Join();


            void Dine(int philosopherNumber)
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1,5)));
                    sut.Dine(philosopherNumber);
                }
            }
        }
    }
}
