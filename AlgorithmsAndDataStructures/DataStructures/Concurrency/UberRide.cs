using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;

public class UberRide : IDisposable
{
    private readonly Semaphore ridersCountSemaphore = new(1, 1);
    private readonly Semaphore waitForARideAsDemocratSemaphore = new(0, 3);
    private readonly Semaphore waitForARideAsRepublicanSemaphore = new(0, 3);
    private int democratsCount;
    private bool disposed;
    private int republicansCount;

    public UberRide()
    {
        democratsCount = 0;
        republicansCount = 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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

        if (!ride) waitForARideAsDemocratSemaphore.WaitOne();

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

        if (!ride) waitForARideAsRepublicanSemaphore.WaitOne();

        driveAction?.Invoke(ride);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
            ridersCountSemaphore?.Dispose();
            waitForARideAsDemocratSemaphore?.Dispose();
            waitForARideAsRepublicanSemaphore?.Dispose();
        }

        disposed = true;
    }
}