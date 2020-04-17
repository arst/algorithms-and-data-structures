using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class UberRide
    {
        private int democratsCount;
        private int republicansCount;
        private Semaphore ridersCountSemaphore = new Semaphore(1, 1);
        private Semaphore waitForARideAsDemocratSemaphore = new Semaphore(0, 3);
        private Semaphore waitForARideAsRepublicanSemaphore = new Semaphore(0, 3);

        public UberRide()
        {
            democratsCount = 0;
            republicansCount = 0;
        }

        public void RideAsDemocrat(Action<bool> driverAction)
        {
            var rided = false;
            ridersCountSemaphore.WaitOne();
            democratsCount++;
            if (democratsCount >= 4)
            {
                rided = true;
                democratsCount -= 4;
                waitForARideAsDemocratSemaphore.Release(3);
            }
            else if (democratsCount >= 2 && republicansCount >= 2)
            {
                democratsCount -= 2;
                waitForARideAsDemocratSemaphore.Release(2);
                republicansCount -= 2;
                waitForARideAsRepublicanSemaphore.Release(2);
            }
            ridersCountSemaphore.Release();

            if (!rided)
            {
                waitForARideAsDemocratSemaphore.WaitOne();
            }

            driverAction(rided);
        }

        public void RideAsRepublican(Action<bool> driveAction)
        {
            var rided = false;
            ridersCountSemaphore.WaitOne();
            republicansCount++;
            if (republicansCount >= 4)
            {
                rided = true;
                democratsCount -= 4;
                waitForARideAsDemocratSemaphore.Release(3);
            }
            else if (democratsCount >= 2 && republicansCount >= 2)
            {
                democratsCount -= 2;
                waitForARideAsDemocratSemaphore.Release(2);
                republicansCount -= 2;
                waitForARideAsRepublicanSemaphore.Release(2);
            }
            ridersCountSemaphore.Release();

            if (!rided)
            {
                waitForARideAsRepublicanSemaphore.WaitOne();
            }

            driveAction(rided);
        }
    }
}
