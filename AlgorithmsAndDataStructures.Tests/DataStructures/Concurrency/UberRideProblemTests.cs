using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class UberRideProblemTests
    {
        [Fact]
        public void FourDemocratsCanRide()
        {
            var sut = new UberRide();
            var queue = new ConcurrentQueue<string>();
            var democrat1 = new Thread(() => Ride("D"));
            var democrat2 = new Thread(() => Ride("D"));
            var democrat3 = new Thread(() => Ride("D"));
            var democrat4 = new Thread(() => Ride("D"));

            democrat1.Start();
            democrat2.Start();
            democrat3.Start();
            democrat4.Start();

            democrat1.Join();
            democrat2.Join();
            democrat3.Join();
            democrat4.Join();

            void Ride(string party)
            {
                Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1,5)));
                sut.RideAsDemocrat(isRide => queue.Enqueue((isRide ? "F: " : string.Empty) + party));
            }

            Assert.True(queue.Count(arg => arg.Contains('F')) == 1);
            Assert.True(queue.Count(arg => arg.Contains('D')) == 4);
            Assert.True(queue.Count() == 4);
        }

        [Fact]
        public void PairOfDemocratsAndPairOfRepublicansCanRide()
        {
            var sut = new UberRide();
            var queue = new ConcurrentQueue<string>();
            var democrat1 = new Thread(() => Ride("R"));
            var democrat2 = new Thread(() => Ride("D"));
            var democrat3 = new Thread(() => Ride("R"));
            var democrat4 = new Thread(() => Ride("D"));

            democrat1.Start();
            democrat2.Start();
            democrat3.Start();
            democrat4.Start();

            democrat1.Join();
            democrat2.Join();
            democrat3.Join();
            democrat4.Join();

            void Ride(string party)
            {
                Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 5)));
                sut.RideAsDemocrat(isRide => queue.Enqueue((isRide ? "F: " : string.Empty) + party));
            }

            Assert.True(queue.Count(arg => arg.Contains('F')) == 1);
            Assert.True(queue.Count(arg => arg.Contains('R')) == 2);
            Assert.True(queue.Count(arg => arg.Contains('D')) == 2);
            Assert.True(queue.Count() == 4);
        }

        [Fact]
        public void OnlyValidCombinationsAllowedToRide()
        {
            var sut = new UberRide();
            var queue = new ConcurrentQueue<string>();
            var democrat1 = new Thread(() => Ride("R"));
            var democrat2 = new Thread(() => Ride("D"));
            var democrat3 = new Thread(() => Ride("R"));
            var democrat4 = new Thread(() => Ride("D"));

            var democrat5 = new Thread(() => Ride("D"));
            var democrat6 = new Thread(() => Ride("D"));
            var democrat7 = new Thread(() => Ride("D"));
            var democrat8 = new Thread(() => Ride("D"));

            var democrat9 = new Thread(() => Ride("R"));
            var democrat10 = new Thread(() => Ride("R"));
            var democrat11 = new Thread(() => Ride("R"));
            var democrat12 = new Thread(() => Ride("R"));

            democrat1.Start();
            democrat2.Start();
            democrat3.Start();
            democrat4.Start();

            democrat5.Start();
            democrat6.Start();
            democrat7.Start();
            democrat8.Start();

            democrat9.Start();
            democrat10.Start();
            democrat11.Start();
            democrat12.Start();

            democrat1.Join();
            democrat2.Join();
            democrat3.Join();
            democrat4.Join();

            democrat5.Join();
            democrat6.Join();
            democrat7.Join();
            democrat8.Join();

            democrat9.Join();
            democrat10.Join();
            democrat11.Join();
            democrat12.Join();

            void Ride(string party)
            {
                Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 5)));
                sut.RideAsDemocrat(isRide => queue.Enqueue((isRide ? "F: " : string.Empty) + party));
            }

            Assert.True(queue.Count(arg => arg.Contains('F')) == 3);
            Assert.True(queue.Count(arg => arg.Contains('R')) == 6);
            Assert.True(queue.Count(arg => arg.Contains('D')) == 6);
            Assert.True(queue.Count() == 12);
        }

        [Fact]
        public void SlewOfPeople()
        {
            var sut = new UberRide();
            var queue = new ConcurrentQueue<string>();
            var threads = new Thread[100];

            for (var i = 0; i < 50; i++)
            {
                threads[i] = new Thread(() => Ride("D"));
            }

            for (var i = 50; i < 100; i++)
            {
                threads[i] = new Thread(() => Ride("R"));
            }

            for (var i = 0; i < 100; i++)
            {
                threads[i].Start();
            }

            for (var i = 0; i < 100; i++)
            {
                threads[i].Join();
            }

            void Ride(string party)
            {
                Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 10)));
                sut.RideAsDemocrat(isRide => queue.Enqueue((isRide ? "F: " : string.Empty) + party));
            }

            Assert.True(queue.Count(arg => arg.Contains('F')) == 25);
            Assert.True(queue.Count(arg => arg.Contains('R')) == 50);
            Assert.True(queue.Count(arg => arg.Contains('D')) == 50);
            Assert.True(queue.Count() == 100);
        }
    }
}
