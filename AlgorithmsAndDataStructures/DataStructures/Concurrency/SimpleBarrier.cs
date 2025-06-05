namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;

public class SimpleBarrier
{
    private readonly object counterLock = new();
    private readonly int total;
    private int counter;
    private bool released;

    public SimpleBarrier(int size)
    {
        counter = 0;
        total = size;
    }

    public void Wait()
    {
        var localWait = !released;

        lock (counterLock)
        {
            counter++;

            if (counter == total)
            {
                counter = 0;
                released = localWait;
            }
        }

        while (released != localWait)
        {
        }
    }
}