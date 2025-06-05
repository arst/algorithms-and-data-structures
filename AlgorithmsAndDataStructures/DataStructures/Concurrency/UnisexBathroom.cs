﻿using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;

public class UnisexBathroom : IDisposable
{
    private readonly Semaphore femaleCounterSemaphore;
    private readonly Semaphore femaleTurnSemaphore;
    private readonly Semaphore maleCounterSemaphore;
    private readonly Semaphore maleTurnSemaphore;
    private readonly Semaphore occupiedSemaphore;
    private readonly Semaphore starvationPreventionSemaphore;
    private bool disposed;
    private int femaleCount;
    private int maleCount;

    public UnisexBathroom()
    {
        maleCounterSemaphore = new Semaphore(0, 3);
        femaleCounterSemaphore = new Semaphore(0, 3);
        occupiedSemaphore = new Semaphore(0, 1);
        femaleTurnSemaphore = new Semaphore(0, 1);
        maleTurnSemaphore = new Semaphore(0, 1);
        starvationPreventionSemaphore = new Semaphore(0, 1);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Enter(int gender)
    {
        if (gender == 0)
            EnterMale();
        else
            EnterFemale();
    }

    private void EnterFemale()
    {
        starvationPreventionSemaphore.WaitOne();
        femaleTurnSemaphore.WaitOne();
        femaleCount += 1;

        if (femaleCount == 1) occupiedSemaphore.WaitOne();

        femaleTurnSemaphore.Release();
        starvationPreventionSemaphore.Release();

        femaleCounterSemaphore.WaitOne();

        Console.WriteLine("In a bathroom F.");
        Thread.Sleep(TimeSpan.FromSeconds(1));

        femaleCounterSemaphore.Release();
        femaleTurnSemaphore.WaitOne();
        femaleCount -= 1;

        if (femaleCount == 0) occupiedSemaphore.Release();

        femaleTurnSemaphore.Release();
    }

    private void EnterMale()
    {
        starvationPreventionSemaphore.WaitOne();
        maleTurnSemaphore.WaitOne();

        maleCount += 1;

        if (maleCount == 1) occupiedSemaphore.WaitOne();

        maleTurnSemaphore.Release();
        starvationPreventionSemaphore.Release();
        maleCounterSemaphore.WaitOne();

        Console.WriteLine("In a bath room M.");
        Thread.Sleep(TimeSpan.FromSeconds(1));

        maleCounterSemaphore.Release();

        maleTurnSemaphore.WaitOne();

        maleCount -= 1;

        if (maleCount == 0) occupiedSemaphore.Release();

        maleTurnSemaphore.Release();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
            maleCounterSemaphore?.Dispose();
            femaleTurnSemaphore?.Dispose();
            maleTurnSemaphore?.Dispose();
            starvationPreventionSemaphore?.Dispose();
            femaleCounterSemaphore?.Dispose();
            occupiedSemaphore?.Dispose();
        }

        disposed = true;
    }
}