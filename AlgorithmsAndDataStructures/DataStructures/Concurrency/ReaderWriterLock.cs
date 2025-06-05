using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
public class ReaderWriterLock
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
{
    private readonly Mutex readersCounterMutex = new();
    private readonly Mutex readersMutex = new();
    private readonly Semaphore writerSemaphore = new(1, 1);
    private volatile int readersCounter;

    public void AcquireReaderLock()
    {
        readersMutex.WaitOne();
        readersCounterMutex.WaitOne();
        readersCounter++;
        if (readersCounter == 1) writerSemaphore.WaitOne();
        readersCounterMutex.ReleaseMutex();
        readersMutex.ReleaseMutex();
    }

    public void ReleaseReaderLock()
    {
        readersCounterMutex.WaitOne();
        readersCounter--;
        if (readersCounter == 0) writerSemaphore.Release();
        readersCounterMutex.ReleaseMutex();
    }

    public void AcquireWriterLock()
    {
        readersMutex.WaitOne();
        writerSemaphore.WaitOne();
    }

    public void ReleaseWriterLock()
    {
        writerSemaphore.Release();
        readersMutex.ReleaseMutex();
    }
}