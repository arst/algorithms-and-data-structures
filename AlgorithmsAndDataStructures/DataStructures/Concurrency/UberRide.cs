using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class UberRide : IDisposable
    {
        private int democratsCount;
        private int republicansCount;
        private readonly Semaphore ridersCountSemaphore = new Semaphore(1, 1);
        private readonly Semaphore waitForARideAsDemocratSemaphore = new Semaphore(0, 3);
        private readonly Semaphore waitForARideAsRepublicanSemaphore = new Semaphore(0, 3);
        private bool disposed;

        public UberRide()
        {
            democratsCount = 0;
            republicansCount = 0;
        }

        public void RideAsDemocrat(Action<bool> driverAction)
        {
            var ride = false;
            ridersCountSemaphore.WaitOne();
            democratsCount++;
            if (democratsCount >= 4)
            {
                ride = true;
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

            if (!ride)
            {
                waitForARideAsDemocratSemaphore.WaitOne();
            }

            driverAction?.Invoke(ride);
        }

        public void RideAsRepublican(Action<bool> driveAction)
        {
            var ride = false;
            ridersCountSemaphore.WaitOne();
            republicansCount++;
            if (republicansCount >= 4)
            {
                ride = true;
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

            if (!ride)
            {
                waitForARideAsRepublicanSemaphore.WaitOne();
            }

            driveAction?.Invoke(ride);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                ridersCountSemaphore?.Dispose();
                waitForARideAsDemocratSemaphore?.Dispose();
                waitForARideAsRepublicanSemaphore?.Dispose();
            }

            disposed = true;
        }
    }
}
